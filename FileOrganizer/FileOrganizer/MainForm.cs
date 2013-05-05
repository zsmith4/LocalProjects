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
		protected bool _overwrite = false;
		protected bool _skip = true;

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
			_overwrite = this.chkDestination.Checked;
			var source = new DirectoryInfo(txtSourceDirectory.Text);
			var dest = new DirectoryInfo(txtOutputDirectory.Text);
			_skip = chkSkipExisting.Checked;

			//create destination if it doesn't exist
			if (!dest.Exists)
			{
				dest.Create();
			}

			//******

			//rename all source directories
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


			//get year directories
			var yearDirs = source.GetDirectories("*", SearchOption.TopDirectoryOnly);
			foreach (var yearDir in yearDirs)
			{
				var yearInt = 1901;
				var monthInt = 0;
				
				//get year from directory name
				var year = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(yearDir.Name));
				
				if (year != DateTime.MinValue)
				{
					yearInt = year.Year;
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

					//dest
					DateTime combinedDate = new DateTime(yearInt,monthInt,1);
					string dirNewName = String.Format("{0:yyyy-MM}", combinedDate);
					string newDirName = Path.Combine(dest.FullName, yearInt.ToString());
					newDirName = Path.Combine(newDirName, dirNewName);

					if (monthDirDesc == monthDir.Name)
					{
						if (!CheckIfYearMonthFormatOnly(monthDir.Name))
						{
							newDirName = Path.Combine(newDirName, monthDirDesc);
						}
					}

					//source
					string sourceDirName = Path.Combine(source.FullName, yearDir.Name);
					sourceDirName = Path.Combine(sourceDirName, monthDir.Name);

					//create directory info's
					var diDestName = new DirectoryInfo(newDirName);
					var diSourceName = new DirectoryInfo(sourceDirName);

					Console.WriteLine();
					Utilities.CopyTo(diSourceName, diDestName, chkDestination.Checked, chkSkipExisting.Checked);

				}
			}


			//******
						

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
	}
}
