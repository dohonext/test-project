using System;

namespace lab1
{
	class MainClass
	{
		public static void Main (string[] args)
		{string star = "*";
			for (int loop = 0; loop <5; loop++) {
					Console.WriteLine (star);
				star = star + "*";
			}
		}
	}
}
