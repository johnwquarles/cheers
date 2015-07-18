using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Cheers
{
	class MainClass
	{
		static string an_letters = "halfnorsemix";
		public static void Main (string[] args)
		{
			Console.WriteLine ("Your name, please?");
			string name = Console.ReadLine ();
			Console.WriteLine ("And your birthday? MM/DD please!");

			// sanitize input by matching against a regex
			string DOB = "";
			Regex regex = new Regex ("^(0?[1-9]|1[0-2])/(0?[1-9]|[12][0-9]|3[01])$");
			Match DOBgetwas;
			do 
			{
				DOB = Console.ReadLine ();
				DOBgetwas = regex.Match (DOB);
				if (!DOBgetwas.Success) {
					Console.WriteLine ("Please try that input again! MM/DD Please!");
				}
			} while (!DOBgetwas.Success);

			Console.WriteLine("\n");
			foreach (char c in name)
			{
				Console.WriteLine(Cheer (c));
			}

			Console.WriteLine(name.ToUpper() + " is.. GRAND!\n");
			Console.WriteLine(BDayLine (DOB));
		}

		private static string Cheer (char c)
		{
			string article;
			article = (an_letters.Contains(Char.ToLower(c))) ? "an" : "a";
			return "Give me " + article + ".. " + c;
		}
			
		private static string BDayLine (string DOB)
		{
			DateTime bday = makeBdayDateTime (DOB);
			int difference =  bday.DayOfYear - DateTime.Today.DayOfYear;
			string days = "";
			if (difference == 0) {
				return "Happy Birthday!!";
			} else if (difference > 0) {
				days = difference.ToString ();
			} else if (difference < 0) {
				days = (365 + difference).ToString ();
			}
			return "Your birthday is " + days + " days away!";
		}

		private static DateTime makeBdayDateTime (string DOB)
		{
			string[] month_day = DOB.Split ('/');
			DateTime bday = new DateTime(DateTime.Today.Year, int.Parse(month_day [0]), int.Parse(month_day [1]));
			return bday;
		}
	}
}
