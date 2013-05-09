using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FileUtilities
{
    class DateFunctions
    {
        #region Constructor

        internal static List<Month> _months;
        internal static List<Year> _years;    
		
		static DateFunctions()
        {
            //fill month array
            _months = Constants.GetMonths();
            _years = Constants.GetYears();
        }
        #endregion

        internal static string GetNewFullDirPath(DirectoryInfo dest, DateTime dirDate, string dirDesc)
        {
            //Detect if dir only had month and year in odd format
            string dirNewName;
			string monthDir = dirDate.Year + "-" + dirDate.Month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');

			if (DirectoryDescOnlyContainsDate(dirDesc))
			{
				dirNewName = string.Format("{0}\\{1}\\{2}",
						dest,
						dirDate.Year,
						monthDir
						);
			}
			else
			{
				dirNewName = string.Format("{0}\\{1}\\{2}\\{3}",
						dest,
						dirDate.Year,
						monthDir,
						dirDesc
						);
			}
                          
            return dirNewName;
        }

		private static bool DirectoryDescOnlyContainsDate(string dirDesc)
		{
			//strip year and month out
			//although year and month are not used, calling FindYear and FindMonth is only for the purpose of determining if 'remain' contains anything
			string remain;
			var year = FindYear(dirDesc, out remain);
			var month = FindMonth(remain, out remain);

			if (String.IsNullOrEmpty(remain))
			{
				return true;
			}

			return false;
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

        internal static DateTime GetReferenceDate(FileInfo file)
        {
            //use last written
            var dateTaken = file.LastWriteTime;
            //dateTaken = file.CreationTime;

            return dateTaken;
        }

        internal static string RemoveDateFromDirName(string dirName, int expectedDateDigits)
        {
			int lengthToRemove = expectedDateDigits + 1;
			var dirDesc = dirName.Substring(lengthToRemove, dirName.Length - lengthToRemove);
            return dirDesc;
        }

        internal static bool IsFullDateInDir(string dirName)
        {
            int i;
            return dirName.Length >= 8 && int.TryParse(dirName.Substring(0, 8), out i);
        }

        internal static bool RemoveIfContains(string input, string value, out string remains)
        {
			if (input.ToLowerInvariant().Contains(value.ToLowerInvariant()))
            {
				remains = input.ToLowerInvariant().Replace(value.ToLowerInvariant(), string.Empty).Trim();
                return true;
            }

            remains = string.Empty;
            return false;
        }

        internal static int FindMonth(string input, out string remains)
		{
		    foreach (var mo in _months)
		    {
		        //check for full name
		        if(RemoveIfContains(input, mo.FullName, out remains))
		        {
		            return mo.MonthInt;
		        }

		        //check for abbreviation
		        if(RemoveIfContains(input, mo.Abbreviation, out remains))
		        {
		            return mo.MonthInt;
		        }

		        //check for two-digit format
		        if(RemoveIfContains(input, mo.TwoDigitFormat, out remains))
		        {
		            return mo.MonthInt;
		        }
		    }

		    remains = string.Empty;
		    return 0;
		}

        internal static int FindYear(string input, out string remains)
        {
            foreach (var yr in _years)
            {
                //check for full date
                if (RemoveIfContains(input, yr.YearInt.ToString(CultureInfo.InvariantCulture), out remains))
                {
                    return yr.YearInt;
                }

            }

            remains = string.Empty;
            return 0;

        }
        internal static DateTime ParseLongDateFromDirName(string dirName)
        {
            var dirDate = new DateTime(Convert.ToInt16(dirName.Substring(0, 4)), Convert.ToInt16(dirName.Substring(4, 2)), Convert.ToInt16(dirName.Substring(6, 2)));
            return dirDate;
        }

		internal static string GetLongMonthDirName(int month)
		{
			var retval = "00 Unknown";
			foreach (var mo in _months)
			{
				if (mo.MonthInt == month)
				{
					retval = mo.TwoDigitFormat + " " + mo.FullName;
				}
			}
			return retval;
		}

	}
}
