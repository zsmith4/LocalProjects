using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CopyRename
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public enum Tabs { Copy = 0, Resize = 1};
		public enum ConstraintTypes{Landscape = 0, Portrait = 1, Ratio = 2};

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
			TotalFiles = new DirectoryInfo(Settings.SourceDir).GetFiles("*" + Settings.Ext, SearchOption.AllDirectories).Count();
			statusProgress.Step = 1;
			statusProgress.Maximum = TotalFiles;
			statusProgress.Minimum = 0;

			Refresh();
			
			if (SelectedTab == Tabs.Copy)
			{
				statusLabel.Text = "Copying...";

				//set the Counter property of CopyOperations to the latest counter
				Counter = Settings.StartNumber;
				Worker.RunWorkerAsync();
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
                Worker.RunWorkerAsync();
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
			if (tabContainer.SelectedIndex == 1)
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
			}
			else
			{
				SelectedTab = Tabs.Copy;
			}

			txtLandscape.Text = Settings.ConstraintLandscape.ToString();
			txtPortrait.Text = Settings.ConstraintPortrait.ToString();
			txtRatio.Text = Settings.ConstraintRatio.ToString();

		}

		private void cmdCancel_MouseHover(object sender, EventArgs e)
		{
			Cursor = Cursors.Default;
		}

		private void EnableForm(bool enable)
		{
			txtSourceDirectory.Enabled = enable;
			txtOutputDirectory.Enabled = enable;
			btnSourceBrowse.Enabled = enable;
			btnOutputBrowse.Enabled = enable;
			tabContainer.Enabled = enable;
		}

		#endregion Form Events

		#region Update file name example

		private void UpdateExample(bool useDir)
		{
			string exPrefix = txtPrefix.Text;
			if (chkUseDir.Checked)
			{
				exPrefix = "<directory name>";
			}
			
			txtExample.Text = GetFileName(exPrefix, Settings.StartNumber, Convert.ToInt16(cboDigits.SelectedItem), Settings.Ext, chkNumberFirst.Checked);
		}
		#endregion

		#region Save Settings

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadSettings();
			UpdateExample(chkUseDir.Checked);
			cmdCancel.Enabled = false;
		}
		
		private void LoadSettings()
		{	
			Settings = Properties.Settings.Default;

			txtSourceDirectory.Text = Settings.SourceDir;
			txtOutputDirectory.Text = Settings.DestDir;
			txtPrefix.Text = Settings.Prefix;

			cboDigits.SelectedIndex = Settings.DigitsSelectedIndex;
			cboDigits.SelectedItem = Settings.Digits;
			
			chkUseDir.Checked = Settings.UseDirName;
			chkNumberFirst.Checked = Settings.NumberFirst;
			txtStart.Text = Settings.StartNumber.ToString();

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
			Settings.SourceDir = txtSourceDirectory.Text;
			Settings.Save();

		}

		private void txtOutputDirectory_TextChanged(object sender, EventArgs e)
		{
			Settings.DestDir = txtOutputDirectory.Text;
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
		}

		private void btnOutputBrowse_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { SelectedPath = txtOutputDirectory.Text };
			dialog.ShowDialog();
			txtOutputDirectory.Text = dialog.SelectedPath;
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
				var files = Sort(source.GetFiles("*" + Settings.Ext));

				//re-iterate through files
				foreach (FileInfo fi in files)
				{
					//get new file name and copy to dest
					if (useDirName)
					{
						prefix = source.Name;
					}
					var fileName = GetFileName(prefix, Counter, digits, fi.Extension, numberFirst);
					fi.CopyTo(Path.Combine(dest.ToString(), fileName), true);

					//increment counter property
					Counter++;
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
			var files = Sort(source.GetFiles("*" + Settings.Ext));

			//re-iterate through files
			foreach (FileInfo fi in files)
			{
				//generate a new resized image based on the source file
				Image newImage = new ImageManipulation(fi.FullName).Resize(ConstraintType, Constraint);
				string destPath = Path.Combine(dest.ToString(), GetFileName(fi.Name.Replace(fi.Extension, string.Empty), ConstraintType, Constraint, Settings.Ext));
				//string destPath = Path.Combine(dest.ToString(), GetFileName(fi.Name.Replace(fi.Extension, string.Empty), ConstraintType, Constraint, newImage.Width, newImage.Height, Settings.Ext));

				//delete if file exists already
				var destFile = new FileInfo(destPath);
				if (destFile.Exists)
				{
					destFile.Delete();
				}

				//save original file as new file
				newImage.Save(destPath, ImageFormat.Jpeg);
				newImage.Dispose();

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
		}

		public static string GetFileName(string prefix, int counter, int digits, string ext, bool numberFirst)
		{
			if (numberFirst)
			{
				return counter.ToString().PadLeft(digits, '0') + "_" + prefix + ext;
			}
			
			return prefix + "_" + counter.ToString().PadLeft(digits, '0') + ext;
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

		#endregion Recursive copy

		#region Background worker events
		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			if (SelectedTab == Tabs.Copy)
			{
				//Call copy operation
				CopyRecursiveWithRename(
					new DirectoryInfo(Settings.SourceDir),
					new DirectoryInfo(Settings.DestDir),
					Settings.Prefix,
					Settings.Digits,
					Settings.UseDirName,
					Settings.NumberFirst
					);

				//save the counter
				Settings.StartNumber = Counter;
				Settings.Save();
			}

			if (SelectedTab == Tabs.Resize)
			{
				//Call resize operation
				ResizeToSingleDir(
				new DirectoryInfo(Settings.SourceDir),
				new DirectoryInfo(Settings.DestDir)
				);
			}
		}
        
		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//update form with latest counter
			if (SelectedTab == Tabs.Copy)
			{
				txtStart.Text = Settings.StartNumber.ToString();
			}

			//reset cursor
			Cursor = Cursors.Default;
			cmdCancel.Enabled = false;
			cmdRun.Enabled = true;
			statusProgress.Value = statusProgress.Maximum;
			EnableForm(true);

			if (WorkerCancelled)
			{
			    statusLabel.Text = "Operation cancelled";
				MessageBox.Show("Operation cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
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

		#region Sorting
		public static List<FileInfo> Sort(FileInfo[] fileList)
		{
			List<FileInfo> newList = fileList.ToList();
			newList.ToList().Sort((a, b) => String.Compare(a.Name, b.Name));
			return newList;
		}

		public static List<DirectoryInfo> Sort(DirectoryInfo[] dirList)
		{
			List<DirectoryInfo> newList = dirList.ToList();
			newList.ToList().Sort((a, b) => String.Compare(a.Name, b.Name));
			return newList;
		}
		#endregion

		#region Properties

		internal static Properties.Settings Settings { get; set; }
		public static int Counter { get; set; }
		public static int FilesProcessed { get; set; }
		public static int TotalFiles { get; set; }
		private static bool WorkerCancelled { get; set; }
		private static Tabs SelectedTab { get; set; }
		public static ConstraintTypes ConstraintType { get; set; }
		public static int Constraint { get; set; }
        
		#endregion Properties

		private void cmdCancel_MouseLeave(object sender, EventArgs e)
		{
			if (Worker.IsBusy)
			{
				Cursor = Cursors.WaitCursor;
			}
			else
			{
				Cursor = Cursors.Default;
			}
		}

	}
}
