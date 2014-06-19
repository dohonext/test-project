using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class Card
    {
        public int[] deck = new int[52];
        public int[] sameCheck = new int[52];
        public int[] CardValue = new int[53]{
            0,1,2,3,4,5,6,7,8,9,10,10,10,10,
            1,2,3,4,5,6,7,8,9,10,10,10,10,
            1,2,3,4,5,6,7,8,9,10,10,10,10,
            1,2,3,4,5,6,7,8,9,10,10,10,10};
        public Bitmap[] Cards = new Bitmap[54]{
            new Bitmap(WindowsFormsApplication2.Properties.Resources.basic),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._1),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._2),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._3),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._4),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._5),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._6),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._7),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._8),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._9),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._10),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._11),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._12),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._13),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._14),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._15),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._16),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._17),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._18),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._19),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._20),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._21),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._22),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._23),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._24),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._25),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._26),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._27),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._28),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._29),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._30),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._31),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._32),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._33),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._34),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._35),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._36),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._37),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._38),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._39),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._40),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._41),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._42),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._43),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._44),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._45),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._46),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._47),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._48),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._49),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._50),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._51),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._52),
            new Bitmap(WindowsFormsApplication2.Properties.Resources._0)};


        public int[] DealerCard;
        public int[] PlayerCard;
        public int DealerCardSum;
        public int PlayerCardSum;
        
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

        public void First2CardsDistribute()
        {
            DealerCard[0] = deck[0];
            DealerCard[1] = deck[1];//딜러카드 두장 분배, 플레이어 카드 두장 분배
            PlayerCard[0] = deck[2];
            PlayerCard[1] = deck[3];
        }

        public void FirstSum()
        {
            DealerCardSum = CardValue[DealerCard[0]] + CardValue[DealerCard[1]];
            PlayerCardSum = CardValue[PlayerCard[0]] + CardValue[PlayerCard[1]];
        }
    }
}

