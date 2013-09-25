using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using FileUtilities.Properties;

namespace FileUtilities
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public enum Tabs { Organize = 0, Sort = 1, Rename = 2, Resize = 3, Duplicates = 4 };
		public enum ConstraintTypes{Landscape = 0, Portrait = 1, Ratio = 2};
		const int BYTES_TO_READ = sizeof(Int64);

		#region Form Events

		private void cmdRun_Click(object sender, EventArgs e)
		{
			//set cursor to wait
			Cursor = Cursors.WaitCursor;
			cmdRun.Enabled = false;
			cmdCancel.Enabled = true;
			EnableForm(false);
			
			//set the processing counter
			FilesProcessed = 0;

			//count total files
			TotalFiles = new DirectoryInfo(Settings.Source).GetFiles("*.*", SearchOption.AllDirectories).Count();
			statusProgress.Step = 1;
			statusProgress.Maximum = TotalFiles;
			statusProgress.Minimum = 0;

			Refresh();
			
			if(SelectedTab == Tabs.Sort)
			{
				statusLabel.Text = "Sorting...";
				
				//sort individual files
				Worker.RunWorkerAsync(Settings.Default);
			}

			if (SelectedTab == Tabs.Organize)
			{
				statusLabel.Text = "Organizing...";

				//sort individual files
				Worker.RunWorkerAsync(Settings.Default);
			}

			if (SelectedTab == Tabs.Rename)
			{
				statusLabel.Text = "Renaming...";

				//set the Counter property of CopyOperations to the latest counter
				Counter = Settings.StartNumber;

				Worker.RunWorkerAsync(Settings.Default);
			}

			if (SelectedTab == Tabs.Resize)
			{
				if (radioLandscape.Checked)
				{
					ConstraintType = ConstraintTypes.Landscape;
					Constraint = Convert.ToInt32(txtLandscape.Text);
				}

				if (radioPortrait.Checked)
				{
					ConstraintType = ConstraintTypes.Portrait;
					Constraint = Convert.ToInt32(txtPortrait.Text);
				}

				if (radioRatio.Checked)
				{
					ConstraintType = ConstraintTypes.Ratio;
					Constraint = Convert.ToInt32(txtRatio.Text);
				}

				statusLabel.Text = "Resizing...";
				Worker.RunWorkerAsync(Settings.Default);
			}

			if (SelectedTab == Tabs.Duplicates)
			{
				statusLabel.Text = "Finding duplicates...";

				if(Duplicates != null && Duplicates.Count > 0)
				{
					Duplicates.Clear();
				}
				gridDuplicates.Rows.Clear();
				gridDuplicates.Refresh();

				Worker.RunWorkerAsync(Settings.Default);

			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			if (Worker.WorkerSupportsCancellation)
			{
				// Cancel the asynchronous operation.
				Worker.CancelAsync();
				WorkerCancelled = true;
				cmdCancel.Enabled = false;
				cmdRun.Enabled = false;
			}
		}

		private void txtLandscape_Enter(object sender, EventArgs e)
		{
			radioLandscape.Checked = true;
		}

		private void txtPortrait_Enter(object sender, EventArgs e)
		{
			radioPortrait.Checked = true;
		}

		private void txtRatio_Enter(object sender, EventArgs e)
		{
			radioRatio.Checked = true;
		}

		private void tabContainer_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedTabIndex = tabContainer.SelectedIndex;
			txtOutputDirectory.Enabled = true;
			btnOutputBrowse.Enabled = true;

			Settings.SelectedTab = SelectedTabIndex;
			Settings.Save();

			if (SelectedTabIndex == Convert.ToInt32(Tabs.Resize))
			{
				SelectedTab = Tabs.Resize;

				switch (Settings.ConstraintTypeSelection)
				{
					case "Landscape":
						radioLandscape.Checked = true;
						break;
					case "Portrait":
						radioPortrait.Checked = true;
						break;
					case "Ratio":
						radioRatio.Checked = true;
						break;
				}
				
				txtLandscape.Text = Settings.ConstraintLandscape.ToString(CultureInfo.InvariantCulture);
				txtPortrait.Text = Settings.ConstraintPortrait.ToString(CultureInfo.InvariantCulture);
				txtRatio.Text = Settings.ConstraintRatio.ToString(CultureInfo.InvariantCulture);
			}
			if (SelectedTabIndex == Convert.ToInt32(Tabs.Sort))
			{
				SelectedTab = Tabs.Sort;
			}

			if (SelectedTabIndex == Convert.ToInt32(Tabs.Organize))
			{
				SelectedTab = Tabs.Organize;
			}

			if (SelectedTabIndex == Convert.ToInt32(Tabs.Rename))
			{
				SelectedTab = Tabs.Rename;
			}

			if (SelectedTabIndex == Convert.ToInt32(Tabs.Duplicates))
			{
				SelectedTab = Tabs.Duplicates;

				if (!chkMoveDuplicates.Checked)
				{
					txtOutputDirectory.Enabled = false;
					btnOutputBrowse.Enabled = false;
				}
				
			}


		}

		private void EnableForm(bool enable)
		{
			txtSourceDirectory.Enabled = enable;
			txtOutputDirectory.Enabled = enable;
			btnSourceBrowse.Enabled = enable;
			btnOutputBrowse.Enabled = enable;
			tabContainer.Enabled = enable;
		}

		private void cmdCancel_MouseLeave(object sender, EventArgs e)
		{
			Cursor = Worker.IsBusy ? Cursors.WaitCursor : Cursors.Default;
		}

		private void cmdCancel_MouseHover(object sender, EventArgs e)
		{
			Cursor = Cursors.Default;
		}

		private void txtSourceDirectory_Leave(object sender, EventArgs e)
		{
			Settings.Source = txtSourceDirectory.Text;
			Settings.Save();
		}

		private void txtOutputDirectory_Leave(object sender, EventArgs e)
		{
			Settings.Destination = txtOutputDirectory.Text;
			Settings.Save();
		}

		private void chkAddDashesToDates_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AddDashesToDates = chkAddDashesToDates.Checked;
			Settings.Save();
		}

		private void chkOverwrite_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Overwrite = chkOverwrite.Checked;
			Settings.Save();
		}

		private void chkSortCopy_CheckedChanged(object sender, EventArgs e)
		{
			Settings.CopyWhenSorting = chkSortCopy.Checked;
			Settings.Save();
		}

		private void chkSkipExisting_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Skip = chkSkipExisting.Checked;
			Settings.Save();
		}

		private void chkUseYearMonthDir_CheckedChanged(object sender, EventArgs e)
		{
			Settings.UseMonthSubDirs = chkUseYearMonthDir.Checked;
			Settings.Save();
		}

		private void chkMoveDuplicates_CheckedChanged(object sender, EventArgs e)
		{
			Settings.MoveDuplicates = chkMoveDuplicates.Checked;
			Settings.Save();

			//disable destination directory unless move is specified
			if (chkMoveDuplicates.Checked)
			{
				txtOutputDirectory.Enabled = true;
				btnOutputBrowse.Enabled = true;
			}
			else
			{
				txtOutputDirectory.Enabled = false;
				btnOutputBrowse.Enabled = false;
			}

		}

		private void MainForm_Activated(object sender, EventArgs e)
		{
			//if (SelectedTabIndex == Convert.ToInt32(Tabs.Duplicates))
			//{
			//    //disable destination directory unless move is specified
			//    if (chkMoveDuplicates.Checked)
			//    {
			//        txtOutputDirectory.Enabled = true;
			//        btnOutputBrowse.Enabled = true;
			//    }
			//    else
			//    {
			//        txtOutputDirectory.Enabled = false;
			//        btnOutputBrowse.Enabled = false;
			//    }
			//}
		}

		#endregion Form Events

		#region Update file name example

		private void UpdateExample(bool useDir)
		{
			string exPrefix = txtPrefix.Text;
			if (useDir)
			{
				exPrefix = "<directory name>";
			}
			
			txtExample.Text = GetFileName(exPrefix, Settings.StartNumber, Convert.ToInt16(cboDigits.SelectedItem), Settings.PhotoExtension, chkNumberFirst.Checked);
		}
		#endregion

		#region Background worker events
		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			var settings = (Settings)e.Argument;

			if (SelectedTab == Tabs.Organize)
			{
				Organize(
					new DirectoryInfo(settings.Source),
					new DirectoryInfo(settings.Destination),
					settings.AddDashesToDates,
					settings.Overwrite,
					settings.Skip,
					settings.UseMonthSubDirs
					);
			}

			if (SelectedTab == Tabs.Sort)
			{
				SortIndividualPicturesByDate(
					new DirectoryInfo(settings.Source),
					new DirectoryInfo(settings.Destination),
					chkUseYearMonthDir.Checked, chkSortCopy.Checked);
			}

			if (SelectedTab == Tabs.Rename)
			{
				//Call copy operation
				CopyRecursiveWithRename(
					new DirectoryInfo(settings.Source),
					new DirectoryInfo(settings.Destination),
					settings.Prefix,
					settings.Digits,
					settings.UseDirName,
					settings.NumberFirst
					);

				//save the counter
				settings.StartNumber = Counter;
				Settings.Save(); //Must be capital case.  'settings' is a local variable
			}

			if (SelectedTab == Tabs.Resize)
			{
				//Call resize operation
				ResizeToSingleDir(
				new DirectoryInfo(settings.Source),
				new DirectoryInfo(settings.Destination)
				);
			}

			if (SelectedTab == Tabs.Duplicates)
			{
				//Call duplicates operation
				var results = FindDuplicates(
				new DirectoryInfo(settings.Source),
				new DirectoryInfo(settings.Destination), 
				settings.MoveDuplicates
				);

				Duplicates = results;

			}
		}

		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//update form with latest counter
			if (SelectedTab == Tabs.Rename)
			{
				txtStart.Text = Settings.StartNumber.ToString(CultureInfo.InvariantCulture);
			}

			//reset cursor
			Cursor = Cursors.Default;
			cmdCancel.Enabled = false;
			cmdRun.Enabled = true;
			statusProgress.Value = statusProgress.Maximum;
			EnableForm(true);

			if (SelectedTab == Tabs.Duplicates && Duplicates.Count > 0)
			{
				//Fill the grid with results
				foreach (var entry in Duplicates)
				{
					gridDuplicates.Rows.Add(entry.Key, entry.Value);
				}
			}	
			
			if (WorkerCancelled)
			{
				WorkerCancelled = true;
				statusLabel.Text = "Operation cancelled";
				MessageBox.Show("Operation cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				WorkerCancelled = false;
				statusLabel.Text = "Operation complete!";
				MessageBox.Show("Operation complete!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			statusProgress.Value = FilesProcessed;
			statusLabel.Text = FilesProcessed + "\\" + TotalFiles;
		}

		#endregion Background worker events

		#region Save Settings

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadSettings();
			UpdateExample(chkUseDir.Checked);
			cmdCancel.Enabled = false;
		}
		
		private void LoadSettings()
		{	
			Settings = Settings.Default;

			txtSourceDirectory.Text = Settings.Source;
			txtOutputDirectory.Text = Settings.Destination;
			txtPrefix.Text = Settings.Prefix;

			cboDigits.SelectedIndex = Settings.DigitsSelectedIndex;
			cboDigits.SelectedItem = Settings.Digits;
			
			chkUseDir.Checked = Settings.UseDirName;
			chkNumberFirst.Checked = Settings.NumberFirst;
			txtStart.Text = Settings.StartNumber.ToString(CultureInfo.InvariantCulture);


			chkOverwrite.Checked = Settings.Overwrite;
			chkSkipExisting.Checked = Settings.Skip;
			chkAddDashesToDates.Checked = Settings.AddDashesToDates;
			chkUseYearMonthDir.Checked = Settings.UseMonthSubDirs;

			chkSortCopy.Checked = Settings.CopyWhenSorting;
			chkMoveDuplicates.Checked = Settings.MoveDuplicates;

			tabContainer.SelectedIndex = Settings.SelectedTab;
			
			UpdateExample(chkUseDir.Checked);
		}

		private void cboDigits_SelectedIndexChanged(object sender, EventArgs e)
		{
			Settings.Digits = Convert.ToInt16(cboDigits.SelectedItem);
			Settings.DigitsSelectedIndex = cboDigits.SelectedIndex;
			Settings.Save();

			UpdateExample(chkUseDir.Checked);
		}

		private void chkNumberFirst_CheckedChanged(object sender, EventArgs e)
		{
			Settings.NumberFirst = chkNumberFirst.Checked;
			Settings.Save();

			UpdateExample(chkUseDir.Checked);
		}

		private void txtPrefix_TextChanged(object sender, EventArgs e)
		{
			Settings.Prefix = txtPrefix.Text;
			UpdateExample(chkUseDir.Checked);
		}

		private void chkUseDir_CheckedChanged(object sender, EventArgs e)
		{
			Settings.UseDirName = chkUseDir.Checked;
			Settings.Save();

			txtPrefix.Enabled = !chkUseDir.Checked;
			UpdateExample(chkUseDir.Checked);
		}		
		
		private void txtSourceDirectory_TextChanged(object sender, EventArgs e)
		{
			Settings.Source = txtSourceDirectory.Text;
			Settings.Save();

		}

		private void txtOutputDirectory_TextChanged(object sender, EventArgs e)
		{
			Settings.Destination = txtOutputDirectory.Text;
			Settings.Save();

		}

		private void txtStart_TextChanged(object sender, EventArgs e)
		{
			int start;
			if (!Int32.TryParse(txtStart.Text, out start))
			{
				start = 1;
			}
			Settings.StartNumber = start;
			Settings.Save();

			UpdateExample(chkUseDir.Checked);
		}

		private void txtLandscape_TextChanged(object sender, EventArgs e)
		{
			Settings.ConstraintLandscape = Convert.ToInt32(txtLandscape.Text);
			Settings.Save();
		}

		private void txtPortrait_TextChanged(object sender, EventArgs e)
		{
			Settings.ConstraintPortrait = Convert.ToInt32(txtPortrait.Text);
			Settings.Save();
		}

		private void txtRatio_TextChanged(object sender, EventArgs e)
		{
			Settings.ConstraintRatio = Convert.ToInt32(txtRatio.Text);
			Settings.Save();
		}

		#endregion Save Settings

		#region Browse controls
		private void btnSourceBrowse_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { SelectedPath = txtSourceDirectory.Text };
			dialog.ShowDialog();
			txtSourceDirectory.Text = dialog.SelectedPath;
			Settings.Source = txtSourceDirectory.Text;
			Settings.Save();
		}

		private void btnOutputBrowse_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { SelectedPath = txtOutputDirectory.Text };
			dialog.ShowDialog();
			txtOutputDirectory.Text = dialog.SelectedPath;
			Settings.Destination = txtOutputDirectory.Text;
			Settings.Save();
		}
		#endregion

		#region Resursive copy

		public void CopyRecursiveWithRename(DirectoryInfo source, DirectoryInfo dest, string prefix, int digits, bool useDirName, bool numberFirst)
		{
				if (Worker.CancellationPending)
				{
					Worker.CancelAsync();
					WorkerCancelled = true;
					return;
				}

				//create dest directory if it doesn't exist
				if (Directory.Exists(dest.FullName) == false)
				{
					Directory.CreateDirectory(dest.FullName);
				}

				//get list of files and sort
				var files = Sort(source.GetFiles("*.*"));

				//re-iterate through files
				foreach (FileInfo fi in files)
				{
					if (Worker.CancellationPending)
					{
						Worker.CancelAsync();
						WorkerCancelled = true;

						return;
					}

					//get new file name and copy to dest
					if (useDirName)
					{
						prefix = source.Name;
					}

					//only rename files that match the extension, but copy all files.  Be sure to compare lower-case to lower-case or copy will not happen
					string fileName;
					if (fi.Extension.ToLowerInvariant() == Settings.PhotoExtension.ToLowerInvariant())
					{
						fileName = GetFileName(prefix, Counter, digits, fi.Extension.ToLowerInvariant(), numberFirst);
						Counter++;					
					}
					else
					{ 
						fileName = fi.Name;					
					}

					fi.CopyTo(Path.Combine(dest.ToString(), fileName), true);

					//increment counter property
					FilesProcessed++;
					Worker.ReportProgress(FilesProcessed/TotalFiles);

				}

				//recursively copy each subdirectory
				foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
				{
					if (Worker.CancellationPending)
					{
						Worker.CancelAsync();
						WorkerCancelled = true;
						break;
					}

					DirectoryInfo nextTargetSubDir = dest.CreateSubdirectory(diSourceSubDir.Name);
					CopyRecursiveWithRename(diSourceSubDir, nextTargetSubDir, prefix, digits, useDirName, numberFirst);
				}

				WorkerCancelled = false;
			
		}

		public void ResizeToSingleDir(DirectoryInfo source, DirectoryInfo dest)
		{
			if (Worker.CancellationPending)
			{
				Worker.CancelAsync();
				WorkerCancelled = true;
				return;
			}

			//create dest directory if it doesn't exist
			if (Directory.Exists(dest.FullName) == false)
			{
				Directory.CreateDirectory(dest.FullName);
			}

			//get list of files and sort
			var files = Sort(source.GetFiles("*" + Settings.PhotoExtension));

			TotalFiles = files.Count;

			//re-iterate through files
			foreach (FileInfo fi in files)
			{
				try
				{
					//generate a new resized image based on the source file
					Image newImage = new ImageManipulation(fi.FullName).Resize(ConstraintType, Constraint);
					string destPath = Path.Combine(dest.ToString(), GetFileName(fi.Name.Replace(fi.Extension, string.Empty), ConstraintType, Constraint, Settings.PhotoExtension));
					//string destPath = Path.Combine(dest.ToString(), GetFileName(fi.Name.Replace(fi.Extension, string.Empty), ConstraintType, Constraint, newImage.Width, newImage.Height, Settings.PhotoExtension));

					//delete if file exists already
					var destFile = new FileInfo(destPath);
					if (destFile.Exists)
					{
						destFile.Delete();
					}

					//save original file as new file
					newImage.Save(destPath, ImageFormat.Jpeg);
					newImage.Dispose();
				}
				finally
				{
					MessageBox.Show("Encountered an error while processing \n" + fi.FullName);
				}
				//increment files processed
				FilesProcessed++;
				Worker.ReportProgress(FilesProcessed / TotalFiles);
			}

			//recursively copy each subdirectory
			foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
			{
				if (Worker.CancellationPending)
				{
					Worker.CancelAsync();
					WorkerCancelled = true;
					break;
				}

				ResizeToSingleDir(diSourceSubDir, dest);
			}

			WorkerCancelled = false;
		}

		public static string GetFileName(string prefix, int counter, int digits, string ext, bool numberFirst)
		{
			if (numberFirst)
			{
				return counter.ToString(CultureInfo.InvariantCulture).PadLeft(digits, '0') + "_" + prefix + ext;
			}
			
			return string.Format("{0}_{1}{2}", prefix, counter.ToString(CultureInfo.InvariantCulture).PadLeft(digits, '0'), ext);
		}

		public static string GetFileName(string filename, ConstraintTypes constraintType, int constraint, int x, int y, string ext)
		{
			//unused
			return filename + "_" + constraintType + "_" + constraint + "_" + x + "_" + y + ext;
		}

		public static string GetFileName(string filename, ConstraintTypes constraintType, int constraint, string ext)
		{
			return filename + "_" + constraintType + "_" + constraint + ext;
		}

		#region unused

		//public static void CopyRecursive(DirectoryInfo source, DirectoryInfo dest)
		//{
		//    // Check if the dest directory exists, if not, create it.
		//    if (Directory.Exists(dest.FullName) == false)
		//    {
		//        Directory.CreateDirectory(dest.FullName);
		//    }

		//    // Copy each file into it's new directory.
		//    foreach (FileInfo fi in source.GetFiles())
		//    {
		//        Console.WriteLine(@"Copying {0}\{1}", dest.FullName, fi.Name);
		//        fi.CopyTo(path.Combine(dest.ToString(), fi.Name), true);
		//    }

		//    // Copy each subdirectory using recursion.
		//    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		//    {
		//        DirectoryInfo nextTargetSubDir =
		//            dest.CreateSubdirectory(diSourceSubDir.Name);
		//        CopyRecursive(diSourceSubDir, nextTargetSubDir);
		//    }
		//}

		#endregion

		internal void CopyRecursive(DirectoryInfo source, DirectoryInfo dest)
		{
			//create dest directory if it doesn't exist
			if (!Directory.Exists(dest.FullName))
			{
				Directory.CreateDirectory(dest.FullName);
			}

			//get list of files and sort
			var files = Sort(source.GetFiles("*.*"));

			TotalFiles = files.Count;

			//re-iterate through files
			foreach (FileInfo fi in files)
			{

				if (Worker.CancellationPending)
				{
					Worker.CancelAsync();
					WorkerCancelled = true;

					return;
				}

				//get new file name and copy to dest
				//var fileName = GetFileName(prefix, Counter, digits, fi.Extension, numberFirst);
				fi.CopyTo(Path.Combine(dest.ToString(), fi.Name), true);

				//increment counter property
				FilesProcessed++;
				Worker.ReportProgress(FilesProcessed / TotalFiles);

			}

			//recursively copy each subdirectory
			foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
			{
				DirectoryInfo nextTargetSubDir = dest.CreateSubdirectory(diSourceSubDir.Name);
				CopyRecursive(diSourceSubDir, nextTargetSubDir);
			}

			WorkerCancelled = false;
		}

		internal static List<FileInfo> Sort(FileInfo[] fileList)
		{
			List<FileInfo> newList = fileList.ToList();
			newList.ToList().Sort((a, b) => String.CompareOrdinal(a.Name, b.Name));
			return newList;
		}

		internal void SortIndividualPicturesByDate(DirectoryInfo source, DirectoryInfo dest, bool useYearMonthDir, bool copy)
		{
			//move files based on their file date
			var files = source.GetFiles("*", SearchOption.TopDirectoryOnly);
			foreach (var file in files)
			{
				if (Worker.CancellationPending)
				{
					Worker.CancelAsync();
					WorkerCancelled = true;

					return;
				}

				var fileDate = DateFunctions.GetReferenceDate(file);

				if (fileDate != DateTime.MinValue)
				{
					var path = String.Format(useYearMonthDir ? "{0}\\{1:yyyy}\\{1:yyyy-MM}" : "{0}\\{1:yyyy}", dest.FullName, fileDate);

					var pathWithName = Path.Combine(path, file.Name);

					var fiExist = new FileInfo(pathWithName);
					var di = new DirectoryInfo(path);

					//never overwrite
					if (!fiExist.Exists)
					{
						if (!di.Exists)
						{
							di.Create();
						}

						if (copy)
						{
							file.CopyTo(pathWithName, false);
						}
						else
						{
							file.MoveTo(pathWithName);
						}

					}
				}
			}

			WorkerCancelled = false;
		}

		internal void Organize(DirectoryInfo source, DirectoryInfo dest, bool addDashesToDates, bool overwrite, bool skip, bool useMonthSubDirs)
		{
            string newDirName = string.Empty;
			string sourceDirName = string.Empty;
			string dirNewName = string.Empty;

			//create destination if it doesn't exist
			if (!dest.Exists)
			{
				dest.Create();
			}

			//find instances of yyyymmdd and switch them to yyyy-mm-dd.  THIS UPDATES THE SOURCE DIRECTORY, NOT THE DESTINATION
			if (addDashesToDates)
			{
				var allDirs = source.GetDirectories("*", SearchOption.AllDirectories);
				foreach (var subDir in allDirs)
				{
					if (Worker.CancellationPending)
					{
						Worker.CancelAsync();
						WorkerCancelled = true;

						return;
					}

					string newName = RegularExpressions.AddDashesToDateInDirName(subDir.Name);
					var di = new DirectoryInfo(Path.Combine(subDir.Parent.FullName, newName));

					if (di.FullName != subDir.FullName)
					{
						subDir.MoveTo(di.FullName);
					}
				}

			}

			var counter = source.GetFiles("*.*", SearchOption.AllDirectories);
			TotalFiles = counter.Count();

			//get year directories
			var yearDirs = source.GetDirectories("*", SearchOption.TopDirectoryOnly);
			foreach (var yearDir in yearDirs)
			{

				if (Worker.CancellationPending)
				{
					Worker.CancelAsync();
					WorkerCancelled = true;

					return;
				}

				var yearInt = 0;
				var monthInt = 0;

				//get year from directory name
				var year = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(yearDir.Name));

				bool nonYearDir;
				if (year != DateTime.MinValue)
				{
					yearInt = year.Year;
					nonYearDir = false;
				}
				else
				{
					nonYearDir = true;
					string sourcDir = Path.Combine(source.FullName, yearDir.Name);
					string destDir = Path.Combine(dest.FullName, yearDir.Name);
					var diSource = new DirectoryInfo(sourcDir);
					var diDest = new DirectoryInfo(destDir);

					//copy everything to destination directory
					CopyRecursive(diSource, diDest);
					//break;
				}

				//get month-level directories
				var monthDirs = yearDir.GetDirectories("*", SearchOption.TopDirectoryOnly);
				foreach (var monthDir in monthDirs)
				{

					if (Worker.CancellationPending)
					{
						Worker.CancelAsync();
						WorkerCancelled = true;

						return;
					}

					string monthDirDesc = RegularExpressions.AddDashesToDateInDirName(monthDir.Name);

					//determine the month
					var month = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(monthDirDesc));
					if (month != DateTime.MinValue)
					{
						monthInt = month.Month;
					}

					if (monthInt > 0)
					{
						//dest
						var combinedDate = new DateTime(yearInt, monthInt, 1);  //exception when a year folder only has text

						if (useMonthSubDirs)
						{
							dirNewName = String.Format("{0:yyyy-MM}", combinedDate);
							newDirName = Path.Combine(dest.FullName, yearInt.ToString(CultureInfo.InvariantCulture));
							newDirName = Path.Combine(newDirName, dirNewName);

							if (monthDirDesc == monthDir.Name)
							{
								if (!RegularExpressions.CheckIfYearMonthFormatOnly(monthDir.Name))
								{
									newDirName = Path.Combine(newDirName, monthDirDesc);
								}
							}
						}
						else //THIS SECTION WORKS
						{
							dirNewName = !RegularExpressions.CheckIfYearMonthFormatOnly(monthDir.Name) ? monthDir.Name : string.Empty;

							newDirName = Path.Combine(dest.FullName, yearInt.ToString(CultureInfo.InvariantCulture));
							newDirName = Path.Combine(newDirName, dirNewName);

						}

						//source
						sourceDirName = Path.Combine(source.FullName, yearDir.Name);
						sourceDirName = Path.Combine(sourceDirName, monthDir.Name);
					}
					else
					{
						//source
						sourceDirName = monthDir.FullName;
						newDirName = Path.Combine(dest.FullName, yearDir.Name);
						newDirName = Path.Combine(newDirName, monthDir.Name);
					}

					//create directory info's
					var diDestName = new DirectoryInfo(newDirName);
					var diSourceName = new DirectoryInfo(sourceDirName);

					CopyTo(diSourceName, diDestName, overwrite, skip);

					//increment counter property
					FilesProcessed++;
					Worker.ReportProgress(FilesProcessed / TotalFiles);

				}
				if (!nonYearDir)
				{
					//get any files in the year directory
					var yearFiles = yearDir.GetFiles();
					//copy files from year directory into sub
					foreach (var yearFile in yearFiles)
					{
						string yearMonthPath = Path.Combine(yearDir.Name,
						String.Format("{0:yyyy-MM}", DateFunctions.GetReferenceDate(yearFile)));
						yearMonthPath = Path.Combine(dest.FullName, yearMonthPath);
						var diNew = new DirectoryInfo(yearMonthPath);
						if (!diNew.Exists)
						{
							diNew.Create();
						}
						var fileName = Path.Combine(yearMonthPath, yearFile.Name);
						yearFile.CopyTo(fileName, true);

						//increment counter property
						FilesProcessed++;
						Worker.ReportProgress(FilesProcessed / TotalFiles);
					}
				}

			}

			WorkerCancelled = false;
		}

		public static void CopyTo(DirectoryInfo source, DirectoryInfo target, bool overwrite, bool skip)
		{
			// Check if the target directory exists, if not, create it.
			if (!Directory.Exists(target.FullName))
			{
				Directory.CreateDirectory(target.FullName);
			}

			// Copy each file into it's new directory.
			foreach (FileInfo fi in source.GetFiles())
			{
				//Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
				//check if destination file exists
				string path = Path.Combine(target.ToString(), fi.Name);

				//check for existing file
				var existingFi = new FileInfo(path);
				if (existingFi.Exists)
				{
					if (!skip)
					{
						if (!overwrite)
						{
							path = Path.Combine(target.ToString(), AddTimestamp(fi));
						}

						fi.CopyTo(path, overwrite);
					}
				}
				else
				{
					fi.CopyTo(path, true);
				}
			}

			// Copy each subdirectory using recursion.
			foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
			{
				DirectoryInfo nextTargetSubDir =
					target.CreateSubdirectory(diSourceSubDir.Name);
				CopyTo(diSourceSubDir, nextTargetSubDir, overwrite, skip);
			}
		}

		public static string AddTimestamp(FileInfo fileInfo)
		{
			string extension = fileInfo.Extension;
			string name = fileInfo.Name;
			name = name.Remove(name.LastIndexOf(".", StringComparison.Ordinal));
			name = name + "_Duplicate_" + String.Format("{0:yyyy.dd.MM.H.mm.ss.ffffff}", DateTime.Now);
			name = name + extension;
			return name;
		}

		internal List<Result> FindDuplicates(DirectoryInfo source, DirectoryInfo destination, bool moveDuplicates)
		{
			var resultDict = new List<Result>();
			//var dirList = source.GetDirectories("*", SearchOption.AllDirectories);

			var fileList = new List<FileInfo>();
			var compareList = new List<FileInfo>();

			var counter = source.GetFiles("*.*", SearchOption.AllDirectories);
			TotalFiles = counter.Count();

			//add root level files first
			fileList.AddRange(source.GetFiles("*.*", SearchOption.AllDirectories));
			compareList.AddRange(source.GetFiles("*.*", SearchOption.AllDirectories));

			if (!destination.Exists)
			{
				destination.Create();
			}

			foreach (var file in fileList)
			{
				if (Worker.CancellationPending)
				{
					Worker.CancelAsync();
					WorkerCancelled = true;
					
					var result = new Result("Operation cancelled.", string.Empty);
					resultDict.Add(result);
					return resultDict;
				}

				foreach (var compare in compareList)
				{
					var fileFi = new FileInfo(file.FullName);
					var compareFi = new FileInfo(compare.FullName);

					if (fileFi.Exists && compareFi.Exists && file.FullName != compare.FullName)
					{
						//check if exists first before trying to compare or the filestream in FilesAreEqual will throw an exception
						if (FilesAreEqual(file, compare))
						{
							var kvp = new Result(file.FullName, compare.FullName);
							var kvp2 = new Result(compare.FullName, file.FullName);

							if (!resultDict.Contains(kvp) && !resultDict.Contains(kvp2))
							{
								resultDict.Add(kvp);

								//resultDict.Add(file.FullName, compare.FullName);
								//var newFileName = String.Format("{0}-{1}", file.Name, compare.Name);

								//determine the sub path
								var destFile = new FileInfo(compare.FullName.Replace(source.FullName, destination.FullName));
								var destPath = new DirectoryInfo(Path.GetDirectoryName(destFile.FullName));

								if (moveDuplicates)
								{
									if (!destPath.Exists)
									{
										destPath.Create();
									}

									if (destFile.Exists)
									{
										destFile.Delete();
									}

									compare.MoveTo(destFile.FullName);
								}
							}
						}
					}
				}

				//increment counter property
				FilesProcessed++;
				Worker.ReportProgress(FilesProcessed / TotalFiles);
			}

			WorkerCancelled = false;
			return resultDict;
		}

		static bool FilesAreEqual(FileInfo first, FileInfo second)
		{

			if (first.Length != second.Length)
				return false;

			int iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

			using (FileStream fs1 = first.OpenRead())
			using (FileStream fs2 = second.OpenRead())
			{
				byte[] one = new byte[BYTES_TO_READ];
				byte[] two = new byte[BYTES_TO_READ];

				for (int i = 0; i < iterations; i++)
				{
					fs1.Read(one, 0, BYTES_TO_READ);
					fs2.Read(two, 0, BYTES_TO_READ);

					if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
						return false;
				}
			}

			return true;
		}
		#endregion Recursive copy

		#region Sorting
		//public static List<FileInfo> Sort(FileInfo[] fileList)
		//{
		//    List<FileInfo> newList = fileList.ToList();
		//    newList.ToList().Sort((a, b) => String.CompareOrdinal(a.Name, b.Name));
		//    return newList;
		//}

		public static List<DirectoryInfo> Sort(DirectoryInfo[] dirList)
		{
			List<DirectoryInfo> newList = dirList.ToList();
			newList.ToList().Sort((a, b) => String.CompareOrdinal(a.Name, b.Name));
			return newList;
		}
		#endregion

		#region Properties

		internal static Settings Settings { get; set; }
		public static int Counter { get; set; }
		public static int FilesProcessed { get; set; }
		public static int TotalFiles { get; set; }
		private static bool WorkerCancelled { get; set; }
		private static Tabs SelectedTab { get; set; }
		private static int SelectedTabIndex { get; set; }
		public static ConstraintTypes ConstraintType { get; set; }
		public static int Constraint { get; set; }
		public List<Result> Duplicates { get; set; }
        
		#endregion Properties

        private void cmdChangeDate(object sender, EventArgs e)
        {

            var source = new DirectoryInfo(Settings.Default.Source);
            var date = new DateTime(datePickerChangeDate.Value.Year, datePickerChangeDate.Value.Month, datePickerChangeDate.Value.Day);
            
            var confirm = MessageBox.Show(String.Format("Change create date on all files in '{0}' to '{1:MM/dd/yyyy}'?", source, date), "Change Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirm == DialogResult.Yes)
            { 
                ChangeDate(source, date);
            }
   
        }
        
        public void ChangeDate(DirectoryInfo source, DateTime setDateTime)
        {
            var files = source.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                file.LastWriteTime = setDateTime;
                file.CreationTime = setDateTime;
                file.LastAccessTime = setDateTime;
            }

            MessageBox.Show("Operation Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

	}

}
