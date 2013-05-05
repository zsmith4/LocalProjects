//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace FileOrganizer
//{
//    class Class1
//    {
//        private void DoSomething()
//        {
		//    //go three levels deep
		//    var subDirs = source.GetDirectories("*", SearchOption.TopDirectoryOnly);

		//    foreach (var subDir in subDirs)
		//    {
		//        var dirDate = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(subDir.Name));

		//        //if no date found, go one level down
		//        if (dirDate == DateTime.MinValue)
		//        {
		//            var subDirs2 = subDir.GetDirectories("*", SearchOption.TopDirectoryOnly);

		//            //level 2
		//            foreach (var subDir2 in subDirs2)
		//            {
		//                ////testing
		//                //if (currDir.Name.Contains("2005-03"))
		//                //{
		//                //    Console.WriteLine();
		//                //}

		//                //currDir = subdir2;
		//                //dirDate = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(currDir.Name));  //does not parse with year-mm

		//                var dirDate2 = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(subDir2.Name));  //does not parse with year-mm

		//                //if no date found, go one level down
		//                if (dirDate2 == DateTime.MinValue)
		//                {
		//                    //get directories
		//                    var subDirs3 = subDir2.GetDirectories("*", SearchOption.TopDirectoryOnly);

		//                    foreach (var subdir3 in subDirs3)
		//                    {
		//                        dirDate = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(subdir3.Name));
								
		//                        //currDir = subdir3;
		//                        //dirDate = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(currDir.Name));

		//                        //copy directory
		//                        CopyToNewDir(dirDate, dest, subdir3, _overwrite, _skip);
		//                    }
		//                }
		//                else
		//                {
		//                    //copy directory
		//                    CopyToNewDir(dirDate, dest, subDir2, _overwrite, _skip);
		//                }

		//                //copy directory
		//                CopyToNewDir(dirDate, dest, subDir, _overwrite, _skip);
		//            }
		//        }
		//        else
		//        {
		//            //copy directory
		//            CopyToNewDir(dirDate, dest, subDir, _overwrite, _skip);
		//        }
		//    }
		//}

////namespace FileOrganizer
////{
////    class Class1
////    {
////                //get list of files and sort
////                var files = Sort(source.GetFiles("*" + Settings.Ext));

////                //re-iterate through files
////                foreach (FileInfo fi in files)
////                {
////                    //get new file name and copy to dest
					
////                    fi.CopyTo(Path.Combine(dest.ToString(), fileName), true);

////                    //increment counter property
////                    Counter++;
////                    FilesProcessed++;

////                    Worker.ReportProgress(FilesProcessed/TotalFiles);

////                }

////                //recursively copy each subdirectory
////                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
////                {
////                    if (Worker.CancellationPending)
////                    {
////                        Worker.CancelAsync();
////                        WorkerCancelled = true;
////                        break;
////                    }

////                    DirectoryInfo nextTargetSubDir = dest.CreateSubdirectory(diSourceSubDir.Name);
////                    CopyRecursiveWithRename(diSourceSubDir, nextTargetSubDir, prefix, digits, useDirName, numberFirst);
////                }
////    }
////}

			////get year directories
			//var yearDirs = source.GetDirectories("*", SearchOption.TopDirectoryOnly);
			//foreach (var yearDir in yearDirs)
			//{
			//    //get year from directory name
			//    var year = RegularExpressions.ParseDate(yearDir.Name);
			//    var yearInt = 1901;
			//    var monthInt = 0;
			//    if (year != DateTime.MinValue)
			//    {
			//        yearInt = year.Year;
			//    }
				
			//    //get month-level directories
			//    var monthDirs = yearDir.GetDirectories("*", SearchOption.TopDirectoryOnly);
			//    foreach (var monthDir in monthDirs)
			//    {
			//        //remove year from directory name first. Then return remainder
			//        string monthDirDesc;
			//        DateFunctions.RemoveIfContains(monthDir.Name, year.Year.ToString(), out monthDirDesc);

			//        //determine the month
			//        var month = RegularExpressions.ParseDate(monthDirDesc);
			//        if (month != DateTime.MinValue)
			//        {
			//            monthInt = month.Month;
			//        }

			//    }
			//}



			////get year directories
			//var dirs = source.GetDirectories("*", SearchOption.TopDirectoryOnly);
			//foreach (var dir in dirs)
			//{
			//    var year = 1901;
			//    var month = 0;
			//    var day = 0;
			//    string desc = String.Empty;

			//    string newDirName = RegularExpressions.AddDashesToDateInDirName(dir.Name);

			//    //remove special characters and look for year, mm
			//    var dirDate = RegularExpressions.ParseDate(DateFunctions.RemoveSpecialChars(newDirName));

			//    if (dirDate != DateTime.MinValue)
			//    {
			//        year = dirDate.Year;
			//        month = dirDate.Month;
			//        day = dirDate.Day;
			//        desc = RegularExpressions.AddDashesToDateInDirName(newDirName);
			//    }
			//    else
			//    {
			//        desc = dir.Name;
			//    }

			//    string targetPath = Path.Combine(dest.FullName, newDirName);
			//    var targetDirInfo = new DirectoryInfo(targetPath);

			//    CopyToNewDir(dirDate, targetDirInfo, source, chkDestination.Checked, chkSkipExisting.Checked);
			//}