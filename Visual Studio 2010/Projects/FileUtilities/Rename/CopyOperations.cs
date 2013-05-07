using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CopyRename.Properties;

namespace CopyRename
{
    public static class CopyOperations
	{
		////property to hold file counter from MainForm
		//public static int Counter { get; set; }
		//public static int FilesCopied { get; set; }
		//public static int TotalFiles { get; set; }
        
		//public static void CopyRecursiveWithRename(DirectoryInfo source, DirectoryInfo dest, string prefix, int digits, string ext, bool useDirName)
		//{
		//    //create dest directory if it doesn't exist
		//    if (Directory.Exists(dest.FullName) == false)
		//    {
		//        Directory.CreateDirectory(dest.FullName);
		//    }
			
		//    //get list of files and sort
		//    var files = Sort(source.GetFiles("*" + ext));
            
		//    //re-iterate through files
		//    foreach (FileInfo fi in files)
		//    {
		//        //get new file name and copy to dest
		//        if (useDirName)
		//        {
		//            prefix = source.Name;
		//        }
		//        var fileName = GetFileName(prefix, Counter, digits, ext);
		//        fi.CopyTo(Path.Combine(dest.ToString(), fileName), true);
				
		//        //increment counter property
		//        Counter++;
		//        FilesCopied++;
		//    }

		//    //recursively copy each subdirectory
		//    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		//    {
		//        DirectoryInfo nextTargetSubDir = dest.CreateSubdirectory(diSourceSubDir.Name);
		//        CopyRecursiveWithRename(diSourceSubDir, nextTargetSubDir, prefix, digits, ext, useDirName );
		//    }
		//}

		//public static string GetFileName(string prefix, int counter, int digits, string ext)
		//{
		//    return prefix + "_" + counter.ToString().PadLeft(digits, '0') + ext;
		//}

		//#region unused

		////public static void CopyRecursive(DirectoryInfo source, DirectoryInfo dest)
		////{
		////    // Check if the dest directory exists, if not, create it.
		////    if (Directory.Exists(dest.FullName) == false)
		////    {
		////        Directory.CreateDirectory(dest.FullName);
		////    }

		////    // Copy each file into it's new directory.
		////    foreach (FileInfo fi in source.GetFiles())
		////    {
		////        Console.WriteLine(@"Copying {0}\{1}", dest.FullName, fi.Name);
		////        fi.CopyTo(Path.Combine(dest.ToString(), fi.Name), true);
		////    }

		////    // Copy each subdirectory using recursion.
		////    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		////    {
		////        DirectoryInfo nextTargetSubDir =
		////            dest.CreateSubdirectory(diSourceSubDir.Name);
		////        CopyRecursive(diSourceSubDir, nextTargetSubDir);
		////    }
		////}

		//#endregion

		//#region Sorting
		//public static List<FileInfo> Sort(FileInfo[] fileList)
		//{
		//    List<FileInfo> newList = fileList.ToList();
		//    newList.ToList().Sort((a, b) => String.Compare(a.Name, b.Name));
		//    return newList;
		//}

		//public static List<DirectoryInfo> Sort(DirectoryInfo[] dirList)
		//{
		//    List<DirectoryInfo> newList = dirList.ToList();
		//    newList.ToList().Sort((a, b) => String.Compare(a.Name, b.Name));
		//    return newList;
		//}
		//#endregion

		//#region Image rotate
		//public static void RotateFlipInPlace(string path, System.Drawing.RotateFlipType rotateFlipType)
		//{
		//    var image = System.Drawing.Image.FromFile(path);
		//    image.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
		//    image.Save(path,ImageFormat.Jpeg);
		//}
		//#endregion
	}
}
