using System;


namespace lab3
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Random random = new Random ();
			int x = random.Next (0,100);

			for(int i = 0; ; i++) 
			{ 
				Console.Write ("What's Your Guess? ");
				int y = int.Parse (Console.ReadLine());

				if (y > x) {
					Console.WriteLine ("Too high!!!");
				} else if (y < x) {
					Console.WriteLine ("Too Low!!!");
				} else if (y == x) {
					Console.WriteLine ("You Got it!!!");
					break;
				} 

				if (i == 5) {
					Console.WriteLine ("No more guess! Better luck next time");
					break;
				}
			}
		}
	}
}