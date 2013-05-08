using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileUtilities
{
	class RecursiveOperations
	{
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
			newList.ToList().Sort((a, b) => String.CompareOrdinal(a.Name, b.Name));
			return newList;
		}

		public void SortIndividualPicturesByDate(DirectoryInfo source, DirectoryInfo dest)
		{
			//move files based on their file date
			var files = source.GetFiles("*", SearchOption.TopDirectoryOnly);
			foreach (var file in files)
			{
				var fileDate = DateFunctions.GetReferenceDate(file);

				if (fileDate != DateTime.MinValue)
				{
					var path = String.Format(chkUseYearMonthDir.Checked ? "{0}\\{1:yyyy}\\{1:yyyy-MM}" : "{0}\\{1:yyyy}", dest.FullName, fileDate);

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

						if (chkSortCopy.Checked)
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
	}
}
