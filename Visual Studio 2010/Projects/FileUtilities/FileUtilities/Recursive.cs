using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

namespace FileUtilities
{
	internal static class Recursive
	{
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

