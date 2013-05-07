using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CopyRename
{
	class AddDashesToDates
	{

		static void RenameDatesWithDashes(string path)
		{
			var source = new DirectoryInfo(path);

			var allDirs = source.GetDirectories("*", SearchOption.AllDirectories);
			foreach (var subDir in allDirs)
			{
				string newName = AddDashesToDateInDirName(subDir.Name);
				var di = new DirectoryInfo(Path.Combine(subDir.Parent.FullName, newName));

				if (di.FullName != subDir.FullName)
				{
					subDir.MoveTo(di.FullName);
				}
			}
		}

		public static string AddDashesToDateInDirName(string dirName)
		{
			//define pattern and replacement
			//look for yyyymmdd(remainder) and changed to yyyy-mm-dd(remainder) 
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
	}
}
