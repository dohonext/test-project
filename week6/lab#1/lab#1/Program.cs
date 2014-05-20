using System;

namespace Numbers
{

	class MainClass
	{   
		public static void Main (string[] args)
		{
			Logo ();
			string name = NameTake ();
			int[] numbers = NumberMake ();
			Show (name, numbers);
		}

		public static void Logo()
		{
			Console.WriteLine ("**********************************");
			Console.WriteLine ("******** Lottery Numbers *********");
			Console.WriteLine ("**********************************");
		}

		public static string NameTake ()
		{   
			Console.Write ("Enter yout name: ");
			return Console.ReadLine ();
		}

		public static int[] NumberMake ()
		{

			int[] _numbers = MakeDefaultNumbers ();
			_numbers = SameCheck (_numbers);
			return _numbers;
		}

		public static void Show (string _name, int[] _numbers)
		{
			ShowName (_name);
			ShowNumbers (_numbers);
			ShowClosed ();
		}

		public static int[] MakeDefaultNumbers ()
		{
			int[] __numbers = new int[6] {0, 0, 0, 0, 0, 0};
			return __numbers;
		}

		public static int[] SameCheck (int[] __numbers)
		{
			int index = 0;
			Random random = new Random ();
			do {		
				bool found = false;
				int randomNumber = random.Next (1, 46);
				for (int loop = 0; loop < index; loop++) {
					if (__numbers [loop] == randomNumber) {
						found = true;
						break;
					}
				}
				if (!found) {
					__numbers [index] = randomNumber;
					index++;
				}
			} while(index < __numbers.Length);
			return __numbers;
		}

		public static void ShowName (string __name)
		{
			Console.Write ("Name : {0}, Numbers : [", __name);
		}
			
		public static void ShowNumbers (int[] __numbers)
		{
			foreach(int number in __numbers)
			{
				Console.Write ("{0} ", number);
			}
		}

		public static void ShowClosed ()
		{
			Console.WriteLine ("]");
		}
	}
}
