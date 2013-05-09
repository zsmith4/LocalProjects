using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using FileUtilities.Properties;
using FileUtilities;

namespace FileOrganizer
{
	public partial class MainFormFileOrganizer : Form
	{
		public MainFormFileOrganizer()
		{
			InitializeComponent();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { SelectedPath = txtSourceDirectory.Text };
			dialog.ShowDialog();
			txtSourceDirectory.Text = dialog.SelectedPath;
			Settings.Default.Source = txtSourceDirectory.Text;
			Settings.Default.Save();

		}

		private void outputBrowse_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { SelectedPath = txtOutputDirectory.Text };
			dialog.ShowDialog();
			txtOutputDirectory.Text = dialog.SelectedPath;
			Settings.Default.Destination = txtOutputDirectory.Text;
			Settings.Default.Save();
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			//settings
			Settings.Default.Overwrite = chkDestination.Checked;
			Settings.Default.Skip = chkSkipExisting.Checked;
			Settings.Default.AddDashesToDates = chkAddDashesToDates.Checked;
			Settings.Default.UseMonthSubDirs = chkUseYearMonthDir.Checked;
			Settings.Default.CopyFilesInSort = chkSortCopy.Checked;
			Settings.Default.Save();

			btnRun.Text = "Running...";
			btnRun.Enabled = false;
			var source = new DirectoryInfo(txtSourceDirectory.Text);
			var dest = new DirectoryInfo(txtOutputDirectory.Text);
			string newDirName = string.Empty;
			string SourceName = string.Empty;
			string dirNewName = string.Empty;
			bool nonYearDir;

			//create destination if it doesn't exist
			if (!dest.Exists)
			{
				dest.Create();
			}


			//find instances of yyyymmdd and switch them to yyyy-mm-dd.  THIS UPDATES THE SOURCE DIRECTORY, NOT THE DESTINATION
			if (chkAddDashesToDates.Checked)
			{
				var allDirs = source.GetDirectories("*", SearchOption.AllDirectories);
				foreach (var subDir in allDirs)
				{
					string newName = AddDashesToDateInDirName(subDir.Name);
					var di = new DirectoryInfo(Path.Combine(subDir.Parent.FullName, newName));

					if (di.FullName != subDir.FullName)
					{
						subDir.MoveTo(di.FullName);
					}
				}

			}

			//get year directories
			var yearDirs = source.GetDirectories("*", SearchOption.TopDirectoryOnly);
			foreach (var yearDir in yearDirs)
			{
				var yearInt = 0;
				var monthInt = 0;

				//get year from directory name
				var year = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(yearDir.Name));

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
					string monthDirDesc = AddDashesToDateInDirName(monthDir.Name);

					//determine the month
					var month = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(monthDirDesc));
					if (month != DateTime.MinValue)
					{
						monthInt = month.Month;
					}

					if (monthInt > 0)
					{
						//dest
						DateTime combinedDate = new DateTime(yearInt, monthInt, 1);  //exception when a year folder only has text

						if (chkUseYearMonthDir.Checked)
						{
							dirNewName = String.Format("{0:yyyy-MM}", combinedDate);
							newDirName = Path.Combine(dest.FullName, yearInt.ToString());
							newDirName = Path.Combine(newDirName, dirNewName);

							if (monthDirDesc == monthDir.Name)
							{
								if (!CheckIfYearMonthFormatOnly(monthDir.Name))
								{
									newDirName = Path.Combine(newDirName, monthDirDesc);
								}
							}
						}
						else //THIS SECTION WORKS
						{
							if (!CheckIfYearMonthFormatOnly(monthDir.Name))
							{
								dirNewName = monthDir.Name;
							}
							else
							{
								dirNewName = string.Empty;
							}

							newDirName = Path.Combine(dest.FullName, yearInt.ToString());
							newDirName = Path.Combine(newDirName, dirNewName);

						}

						//source
						SourceName = Path.Combine(source.FullName, yearDir.Name);
						SourceName = Path.Combine(SourceName, monthDir.Name);
					}
					else
					{
						//source
						SourceName = monthDir.FullName;
						newDirName = Path.Combine(dest.FullName, yearDir.Name);
						newDirName = Path.Combine(newDirName, monthDir.Name);
					}

					//create directory info's
					var diDestName = new DirectoryInfo(newDirName);
					var diSourceName = new DirectoryInfo(SourceName);

