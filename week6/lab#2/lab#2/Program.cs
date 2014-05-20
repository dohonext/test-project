using System;

namespace Drawing
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			DrawThings (1, 3, "*");
			DrawThings (2, 4, "#");
			DrawThings (4, 8, "%");
		}

		public static void DrawThings (int times, int lines, string thing)
		{
			for (int outer = 1; outer <= lines; outer++) 
			{
				for (int inner = 1; inner <= outer * times; inner++) 
				{
					Console.Write (thing);
				}
				Console.WriteLine ();
			}
			Console.WriteLine ();
		}
	}
}