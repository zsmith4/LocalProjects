using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace FileOrganizer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { SelectedPath = txtSourceDirectory.Text };
			dialog.ShowDialog();
			txtSourceDirectory.Text = dialog.SelectedPath;
		}

		private void outputBrowse_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { SelectedPath = txtOutputDirectory.Text };
			dialog.ShowDialog();
			txtOutputDirectory.Text = dialog.SelectedPath;

		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			btnRun.Text = "Running...";
			btnRun.Enabled = false;
			var source = new DirectoryInfo(txtSourceDirectory.Text);
			var dest = new DirectoryInfo(txtOutputDirectory.Text);
			string newDirName = string.Empty;
			string sourceDirName = string.Empty;
			string dirNewName = string.Empty;

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
				}
				else
				{
					string sourcDir = Path.Combine(source.FullName, yearDir.Name);
					string destDir = Path.Combine(dest.FullName, yearDir.Name);
					var diSource = new DirectoryInfo(sourcDir);
					var diDest = new DirectoryInfo(destDir);

					//copy everything to destination directory
					CopyRecursive(diSource, diDest);
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

					Console.WriteLine();
					Utilities.CopyTo(diSourceName, diDestName, chkDestination.Checked, chkSkipExisting.Checked);

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
			string pattern = @"(?<year>\d{4})(?<month>\d{2})(?<day>\d{2})(?<remain>\b.*)";
			string replacement = "${year}-${month}-${day}${remain}";

			//perform replacement
			Regex regEx = new Regex(pattern);
			string result = regEx.Replace(dirName, replacement);

			if (!String.IsNullOrEmpty(result))
			{
				return result;
			}

			return dirName;
		}

		public static bool CheckIfYearMonthFormatOnly(string dirName)
		{
			string pattern = @"(?<year>\d{4})-(?<month>\d{2})(?<remain>\b.*)";
			string replacement = "${remain}";

			//perform replacement
			Regex regEx = new Regex(pattern);
			string result = regEx.Replace(dirName, replacement);

			if (String.IsNullOrEmpty(result))
			{
				return true;
			}

			return false;
		}

		protected static void CopyToNewDir(DateTime dirDate, DirectoryInfo dest, DirectoryInfo source, bool overwrite, bool skip)
		{
			dirDate.ToString("D", CultureInfo.CreateSpecificCulture("en-US"));

			var dirNewName = DateFunctions.GetNewFullDirPath(dest, dirDate, source.Name);

			var diNewName = new DirectoryInfo(dirNewName);
			Utilities.CopyTo(source, diNewName, overwrite, skip);

		}

		public void CopyRecursive(DirectoryInfo source, DirectoryInfo dest)
		{
			//create dest directory if it doesn't exist
			if (!Directory.Exists(dest.FullName))
			{
				Directory.CreateDirectory(dest.FullName);
			}

			//get list of files and sort
			var files = Sort(source.GetFiles("*.*"));

			//re-iterate through files
			foreach (FileInfo fi in files)
			{
				//get new file name and copy to dest
				//var fileName = GetFileName(prefix, Counter, digits, fi.Extension, numberFirst);
				fi.CopyTo(Path.Combine(dest.ToString(), fi.Name), true);
			}

			//recursively copy each subdirectory
			foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
			{
				DirectoryInfo nextTargetSubDir = dest.CreateSubdirectory(diSourceSubDir.Name);
				CopyRecursive(diSourceSubDir, nextTargetSubDir);
			}
		}


		public static List<FileInfo> Sort(FileInfo[] fileList)
		{
			List<FileInfo> newList = fileList.ToList();
			newList.ToList().Sort((a, b) => String.Compare(a.Name, b.Name));
			return newList;
		}

		private void SortIndividualPicturesByDate(DirectoryInfo source, DirectoryInfo dest, bool overwrite, bool skip)
		{
			string path = string.Empty;
			string pathWithName = string.Empty;
			string yr = string.Empty;

			//move files based on their file date
			var files = source.GetFiles("*", SearchOption.TopDirectoryOnly);
			foreach (var file in files)
			{
				var fileDate = DateFunctions.GetReferenceDate(file);

				if (fileDate != DateTime.MinValue)
				{
					if (chkUseYearMonthDir.Checked)
					{
						path = String.Format("{0}\\{1:yyyy}\\{1:yyyy-MM}",
							dest.FullName,
							fileDate);
					}
					else
					{
						path = String.Format("{0}\\{1:yyyy}",
							dest.FullName,
							fileDate);
					}

					pathWithName = Path.Combine(path, file.Name);
					
					var fiExist = new FileInfo(pathWithName);
					var di = new DirectoryInfo(path);

					//never overwrite
					if (!fiExist.Exists)
					{
						if (!di.Exists)
						{
							di.Create();
						}

						if (chkSortCopy.Checked)
						{
							file.CopyTo(pathWithName, false);
						}
						else
						{ 
							file.MoveTo(pathWithName);
						}

					}

					//else
					//{
					//    if (!skip)
					//    {
					//        if (!di.Exists)
					//        {
					//            di.Create();
					//        }

					//        if (overwrite)
					//        {
					//            file.MoveTo(pathWithName);
					//        }

					//    }
					//}
				}
			}
		}

		private void btnSortIndividual_Click(object sender, EventArgs e)
		{
			btnRun.Text = "Running...";
			btnRun.Enabled = false;
			var source = new DirectoryInfo(txtSourceDirectory.Text);
			var dest = new DirectoryInfo(txtOutputDirectory.Text);

			//sort individual files
			SortIndividualPicturesByDate(source, dest, chkDestination.Checked, chkSkipExisting.Checked);

			btnRun.Enabled = true;
			btnRun.Text = "Go";

			//show complete
			MessageBox.Show("Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}
	}
}
