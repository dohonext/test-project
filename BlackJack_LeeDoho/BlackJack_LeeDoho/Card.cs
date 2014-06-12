using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    class Card
    {
        public int[] deck = new int[52];
        public int[] sameCheck = new int[52];

        public void Shuffle()
        {
            int deckCount = 0;

            Random random = new Random();

            for (; ; )
            {
                if (deckCount < 52)
                {
                    int s = random.Next(1, 53);
                    for (int i = 0; i < 52; i++)
                    {
                        if (s == i + 1)
                        {
                            if (sameCheck[i] == 0)
                            {
                                sameCheck[i] = 1;
                                deck[deckCount] = i + 1;
                                deckCount++;
                            }
                        }
                    }

                }
                else
                {
                    break;
                }
            }
        }

        public int CardValue(int cardNumber)
        {
            switch (cardNumber)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                case 5:
                    return 5;
                case 6:
                    return 6;
                case 7:
                    return 7;
                case 8:
                    return 8;
                case 9:
                    return 9;
                case 10:
                    return 10;
                case 11:
                    return 10;
                case 12:
                    return 10;
                case 13:
                    return 10;
                case 14:
                    return 1;
                case 15:
                    return 2;
                case 16:
                    return 3;
                case 17:
                    return 4;
                case 18:
                    return 5;
                case 19:
                    return 6;
                case 20:
                    return 7;
                case 21:
                    return 8;
                case 22:
                    return 9;
                case 23:
                    return 10;
                case 24:
                    return 10;
                case 25:
                    return 10;
                case 26:
                    return 10;
                case 27:
                    return 1;
                case 28:
                    return 2;
                case 29:
                    return 3;
                case 30:
                    return 4;
                case 31:
                    return 5;
                case 32:
                    return 6;
                case 33:
                    return 7;
                case 34:
                    return 8;
                case 35:
                    return 9;
                case 36:
                    return 10;
                case 37:
                    return 10;
                case 38:
                    return 10;
                case 39:
                    return 10;
                case 40:
                    return 1;
                case 41:
                    return 2;
                case 42:
                    return 3;
                case 43:
                    return 4;
                case 44:
                    return 5;
                case 45:
                    return 6;
                case 46:
                    return 7;
                case 47:
                    return 8;
                case 48:
                    return 9;
                case 49:
                    return 10;
                case 50:
                    return 10;
                case 51:
                    return 10;
                case 52:
                    return 10;
                default:
                    return 20;
            }
        }
    }
}

