using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FileOrganizer
{
    class DateFunctions
    {
        internal static List<Month> mMonths;
        internal static List<Year> mYears;

        #region Constructor
        static DateFunctions()
        {
            //fill month array
            mMonths = Constants.GetMonths();
            mYears = Constants.GetYears();
        }
        #endregion

        internal static string GetNewFullDirPath(DirectoryInfo dest, DateTime dirDate, string dirDesc)
        {

            var dirNewName = string.Format("{0}\\{1}\\{2}\\{3}",
                               dest,
                               dirDate.Year,
                               GetLongMonthDirName(dirDate.Month),
                               dirDesc
                               );
            return dirNewName;
        }

		public static string RemoveSpecialChars(string input)
        {
        	var output = input.Replace("-", "");
			output = output.Replace("_", "");
			output = output.Replace("&", "");
			output = output.Replace("(", "");
            output = output.Replace(")", "");

			return output;
        }

        internal static string GetLongMonthDirName(int month)
        {
            var retval = "00 Unknown";
            foreach (var mo in mMonths)
            {
                if (mo.MonthInt == month)
                {
                    retval = mo.TwoDigitFormat + " " + mo.FullName;
                }
            }
            return retval;
		}

		#region Unused Code

		//internal static DateTime GetReferenceDate(FileInfo file)
		//{
		//    //use last written
		//    var dateTaken = file.LastWriteTime;
		//    //dateTaken = file.CreationTime;

		//    return dateTaken;
		//}

		//internal static string ParseDescFromDirName(string dirName)
		//{
		//    var dirDesc = dirName.Substring(9, dirName.Length - 9);
		//    return dirDesc;
		//}

		//internal static bool IsFullDateInDir(string dirName)
		//{
		//    int i;
		//    return dirName.Length >= 8 && int.TryParse(dirName.Substring(0, 8), out i);
		//}

		//internal static bool RemoveIfContains(string input, string value, out string remains)
		//{
		//    input.ToLowerInvariant();
		//    value.ToLowerInvariant();
		//    if (input.Contains(value))
		//    {
		//        remains = input.Replace(value, string.Empty).Trim();
		//        return true;
		//    }
            
		//    remains = string.Empty;
		//    return false;
		//}

		//internal static int FindMonth(string input, out string remains)
		//{
		//    foreach (var mo in mMonths)
		//    {
		//        //check for full name
		//        if(RemoveIfContains(input, mo.FullName, out remains))
		//        {
		//            return mo.MonthInt;
		//        }

		//        //check for abbreviation
		//        if(RemoveIfContains(input, mo.Abbreviation, out remains))
		//        {
		//            return mo.MonthInt;
		//        }

		//        //check for two-digit format
		//        if(RemoveIfContains(input, mo.TwoDigitFormat, out remains))
		//        {
		//            return mo.MonthInt;
		//        }
		//    }

		//    remains = string.Empty;
		//    return 0;
		//}

		//internal static int FindYear(string input, out string remains)
		//{
		//    foreach (var yr in mYears)
		//    {
		//        //check for full date
		//        if (RemoveIfContains(input, yr.YearInt.ToString(), out remains))
		//        {
		//            return yr.YearInt;
		//        }

		//        //check for abbreviation
		//        if (RemoveIfContains(input, yr.TwoDigitFormat, out remains))
		//        {
		//            return yr.YearInt;
		//        }
		//    }

		//    remains = string.Empty;
		//    return 0;

		//}
		//internal static DateTime ParseLongDateFromDirName(string dirName)
		//{
		//    var dirDate = new DateTime(Convert.ToInt16(dirName.Substring(0, 4)), Convert.ToInt16(dirName.Substring(4, 2)), Convert.ToInt16(dirName.Substring(6, 2)));
		//    return dirDate;
		//}
		#endregion

	}
}
