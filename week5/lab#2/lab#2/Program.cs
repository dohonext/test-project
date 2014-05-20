using System;

namespace lab2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			for (int first = 1; first <= 9; first++) {
				Console.WriteLine ("[{0} times table]", first);
				for (int second =1; second <= 9; second++)
					Console.WriteLine ("{0} * {1} = {2}", first, second, first * second);
				Console.WriteLine (" ");
			}
		}
		
	}
}
