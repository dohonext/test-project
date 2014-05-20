using System;

namespace lab5
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			int[,] mArray = new int[32,5];
			int count=0;

			for (int i=0; i<2; i++) {
				for (int j=0; j<2; j++) {
					for (int k=0; k<2; k++) {
						for (int l=0; l<2; l++) {
							for (int m=0; m<2; m++) {

								mArray [count, 0] = i;
								mArray [count, 1] = j;
								mArray [count, 2] = k;
								mArray [count, 3] = l;
								mArray [count, 4] = m;
								count++;
							}
						}
					}
				}
			}				
			Console.WriteLine ("Sausage Bun     Ketchup Mustard Onions");
			for(int i=0; i<=count; i++) {
				Console.WriteLine ("{0}       {1}       {2}       {3}       {4}", mArray[i, 0], mArray[i, 1], mArray[i, 2], mArray[i,3], mArray[i,4]);
			}
		}

	}
}
