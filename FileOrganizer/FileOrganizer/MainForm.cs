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


namespace FileOrganizer
{
	public partial class MainForm : Form
	{
		protected bool _overwrite = false;

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

			//create destination if it doesn't exist
			if (!dest.Exists)
			{
				dest.Create();
			}

			//go three levels deep
			var subDirs = source.GetDirectories("*", SearchOption.TopDirectoryOnly);

			foreach (var dir in subDirs)
			{
				var currDir = dir;
				var dirDate = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(currDir.Name));

				//if no date found, go one level down
				if (dirDate == DateTime.MinValue)
				{
					var subDirs2 = currDir.GetDirectories("*", SearchOption.TopDirectoryOnly);

					foreach (var subdir2 in subDirs2)
					{
						currDir = subdir2;
						dirDate = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(currDir.Name));

						//if no date found, go one level down
						if (dirDate == DateTime.MinValue)
						{
							//get directories
							var subDirs3 = currDir.GetDirectories("*", SearchOption.TopDirectoryOnly);

							foreach (var subdir3 in subDirs3)
							{
								currDir = subdir3;
								dirDate = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(currDir.Name));

								//copy directory
								CopyToNewDir(dirDate, dest, currDir, _overwrite);
							}
						}
						else
						{
							//copy directory
							CopyToNewDir(dirDate, dest, currDir, _overwrite);
						}

						//copy directory
						CopyToNewDir(dirDate, dest, currDir, _overwrite);
					}
				}
				else
				{
					//copy directory
					CopyToNewDir(dirDate, dest, currDir, _overwrite);
				}
			}

			btnRun.Enabled = true;
			btnRun.Text = "Go";

			//show complete
			MessageBox.Show("Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		protected static void CopyToNewDir(DateTime dirDate, DirectoryInfo dest, DirectoryInfo source, bool overwrite)
		{
			dirDate.ToString("D", CultureInfo.CreateSpecificCulture("en-US"));

			var dirNewName = DateFunctions.GetNewFullDirPath(dest, dirDate, source.Name);

			var diNewName = new DirectoryInfo(dirNewName);
			Utilities.CopyTo(source, diNewName, overwrite);

		}
	}
}
