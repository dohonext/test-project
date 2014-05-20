using System;

namespace stringlab3
{
	class MainClass
	{
		public static void Main (string[] args)
		{   string name = "Lee Doho";
			string greeting = "Hello, ";
			string result = greeting + name;

			Console.WriteLine ("{0} - munjasoo: {1}", result, result.Length);
		}
	}
}
