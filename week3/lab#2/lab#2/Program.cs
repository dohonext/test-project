using System;

namespace avg
{
	class MainClass
	{
		public static void Main (string[] args)
		{   int a = 100;
			int b = 200;
			int c = 300;
			int d = 400;
			int avg = (a + b + c + d) / 4;

			Console.WriteLine ("first num: {0}, second num: {1}, third num: {2}, fourth num: {3}, average: {4}", a, b, c, d, avg);
		}
	}
}
