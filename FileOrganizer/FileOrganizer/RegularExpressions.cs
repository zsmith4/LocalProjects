﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FileOrganizer
{
    public static class RegularExpressions
    {
        static RegularExpressions()
        {
            var regExDict = new Dictionary<string, string>();
			
			//YYYYMMDD =  = MM/DD/YYYY
			regExDict.Add(@"(?<year>\d{4})(?<month>\d{2})(?<day>\d{2})\b.*", "${month}/${day}/${year}");
            
            //YYYYMM = MM/DD/YYYY
            regExDict.Add(@"(?<year>\d{4})(?<month>\d{2})\b.*", "${month}/1/${year}");

			////YYYY
			regExDict.Add(@"(?<year>\d{4})\b.*", "01/01/${year}");

			////YY(YY)M(M)D(D)
			////regExDict.Add(@".*\b(?<year>\d{4})(?<month>\d{1,2})(?<day>\d{1,2})\b.*", "${month}/${day}/${year}");
			////regExDict.Add(@".*\b(?<year>\d{2,4})(?<month>\d{1,2})(?<day>\d{1,2})\b.*", "${month}/${day}/${year}");
			////YYYYMM
			//regExDict.Add(@"(?<year>\d{4})(?<month>\d{2})\b.*", "${month}/${year}");

            RegExDict = regExDict;
        }

        public static DateTime ParseDate(string input)
        {            

            var date = new DateTime();
            foreach (var kvp in RegExDict)
            {
                if (Regex.IsMatch(input, kvp.Key))
                {
                    var temp = Regex.Replace(input, kvp.Key, kvp.Value);
					
					DateTime.TryParse(Regex.Replace(input, kvp.Key, kvp.Value), out date);

					break;
                }
            }

			if(date == DateTime.MinValue)
			{
				date = FindStringMonthWithDigitYear(input);
			}

			Console.WriteLine();
			return date;
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

		public static string GetDescWithoutDate(string dirName)
		{
			//define pattern and replacement
			string pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})(?<remain>\b.*)";
			string replacement = "${remain}";

			//perform replacement
			Regex regEx = new Regex(pattern);
			string result = regEx.Replace(dirName, replacement);

			if (!String.IsNullOrEmpty(result))
			{
				return result;
			}

			return dirName;
		}

        public static DateTime FindStringMonthWithDigitYear(string input)
        {
            int moNum = 0;
        	DateTime date;
            foreach(Month month in Constants.GetMonths())
            {
                if(input.Contains(month.FullName) || input.Contains(month.Abbreviation))
                {
                    moNum = month.MonthInt;
					break;
                }
            }
		
            //if month found, look for year with regEx
        	DateTime.TryParse(moNum + "/1/" + Regex.Replace(input, @".*(?<year>\d{2,4}).*", "${year}"), out date );

        	return date;
        }

        public static Dictionary<string, string> RegExDict { get; set; }
    }
}
