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
			foreach (char c in name)
			{
				Console.WriteLine(Cheer (c));
			}
			Console.WriteLine(name.ToUpper() + " is.. GRAND!");
		}

		private static string Cheer (char c)
		{
			string article;
			article = (an_letters.Contains (Char.ToUpper(c)) || an_letters.Contains(Char.ToLower(c))) ? "an" : "a";
			return "Give me " + article + ".. " + c;
		}
	}
}
