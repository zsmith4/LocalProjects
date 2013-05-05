using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace DatesWithDashes
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = args[0];
			//string path = @"C:\Users\Zach\Photos";

			if (String.IsNullOrEmpty(path))
			{
				Console.WriteLine("Please provide a path as the first argument");
				return;
			}
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
