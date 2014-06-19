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
        Card cardpic = new Card();
        int playerMoney = 100;
        int betting = 0;

        public Form1()
        {
            InitializeComponent();
            FirstShow(playerMoney, betting);       //초기화면 표시
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Card c = new Card();
            c.DealerCard = new int[10];
            c.PlayerCard = new int[10];
            c.DealerCardSum = 0;
            c.PlayerCardSum = 0;

            var form2 = new Betting();                      //Console.Write("얼마를 베팅하시겠습니까? (5,10,20)");//베팅 (5, 10, 20)
            form2.StartPosition = FormStartPosition.Manual; //새 폼 뜨는 위치 화면 안가리게
            form2.Left = 500;
            form2.Top = 500;             
            form2.ShowDialog();                              
            betting = form2.Bet;                            //betting = int.Parse(Console.ReadLine())

            c.Shuffle();                                    //카드 셔플
            c.First2CardsDistribute();                      //최초 카드 두장씩 분배
            c.FirstSum();                                   //최초 카드 두장의 합계

            ShowBeforeStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);   //스탠드 하기 전 게임화면 표시
            //int test = 0;
            //ChangeTest(ref test);
            //MessageBox.Show(String.Format("{0}", (test).ToString()), "WIN", MessageBoxButtons.OK);

            if (c.CardValue[c.PlayerCard[0]] == 1 && c.CardValue[c.PlayerCard[1]] == 10 || c.CardValue[c.PlayerCard[0]] == 10 && c.CardValue[c.PlayerCard[1]] == 1)                           //if 플레이어가 블랙잭인가? (a + j,q,k)
            {
                if (c.CardValue[c.DealerCard[0]] == 1 && c.CardValue[c.DealerCard[1]] == 10 || c.CardValue[c.DealerCard[0]] == 10 && c.CardValue[c.DealerCard[1]] == 1)                       //if (딜러가 블랙잭)   
                {
                    c.PlayerCardSum = 21;
                    c.DealerCardSum = 21;
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                    MessageBox.Show("Draw! Press 'New Game' button.","Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);  //Draw!  이라고 표시하고 끝으로 간다.
                    betting = 0;
                    goto END;  // 맨 마지막에 승패판정을 하는데, 블랙잭일 경우 이미 승패가 확정되므로 그걸 막기 위해 전체 For문을 돌리는 것이 비효율적이고 오히려 코드를 복잡하게 만든다고 판단하여 goto문 사용.
                }
                else //else (플레이어 윈(playerMonye = playerMoney + betting *2))
                {
                    c.PlayerCardSum = 21;
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                    MessageBox.Show(String.Format("   Black Jack! You get ${0}!! (X2 Blackjack Bonus)\n                Press 'New Game' button.", (betting * 2).ToString()), "WIN", MessageBoxButtons.OK);  //Draw!  이라고 표시하고 으로 간다.
                    playerMoney = playerMoney + betting * 2;
                    betting = 0;
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                    goto END;
                }
            }
            else //else (블랙잭 아니면)
            {
                while (c.DealerCardSum < 21 && c.PlayerCardSum < 21)  // while (딜러랑 플레이어 카드의 합이 < 21)
                {
                    int CardCount = 4; // 초반에 네장을 이미나눠줬으므로
                    int dealerturn = 1;
                    int playerturn = 1;

                   
                    while (c.PlayerCardSum < 21 )  // hit or stand 를 플레이어가 원할때까지 진행
                    {
                        var hitOrStand = new HitOrStand();           //Hit 이면 1값, Stand 이면 2값 반환.
                        hitOrStand.StartPosition = FormStartPosition.Manual;
                        hitOrStand.Left = 750;
                        hitOrStand.Top = 500;
                        hitOrStand.ShowDialog();                
                        int hitStand = hitOrStand.hitStand;

                        if (hitStand == 1)// HIt 이면 플레이어 카드 한장 더 분배 (스위치대신 그냥 if로 함)
                        {
                            ShowBeforeStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                            playerturn++;    //힛이 진행될때마다 턴 상승
                            c.PlayerCard[playerturn] = c.deck[CardCount];
                            CardCount++;
                            c.PlayerCardSum += c.CardValue[c.PlayerCard[playerturn]];
                            ShowBeforeStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                        }
                        else //stand
                        {
                            break;
                        }
                    }
                    if (c.PlayerCardSum > 21)
                    {
                        break;
                    }
                        
                    int DealerAce = AceCheck(c.DealerCard);  // 여기서부터 딜러카드 체크
                    int DealerAceCheck = 0;
                    c.DealerCardSum += DealerAce * 10; // 블랙잭 룰 : 딜러의 에이스는 무조건 11로 친다
                    if (DealerAce != 0)
                    {
                        DealerAceCheck = DealerAce;  // 초기 두장 말고 나중에 또 딜러가 Ace를 받으면 중복계산을 막기 위해.
                    }
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);

                    while (c.DealerCardSum <= 16) //while (딜러 카드 <= 16)
                    {
                        ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                        dealerturn++;          // 딜러 카드 한장 더 분배 (딜레이필요)
                        MessageBox.Show("Dealer gets 1 more card\nbecause ths sum of dealer's cards are under 16.");
                        c.DealerCard[dealerturn] = c.deck[CardCount];
                        DealerAce = AceCheck(c.DealerCard); // 다시 딜러의 에이스 총 숫자 파악
                        c.DealerCardSum += c.CardValue[c.DealerCard[dealerturn]] + DealerAce * 10 - DealerAceCheck * 10; //나중에 받아서 더해진 에이스 중복계산 막기 위해.
                        CardCount++;
                        ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                    }
                    if (c.DealerCardSum > 21) // while문 돌다 나와서 딜러 카드 > 21
                    {
                        ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                        MessageBox.Show(String.Format("     Dealer Busted! You get ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "WIN", MessageBoxButtons.OK); // Dealer busted! 표시하고 플레이어 돈 베팅한만큼 + 하고 베팅금액 초기화
                        playerMoney += betting;           
                        betting = 0;
                        ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                        break;
                    }
                    break;
                }
            }

            if (c.PlayerCardSum > 21)  // (와일 문 빠져나와서) if 플레이어 카드 > 21 
            {
                ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                MessageBox.Show(String.Format("         You Busted! You lose ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "LOSE", MessageBoxButtons.OK); // Dealer busted! 표시하고 플레이어 돈 베팅한만큼 + 하고 베팅금액 초기화
                playerMoney -= betting;
                betting = 0;
                ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
            }
            else // else (둘다 21 이하일경우)
            {
                ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                int PlayerAce = AceCheck(c.PlayerCard);
                if (PlayerAce != 0) //플레이어가 Ace를 한장 이상 가지고 있고
                {
                    if (c.PlayerCardSum + 10 < 22)  // 그 에이스를 11로 써도 버스티드 되지 않으면 그 에이스를 11로 쓴다 (알아보기 쉽게 일부러 && 로 하지 않고 이중 if문 사용)
                    {
                        MessageBox.Show("One of your 'ACE' cards will be used as '11'");
                        c.PlayerCardSum += 10;
                        ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                    }
                }
                if (c.PlayerCardSum > c.DealerCardSum)  //if 플레이어 카드 > 딜러카드 
                {
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                    MessageBox.Show(String.Format("             You Win! You get ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "WIN", MessageBoxButtons.OK);  // Player win! 표시하고 플레이어 돈 베팅한만큼 + 하고 베팅금액 초기화
                    playerMoney += betting;
                    betting = 0;
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                }
                if (c.DealerCardSum > c.PlayerCardSum && c.DealerCardSum < 22)   // else if 딜러카드 > 플레이어카드 (딜러가 버스티드 되지 않았으면서 커야함)
                {
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                    MessageBox.Show(String.Format("           You Lose! You lose ${0}!!\n         Press 'New Game' button.", (betting).ToString()), "LOSE", MessageBoxButtons.OK);// Dealer win! 표시하고 플레이어 돈 베팅한만큼 - 하고 베팅금액 초기화
                    playerMoney -= betting;
                    betting = 0;
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                }
                if (c.DealerCardSum == c.PlayerCardSum)   // else (비긴경우)
                {
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                    MessageBox.Show("Draw! Press 'New Game' button.", "Draw", MessageBoxButtons.OK);
                    betting = 0;
                    ShowAfterStand(c.DealerCard, c.DealerCardSum, c.PlayerCard, c.PlayerCardSum, playerMoney, betting);
                }
            }
        END:
            betting = 0;
        }

        public void FirstShow(int PlayerMoney, int Betting)
        {
            pictureBox1.Image = cardpic.Cards[0];
            pictureBox2.Image = cardpic.Cards[0];
            pictureBox3.Image = cardpic.Cards[0];
            pictureBox4.Image = cardpic.Cards[0];
            pictureBox5.Image = cardpic.Cards[0];
            pictureBox6.Image = cardpic.Cards[0];
            pictureBox7.Image = cardpic.Cards[0];
            pictureBox8.Image = cardpic.Cards[0];
            pictureBox9.Image = cardpic.Cards[0];
            pictureBox10.Image = cardpic.Cards[0];
            pictureBox11.Image = cardpic.Cards[0];
            pictureBox12.Image = cardpic.Cards[0];
            label7.Text = playerMoney.ToString();
            label8.Text = betting.ToString();
            label9.Text = "0";
            label10.Text = "0";
        }

        public void ShowBeforeStand(int[] DealerCard, int DealerCardSum, int[] PlayerCard, int PlayerCardSum, int PlayerMoney, int Betting)
        {
            pictureBox1.Image = cardpic.Cards[DealerCard[0]];
            pictureBox2.Image = cardpic.Cards[53];
            pictureBox3.Image = cardpic.Cards[DealerCard[3]];
            pictureBox4.Image = cardpic.Cards[DealerCard[4]];
            pictureBox5.Image = cardpic.Cards[DealerCard[5]];
            pictureBox6.Image = cardpic.Cards[DealerCard[6]];
            pictureBox7.Image = cardpic.Cards[PlayerCard[0]];
            pictureBox8.Image = cardpic.Cards[PlayerCard[1]];
            pictureBox9.Image = cardpic.Cards[PlayerCard[2]];
            pictureBox10.Image = cardpic.Cards[PlayerCard[3]];
            pictureBox11.Image = cardpic.Cards[PlayerCard[4]];
            pictureBox12.Image = cardpic.Cards[PlayerCard[5]];
            label7.Text = PlayerMoney.ToString();
            label8.Text = Betting.ToString();
            label9.Text = "?";
            label10.Text = PlayerCardSum.ToString();
        }

        public void ShowAfterStand(int[] DealerCard, int DealerCardSum, int[] PlayerCard, int PlayerCardSum, int PlayerMoney, int Betting)
        {
            pictureBox1.Image = cardpic.Cards[DealerCard[0]];
            pictureBox2.Image = cardpic.Cards[DealerCard[1]];
            pictureBox3.Image = cardpic.Cards[DealerCard[2]];
            pictureBox4.Image = cardpic.Cards[DealerCard[3]];
            pictureBox5.Image = cardpic.Cards[DealerCard[4]];
            pictureBox6.Image = cardpic.Cards[DealerCard[5]];
            pictureBox7.Image = cardpic.Cards[PlayerCard[0]];
            pictureBox8.Image = cardpic.Cards[PlayerCard[1]];
            pictureBox9.Image = cardpic.Cards[PlayerCard[2]];
            pictureBox10.Image = cardpic.Cards[PlayerCard[3]];
            pictureBox11.Image = cardpic.Cards[PlayerCard[4]];
            pictureBox12.Image = cardpic.Cards[PlayerCard[5]];
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

        //public static void ChangeTest(ref int test)
        //{
        //    test = 10;
        //}
    }
}
