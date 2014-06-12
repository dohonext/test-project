using System;

namespace lab4
{
	class MainClass
	{
		public static void Main (string[] args)
		{for (;;)
		 {
			Console.Write ("Enter the operation[+,-,*,/](If you want to quit, enter 'q'): ");
				string oper = Console.ReadLine ();

			switch (oper)
			{
				case "+":
					Console.Write ("Enter the first number: ");
					int a = int.Parse (Console.ReadLine ());
					Console.Write ("Enter the second number: ");
					int b = int.Parse (Console.ReadLine ());
					Console.WriteLine ("Result : {0}", a + b);
					Console.WriteLine ("");
				    break;
				case "-":
					Console.Write ("Enter the first number: ");
					int c = int.Parse (Console.ReadLine ());
					Console.Write ("Enter the second number: ");
					int d = int.Parse (Console.ReadLine ());
				    Console.WriteLine ("Result : {0}",c-d);
					Console.WriteLine ("");
				    break;
				case "*":
					Console.Write ("Enter the first number: ");
					int e = int.Parse (Console.ReadLine ());
					Console.Write ("Enter the second number: ");
					int f = int.Parse (Console.ReadLine ());
				    Console.WriteLine ("Result : {0}",e*f);
					Console.WriteLine ("");
				    break;
				case "/":
					Console.Write ("Enter the first number: ");
					int g = int.Parse (Console.ReadLine ());
					Console.Write ("Enter the second number: ");
					int h = int.Parse (Console.ReadLine ());
				    Console.WriteLine ("Result : {0}",g/h);
					Console.WriteLine ("");
				    break;
				case "q":
				    Console.WriteLine ("Bye!");
					Console.WriteLine ("");
				    break;
				default:
				    Console.WriteLine ("You entered wrong operation. Only +,-,*,/,q are allowed!");
					Console.WriteLine ("");
				    break;
			}
			if (oper == "q") 
			{
				break;
			}
		  }
		}
	}
}