					Console.WriteLine();
					Utilities.CopyTo(diSourceName, diDestName, chkDestination.Checked, chkSkipExisting.Checked);




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
					}
				}

			}

			btnRun.Enabled = true;
			btnRun.Text = "Go";

			//show complete
			MessageBox.Show("Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		public static string AddDashesToDateInDirName(string dirName)
		{
			//define pattern and replacement
			const string pattern = @"(?<year>\d{4})(?<month>\d{2})(?<day>\d{2})(?<remain>\b.*)";
			const string replacement = "${year}-${month}-${day}${remain}";

			//perform replacement
			var regEx = new Regex(pattern);
			string result = regEx.Replace(dirName, replacement);

			if (!String.IsNullOrEmpty(result))
			{
				return result;
			}

			return dirName;
		}

		public static bool CheckIfYearMonthFormatOnly(string dirName)
		{
			const string pattern = @"(?<year>\d{4})-(?<month>\d{2})(?<remain>\b.*)";
			const string replacement = "${remain}";

			//perform replacement
			var regEx = new Regex(pattern);
			string result = regEx.Replace(dirName, replacement);

			if (String.IsNullOrEmpty(result))
			{
				return true;
			}

			return false;
		}

		protected static void CopyToNewDir(DateTime dirDate, DirectoryInfo dest, DirectoryInfo source, bool overwrite, bool skip)
		{
//			dirDate.ToString("D", CultureInfo.CreateSpecificCulture("en-US"));

			var dirNewName = DateFunctions.GetNewFullDirPath(dest, dirDate, source.Name);

			var diNewName = new DirectoryInfo(dirNewName);
			Utilities.CopyTo(source, diNewName, overwrite, skip);

		}

		//public void CopyRecursive(DirectoryInfo source, DirectoryInfo dest)
		//{
		//    //create dest directory if it doesn't exist
		//    if (!Directory.Exists(dest.FullName))
		//    {
		//        Directory.CreateDirectory(dest.FullName);
		//    }

		//    //get list of files and sort
		//    var files = Sort(source.GetFiles("*.*"));

		//    //re-iterate through files
		//    foreach (FileInfo fi in files)
		//    {
		//        //get new file name and copy to dest
		//        //var fileName = GetFileName(prefix, Counter, digits, fi.Extension, numberFirst);
		//        fi.CopyTo(Path.Combine(dest.ToString(), fi.Name), true);
		//    }

		//    //recursively copy each subdirectory
		//    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		//    {
		//        DirectoryInfo nextTargetSubDir = dest.CreateSubdirectory(diSourceSubDir.Name);
		//        CopyRecursive(diSourceSubDir, nextTargetSubDir);
		//    }
		//}

		//public static List<FileInfo> Sort(FileInfo[] fileList)
		//{
		//    List<FileInfo> newList = fileList.ToList();
		//    newList.ToList().Sort((a, b) => String.CompareOrdinal(a.Name, b.Name));
		//    return newList;
		//}



		private void btnSortIndividual_Click(object sender, EventArgs e)
		{
			btnRun.Text = "Running...";
			btnRun.Enabled = false;
			var source = new DirectoryInfo(txtSourceDirectory.Text);
			var dest = new DirectoryInfo(txtOutputDirectory.Text);

			//sort individual files
			FileUtilities.SortIndividualPicturesByDate(source, dest);

			btnRun.Enabled = true;
			btnRun.Text = "Go";

			//show complete
			MessageBox.Show("Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			txtSourceDirectory.Text = Settings.Default.Source;
			txtOutputDirectory.Text = Settings.Default.Destination;

			//settings
			chkDestination.Checked = Settings.Default.Overwrite;
			chkSkipExisting.Checked = Settings.Default.Skip;
			chkAddDashesToDates.Checked = Settings.Default.AddDashesToDates;
			chkUseYearMonthDir.Checked = Settings.Default.UseMonthSubDirs;
			chkSortCopy.Checked = Settings.Default.CopyFilesInSort;
			Settings.Default.Save();
		}

		private void txtSourceDirectory_Leave(object sender, EventArgs e)
		{
			Settings.Default.Source = txtSourceDirectory.Text;
			Settings.Default.Save();
		}

		private void txtOutputDirectory_Leave(object sender, EventArgs e)
		{
			Settings.Default.Destination = txtOutputDirectory.Text;
			Settings.Default.Save();

		}

		private void chkDestination_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.Overwrite = chkDestination.Checked;
			Settings.Default.Save();
		}

		private void chkSkipExisting_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.Skip = chkSkipExisting.Checked;
			Settings.Default.Save();
		}

		private void chkAddDashesToDates_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.AddDashesToDates = chkAddDashesToDates.Checked;
			Settings.Default.Save();

		}

		private void chkUseYearMonthDir_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.UseMonthSubDirs = chkUseYearMonthDir.Checked;
			Settings.Default.Save();
		}

		private void chkSortCopy_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.CopyFilesInSort = chkSortCopy.Checked;
			Settings.Default.Save();
		}
               
	}
}
