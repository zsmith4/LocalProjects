using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

namespace FileUtilities
{
	internal static class Recursive
	{
		internal static void CopyRecursive(DirectoryInfo source, DirectoryInfo dest)
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
		
		internal static List<FileInfo> Sort(FileInfo[] fileList)
		{
			List<FileInfo> newList = fileList.ToList();
			newList.ToList().Sort((a, b) => String.CompareOrdinal(a.Name, b.Name));
			return newList;
		}

		internal static void SortIndividualPicturesByDate(DirectoryInfo source, DirectoryInfo dest, bool useYearMonthDir, bool copy)
		{
			//move files based on their file date
			var files = source.GetFiles("*", SearchOption.TopDirectoryOnly);
			foreach (var file in files)
			{
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
		}

		internal static void Organize(DirectoryInfo source, DirectoryInfo dest, bool addDashesToDates, bool overwrite, bool skip, bool useMonthSubDirs)
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
					string newName = RegularExpressions.AddDashesToDateInDirName(subDir.Name);
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

					Console.WriteLine();
					CopyTo(diSourceName, diDestName, overwrite, skip);

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

		#region Unused Code
		//public void CopyRecursiveWithRename(DirectoryInfo source, DirectoryInfo dest, string prefix, int digits, bool useDirName, bool numberFirst)
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
		//        var fileName = GetFileName(prefix, Counter, digits, fi.Extension, numberFirst);
		//        fi.CopyTo(Path.Combine(dest.ToString(), fi.Name), true);
		//    }

		//    //recursively copy each subdirectory
		//    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		//    {
		//        DirectoryInfo nextTargetSubDir = dest.CreateSubdirectory(diSourceSubDir.Name);
		//        CopyRecursiveWithRename(diSourceSubDir, nextTargetSubDir, prefix, digits, useDirName, numberFirst);
		//    }
		//}
		#endregion Unused Code
	}
}
