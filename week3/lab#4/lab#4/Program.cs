using System;

namespace sum2lab4
{
	class MainClass
	{
		public static void Main (string[] args)
		{   Console.WriteLine ("type 2 numbers if you want to know their sum.");
			string value1 = Console.ReadLine ();
			int a = int.Parse (value1); 
			string value2 = Console.ReadLine ();
			int b = int.Parse (value2); 
			Console.WriteLine ("sum: {0}", a + b);
		}
	}
}
