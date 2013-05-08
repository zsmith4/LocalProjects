using System;
using System.Collections.Generic;
using System.Globalization;

namespace FileUtilities
{
	public static class Constants
	{
        public static List<Month> GetMonths()
		{
		    var months = new List<Month>();

            //Unknown
            var month = new Month { MonthInt = 0, FullName = "Unknown", Abbreviation = "Unknown", TwoDigitFormat = "99" };
            months.Add(month);

            //January
            month = new Month {MonthInt = 1, FullName = "January", Abbreviation = "Jan", TwoDigitFormat = "01"};
            months.Add(month);

            //February
            month = new Month { MonthInt = 2, FullName = "February", Abbreviation = "Feb", TwoDigitFormat = "02" };
            months.Add(month);

            //March
            month = new Month { MonthInt = 3, FullName = "March", Abbreviation = "Mar", TwoDigitFormat = "03" };
            months.Add(month);

            //April
            month = new Month { MonthInt = 4, FullName = "April", Abbreviation = "Apr", TwoDigitFormat = "04" };
            months.Add(month);

            //May
            month = new Month { MonthInt = 5, FullName = "May", Abbreviation = "May", TwoDigitFormat = "05" };
            months.Add(month);

            //June
            month = new Month { MonthInt = 6, FullName = "June", Abbreviation = "Jun", TwoDigitFormat = "06" };
            months.Add(month);

            //July
            month = new Month { MonthInt = 7, FullName = "July", Abbreviation = "Jul", TwoDigitFormat = "07" };
            months.Add(month);

            //August
            month = new Month { MonthInt = 8, FullName = "August", Abbreviation = "Aug", TwoDigitFormat = "08" };
            months.Add(month);

            //September
            month = new Month { MonthInt = 9, FullName = "September", Abbreviation = "Sep", TwoDigitFormat = "09" };
            months.Add(month);

            //October
            month = new Month { MonthInt = 10, FullName = "October", Abbreviation = "Oct", TwoDigitFormat = "10" };
            months.Add(month);

            //November
            month = new Month { MonthInt = 11, FullName = "November", Abbreviation = "Nov", TwoDigitFormat = "11" };
            months.Add(month);

            //December
            month = new Month { MonthInt = 12, FullName = "December", Abbreviation = "Dec", TwoDigitFormat = "12" };
            months.Add(month);

		    return months;
		}
	    
        public static List<Year> GetYears()
        {
            var years = new List<Year>();
            var start = DateTime.Now.AddYears(-70).Year;
            var end = DateTime.Now.AddYears(2).Year;

            for (var i = start; i < end; i++)
            {
                var year = new Year {YearInt = i, TwoDigitFormat = i.ToString(CultureInfo.InvariantCulture).Remove(0, 2)};
                years.Add(year);
            }

            return years;
        }
	}
}
