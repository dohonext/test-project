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
    public partial class Form1 : Form
    {
        public Bitmap[] Cards = new Bitmap[54];
        int playerMoney = 100;
        int betting = 0;


        public Form1()
        {
            InitializeComponent();
            Cards[0] = new Bitmap(WindowsFormsApplication2.Properties.Resources.basic);
            Cards[1] = new Bitmap(WindowsFormsApplication2.Properties.Resources._1);
            Cards[2] = new Bitmap(WindowsFormsApplication2.Properties.Resources._2);
            Cards[3] = new Bitmap(WindowsFormsApplication2.Properties.Resources._3);
            Cards[4] = new Bitmap(WindowsFormsApplication2.Properties.Resources._4);
            Cards[5] = new Bitmap(WindowsFormsApplication2.Properties.Resources._5);
            Cards[6] = new Bitmap(WindowsFormsApplication2.Properties.Resources._6);
            Cards[7] = new Bitmap(WindowsFormsApplication2.Properties.Resources._7);
            Cards[8] = new Bitmap(WindowsFormsApplication2.Properties.Resources._8);
            Cards[9] = new Bitmap(WindowsFormsApplication2.Properties.Resources._9);
            Cards[10] = new Bitmap(WindowsFormsApplication2.Properties.Resources._10);
            Cards[11] = new Bitmap(WindowsFormsApplication2.Properties.Resources._11);
            Cards[12] = new Bitmap(WindowsFormsApplication2.Properties.Resources._12);
            Cards[13] = new Bitmap(WindowsFormsApplication2.Properties.Resources._13);
            Cards[14] = new Bitmap(WindowsFormsApplication2.Properties.Resources._14);
            Cards[15] = new Bitmap(WindowsFormsApplication2.Properties.Resources._15);
            Cards[16] = new Bitmap(WindowsFormsApplication2.Properties.Resources._16);
            Cards[17] = new Bitmap(WindowsFormsApplication2.Properties.Resources._17);
            Cards[18] = new Bitmap(WindowsFormsApplication2.Properties.Resources._18);
            Cards[19] = new Bitmap(WindowsFormsApplication2.Properties.Resources._19);
            Cards[20] = new Bitmap(WindowsFormsApplication2.Properties.Resources._20);
            Cards[21] = new Bitmap(WindowsFormsApplication2.Properties.Resources._21);
            Cards[22] = new Bitmap(WindowsFormsApplication2.Properties.Resources._22);
            Cards[23] = new Bitmap(WindowsFormsApplication2.Properties.Resources._23);
            Cards[24] = new Bitmap(WindowsFormsApplication2.Properties.Resources._24);
            Cards[25] = new Bitmap(WindowsFormsApplication2.Properties.Resources._25);
            Cards[26] = new Bitmap(WindowsFormsApplication2.Properties.Resources._26);
            Cards[27] = new Bitmap(WindowsFormsApplication2.Properties.Resources._27);
            Cards[28] = new Bitmap(WindowsFormsApplication2.Properties.Resources._28);
            Cards[29] = new Bitmap(WindowsFormsApplication2.Properties.Resources._29);
            Cards[30] = new Bitmap(WindowsFormsApplication2.Properties.Resources._30);
            Cards[31] = new Bitmap(WindowsFormsApplication2.Properties.Resources._31);
            Cards[32] = new Bitmap(WindowsFormsApplication2.Properties.Resources._32);
            Cards[33] = new Bitmap(WindowsFormsApplication2.Properties.Resources._33);
            Cards[34] = new Bitmap(WindowsFormsApplication2.Properties.Resources._34);
            Cards[35] = new Bitmap(WindowsFormsApplication2.Properties.Resources._35);
            Cards[36] = new Bitmap(WindowsFormsApplication2.Properties.Resources._36);
            Cards[37] = new Bitmap(WindowsFormsApplication2.Properties.Resources._37);
            Cards[38] = new Bitmap(WindowsFormsApplication2.Properties.Resources._38);
            Cards[39] = new Bitmap(WindowsFormsApplication2.Properties.Resources._39);
            Cards[40] = new Bitmap(WindowsFormsApplication2.Properties.Resources._40);
            Cards[41] = new Bitmap(WindowsFormsApplication2.Properties.Resources._41);
            Cards[42] = new Bitmap(WindowsFormsApplication2.Properties.Resources._42);
            Cards[43] = new Bitmap(WindowsFormsApplication2.Properties.Resources._43);
            Cards[44] = new Bitmap(WindowsFormsApplication2.Properties.Resources._44);
            Cards[45] = new Bitmap(WindowsFormsApplication2.Properties.Resources._45);
            Cards[46] = new Bitmap(WindowsFormsApplication2.Properties.Resources._46);
            Cards[47] = new Bitmap(WindowsFormsApplication2.Properties.Resources._47);
            Cards[48] = new Bitmap(WindowsFormsApplication2.Properties.Resources._48);
            Cards[49] = new Bitmap(WindowsFormsApplication2.Properties.Resources._49);
            Cards[50] = new Bitmap(WindowsFormsApplication2.Properties.Resources._50);
            Cards[51] = new Bitmap(WindowsFormsApplication2.Properties.Resources._51);
            Cards[52] = new Bitmap(WindowsFormsApplication2.Properties.Resources._52);
            Cards[53] = new Bitmap(WindowsFormsApplication2.Properties.Resources._0);

            
            pictureBox1.Image = Cards[0];
            pictureBox2.Image = Cards[0];
            pictureBox3.Image = Cards[0];
            pictureBox4.Image = Cards[0];
            pictureBox5.Image = Cards[0];
            pictureBox6.Image = Cards[0];
            pictureBox7.Image = Cards[0];
            pictureBox8.Image = Cards[0];
            pictureBox9.Image = Cards[0];
            pictureBox10.Image = Cards[0];
            pictureBox11.Image = Cards[0];
            pictureBox12.Image = Cards[0];

            label7.Text = playerMoney.ToString();
            label8.Text = betting.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Card c = new Card();
            int[] DealerCard = new int[10];
            int[] PlayerCard = new int[10];

            var form2 = new Form2();           //Console.Write("얼마를 베팅하시겠습니까? (5,10,20)");//베팅 (5, 10, 20)
            form2.ShowDialog();                //betting = int.Parse(Console.ReadLine())
            betting = form2.Betting;           //Console.Clear();

            c.Shuffle(); //카드 셔플

            DealerCard[0] = c.deck[0];
            DealerCard[1] = c.deck[1];//딜러카드 두장 분배, 플레이어 카드 두장 분배
            PlayerCard[0] = c.deck[2];
            PlayerCard[1] = c.deck[3];

            int DealerCardSum = 0;
            int PlayerCardSum = 0;

            DealerCardSum = c.CardValue(DealerCard[0]) + c.CardValue(DealerCard[1]);
            PlayerCardSum = c.CardValue(PlayerCard[0]) + c.CardValue(PlayerCard[1]);

            ShowBeforeStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting); //게임 화면

            //MessageBox.Show(String.Format("       Dealer Busted! You get ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "WIN", MessageBoxButtons.OK); 
            if (c.CardValue(PlayerCard[0]) == 1 && c.CardValue(PlayerCard[1]) == 10) //if 플레이어가 블랙잭인가? (a + j,q,k)
            {
                if (c.CardValue(DealerCard[0]) == 1 && c.CardValue(DealerCard[1]) == 10)  //if (딜러가 블랙잭)   
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show("Draw! Press 'New Game' button.","Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);  //Draw!  이라고 표시하고 으로 간다.
                    betting = 0;
                    PlayerCardSum = 21;
                    DealerCardSum = 21;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    goto END;  // 블랙잭일 경우 코드의 맨 마지막에 또다시 승패판정을 하는데, 그걸 막기 위해 전체 For문을 돌리는 것이 비효율적이고 오히려 코드를 복잡하게 만든다고 판단하여 goto문 사용.
                }
                if (c.CardValue(DealerCard[0]) == 10 && c.CardValue(DealerCard[1]) == 1)  //if (딜러가 블랙잭)   
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show("Draw! Press 'New Game' button.", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);  //Draw!  이라고 표시하고 으로 간다.
                    betting = 0;
                    PlayerCardSum = 21;
                    DealerCardSum = 21;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    goto END;
                }
                else //else (플레이어 윈(playerMonye = playerMoney + betting *2))
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show(String.Format("     You Win! You get ${0}!! (X2 Blackjack Bonus)\n                Press 'New Game' button.", (betting * 2).ToString()), "WIN", MessageBoxButtons.OK);  //Draw!  이라고 표시하고 으로 간다.
                    
                    playerMoney = playerMoney + betting * 2;
                    betting = 0;
                    PlayerCardSum = 21;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    goto END;
                }
            }
            if (c.CardValue(PlayerCard[0]) == 10 && c.CardValue(PlayerCard[1]) == 1)
            {
                if (c.CardValue(DealerCard[0]) == 1 && c.CardValue(DealerCard[1]) == 10)  //if (딜러가 블랙잭)   
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show("Draw! Press 'New Game' button.", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);  //Draw!  이라고 표시하고 으로 간다.
                    betting = 0;
                    PlayerCardSum = 21;
                    DealerCardSum = 21;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    goto END;
                }
                if (c.CardValue(DealerCard[0]) == 10 && c.CardValue(DealerCard[1]) == 1)  //if (딜러가 블랙잭)   
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show("Draw! Press 'New Game' button.", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);  //Draw!  이라고 표시하고 으로 간다.
                    betting = 0;
                    PlayerCardSum = 21;
                    DealerCardSum = 21;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    goto END;
                }
                else //else (플레이어 윈(playerMonye = playerMoney + betting *2))
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show(String.Format("     You Win! You get ${0}!! (X2 Blackjack Bonus)\n                Press 'New Game' button.", (betting * 2).ToString()), "WIN", MessageBoxButtons.OK);  //Draw!  이라고 표시하고 으로 간다.
                    playerMoney = playerMoney + betting * 2;
                    betting = 0;
                    PlayerCardSum = 21;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    goto END;
                }
            }
            else //else (블랙잭 아니면)
            {
                while (DealerCardSum < 21 && PlayerCardSum < 21)  // while (딜러랑 플레이어 카드의 합이 < 21)
                {
                    int CardCount = 4; // 초반에 네장을 이미나눠줬으므로
                    int dealerturn = 1;
                    int playerturn = 1;

                   
                    while (PlayerCardSum < 21 )  // hit or stand 를 플레이어가 원할때까지 진행
                    {
                        var hitOrStand = new HitOrStand();           //Hit 이면 1값, Stand 이면 2값 반환.
                        hitOrStand.ShowDialog();                
                        int hitStand = hitOrStand.hitStand;

                        if (hitStand == 1)// HIt 이면 플레이어 카드 한장 더 분배 (스위치대신 그냥 if로 함)
                        {
                            ShowBeforeStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                            playerturn++;    //힛이 진행될때마다 턴 상승
                            PlayerCard[playerturn] = c.deck[CardCount];
                            CardCount++;
                            PlayerCardSum += c.CardValue(PlayerCard[playerturn]);
                            ShowBeforeStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                        }
                        else //stand
                        {
                            break;
                        }
                    }
                    if (PlayerCardSum > 21)
                    {
                        break;
                    }
                        
                    int DealerAce = AceCheck(DealerCard);  // 여기서부터 딜러카드 체크
                    DealerCardSum += DealerAce * 10; // 블랙잭 룰 : 딜러의 에이스는 무조건 11로 친다
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);

                    while (DealerCardSum <= 16) //while (딜러 카드 <= 16)
                    {
                        ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                        dealerturn++;          // 딜러 카드 한장 더 분배 (딜레이필요)
                        MessageBox.Show("Dealer gets 1 more card\nbecause ths sum of dealer's cards are under 16.");
                        DealerCard[dealerturn] = c.deck[CardCount];
                        DealerAce = AceCheck(DealerCard); // 다시 딜러의 에이스 총 숫자 파악
                        DealerCardSum += c.CardValue(DealerCard[dealerturn]) + DealerAce * 10;
                        CardCount++;
                        ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    }
                    if (DealerCardSum > 21) // while문 돌다 나와서 딜러 카드 > 21
                    {
                        ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                        MessageBox.Show(String.Format("     Dealer Busted! You get ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "WIN", MessageBoxButtons.OK); // Dealer busted! 표시하고 플레이어 돈 베팅한만큼 + 하고 베팅금액 초기화
                        playerMoney += betting;           
                        betting = 0;
                        ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                        break;
                    }
                    break;
                }
            }

            if (PlayerCardSum > 21)  // (와일 문 빠져나와서) if 플레이어 카드 > 21 
            {
                ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                MessageBox.Show(String.Format("         You Busted! You lose ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "LOSE", MessageBoxButtons.OK); // Dealer busted! 표시하고 플레이어 돈 베팅한만큼 + 하고 베팅금액 초기화
                playerMoney -= betting;
                betting = 0;
                ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
            }

            else // else (둘다 21 이하일경우)
            {
                ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                int PlayerAce = AceCheck(PlayerCard);
                if (PlayerAce != 0) //플레이어가 Ace를 한장 이상 가지고 있고
                {
					if (PlayerCardSum + 10 < 22)  // 그 에이스를 11로 써도 버스티드 되지 않으면 그 에이스를 11로 쓴다 (알아보기 쉽게 일부러 && 로 하지 않고 이중 if문 사용)
                    {
                        MessageBox.Show("One of your 'ACE' cards will be used as '11'");
                        PlayerCardSum += 10;
                        ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    }
                }
                if (PlayerCardSum > DealerCardSum)  //if 플레이어 카드 > 딜러카드 
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show(String.Format("             You Win! You get ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "WIN", MessageBoxButtons.OK);  // Player win! 표시하고 플레이어 돈 베팅한만큼 + 하고 베팅금액 초기화
                    playerMoney += betting;
                    betting = 0;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                }
                if (DealerCardSum > PlayerCardSum && DealerCardSum < 22)   // else if 딜러카드 > 플레이어카드 (딜러가 버스티드 되지 않았으면서 커야함)
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show(String.Format("           You Lose! You lose ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "LOSE", MessageBoxButtons.OK);// Dealer win! 표시하고 플레이어 돈 베팅한만큼 - 하고 베팅금액 초기화
                    playerMoney -= betting;
                    betting = 0;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                }
                if (DealerCardSum == PlayerCardSum)   // else (비긴경우)
                {
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                    MessageBox.Show("Draw! Press 'New Game' button.", "Draw", MessageBoxButtons.OK);
                    betting = 0;
                    ShowAfterStand(DealerCard, DealerCardSum, PlayerCard, PlayerCardSum, playerMoney, betting);
                }
            }
        END:
            betting = 0;
        }

        private void ShowBeforeStand(int[] DealerCard, int DealerCardSum, int[] PlayerCard, int PlayerCardSum, int PlayerMoney, int Betting)
        {
            pictureBox1.Image = Cards[DealerCard[0]];
            pictureBox2.Image = Cards[53];
            pictureBox3.Image = Cards[DealerCard[3]];
            pictureBox4.Image = Cards[DealerCard[4]];
            pictureBox5.Image = Cards[DealerCard[5]];
            pictureBox6.Image = Cards[DealerCard[6]];
            pictureBox7.Image = Cards[PlayerCard[0]];
            pictureBox8.Image = Cards[PlayerCard[1]];
            pictureBox9.Image = Cards[PlayerCard[2]];
            pictureBox10.Image = Cards[PlayerCard[3]];
            pictureBox11.Image = Cards[PlayerCard[4]];
            pictureBox12.Image = Cards[PlayerCard[5]];
            label7.Text = PlayerMoney.ToString();
            label8.Text = Betting.ToString();
            label9.Text = "?";
            label10.Text = PlayerCardSum.ToString();
        }

        private void ShowAfterStand(int[] DealerCard, int DealerCardSum, int[] PlayerCard, int PlayerCardSum, int PlayerMoney, int Betting)
        {
            pictureBox1.Image = Cards[DealerCard[0]];
            pictureBox2.Image = Cards[DealerCard[1]];
            pictureBox3.Image = Cards[DealerCard[2]];
            pictureBox4.Image = Cards[DealerCard[3]];
            pictureBox5.Image = Cards[DealerCard[4]];
            pictureBox6.Image = Cards[DealerCard[5]];
            pictureBox7.Image = Cards[PlayerCard[0]];
            pictureBox8.Image = Cards[PlayerCard[1]];
            pictureBox9.Image = Cards[PlayerCard[2]];
            pictureBox10.Image = Cards[PlayerCard[3]];
            pictureBox11.Image = Cards[PlayerCard[4]];
            pictureBox12.Image = Cards[PlayerCard[5]];
            label7.Text = PlayerMoney.ToString();
            label8.Text = Betting.ToString();
            label9.Text = DealerCardSum.ToString();
            label10.Text = PlayerCardSum.ToString();
        }

        public static int AceCheck(int[] Card)
        {
            int numOfAce = 0;
            for (int i = 0; i < 9; i++)
            {
                if (Card[i] == 1 || Card[i] == 14 || Card[i] == 27 || Card[i] == 40)
                {
                    numOfAce++;
                }
            }
            return numOfAce;
        }
    }
}
