using System;
using System.Collections.Generic;

namespace Cheers
{
	class MainClass
	{
		static List<char> an_letters = new List<char> (new char[] { 'a', 'e', 'f', 'h', 'i', 'l', 'm', 'n', 'o', 'r', 's', 'x' });

		public static void Main (string[] args)
		{
			Console.WriteLine ("Your name, please?");
			string name = Console.ReadLine ();
			Console.WriteLine ("And your birthday? MM/DD please!");
			string DOB = Console.ReadLine ();

			foreach (char c in name)
			{
				Console.WriteLine(Cheer (c));
			}
			Console.WriteLine(name.ToUpper() + " is.. GRAND!");
			//Console.WriteLine ("\n");
			Console.WriteLine(BDayLine (DOB));
		}

		private static string Cheer (char c)
		{
			string article;
			article = (an_letters.Contains (Char.ToUpper(c)) || an_letters.Contains(Char.ToLower(c))) ? "an" : "a";
			return "Give me " + article + ".. " + c;
		}
			
		private static string BDayLine (string DOB)
		{
			DateTime bday = makeBdayDateTime (DOB);
			int difference =  bday.DayOfYear - DateTime.Today.DayOfYear;
			string days;
			if (difference > 0) {
				days = difference.ToString ();
			} else if (difference < 0) {
				days = (365 + difference).ToString ();
			} else {
				days = "Something has gone horribly wrong.";
			}
			return "Your birthday is " + days + " days away!";
		}

		private static bool isBirthday (DateTime bday)
		{
			if (bday.DayOfYear == DateTime.Today.DayOfYear)
				return true;
			return false;
		}

		private static DateTime makeBdayDateTime (string DOB)
		{
			string[] month_day = DOB.Split ('/');
			DateTime bday = new DateTime(DateTime.Today.Year, int.Parse(month_day [0]), int.Parse(month_day [1]));
			return bday;
		}
	}
}
