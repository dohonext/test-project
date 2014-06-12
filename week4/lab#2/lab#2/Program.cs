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

			switch (operation) 
			{
				case "+":
				Console.WriteLine ("Result : {0}", firstNum + secondNum);
				break;
				case "-":
				Console.WriteLine ("Result : {0}", firstNum - secondNum);
				break;
				case "*":
				Console.WriteLine ("Result : {0}", firstNum * secondNum);
				break;
				case "/":
				Console.WriteLine ("Result : {0}", firstNum / secondNum);
				break;
				case "%":
				Console.WriteLine ("Result : {0}", firstNum % secondNum);
				break;
				default:
				Console.WriteLine ("+, -, *, /, % are allowed");
				break;
			}

		}
	}
}