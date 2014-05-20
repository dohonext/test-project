using System;

namespace lab1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write ("Enter the first number :");
			int firstNum = int.Parse (Console.ReadLine ());
			Console.Write ("Enter the second number :");
			int secondNum = int.Parse (Console.ReadLine ());
			Console.Write ("Enter the operator (+, -, *, /, % are allowed) :");
			string operation = Console.ReadLine ();

			if (operation == "+") {
				Console.WriteLine ("Result : {0}", firstNum + secondNum);
			} 
			else if (operation == "-") {
				Console.WriteLine ("Result : {0}", firstNum - secondNum);
			} 
			else if (operation == "*") {
				Console.WriteLine ("Result : {0}", firstNum * secondNum);
			} 
			else if (operation == "/") {
				Console.WriteLine ("Result : {0}", firstNum / secondNum);
			} 
			else if (operation == "%") {
				Console.WriteLine ("Result : {0}", firstNum % secondNum);
			}
			else {
					Console.WriteLine ("you entered {0}, only +, -, *, /, % are allowed", operation);
			}

		}
	}
}
