using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace FileOrganizer
{
    public static class Utilities
    {
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
			name = name.Remove(name.LastIndexOf("."));
			name = name + "_Duplicate_" + String.Format("{0:yyyy.dd.MM.H.mm.ss.ffffff}", System.DateTime.Now);
			name = name + extension;
			return name;
		}


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
    }
}
