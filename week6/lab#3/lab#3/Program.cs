using System;

namespace lab3
{
	class MainClass
	{
		public static void Main (string[] args)
		{   
			int frontindex = 0;

			string input = TakeWord ();
			int index = CountWord (input);
			Palindrome (input, ref index, ref frontindex);

		}

		public static string TakeWord ()
		{
			Console.Write ("Type any word: ");
			string _input = Console.ReadLine ();
			return _input;
		}

		public static int CountWord (string _input)
		{
			int _index = _input.Length - 1;
			return _index;
		}


		public static void Palindrome (string _input, ref int index, ref int frontindex)
		{

			if (index == 0) { 
				Console.WriteLine ("'{0}' is Palindrome.", _input);
				return;
			}
			if (index >= 1) {
				if (_input [frontindex] == _input [index]) {
					index = index - 1;
					frontindex = frontindex + 1;
					Palindrome (_input, ref index, ref frontindex); 
				} else {
					Console.WriteLine ("'{0}' is not Palindrome.", _input);
					return;
				}
				return;
			}
			return;
		}
	}
}
