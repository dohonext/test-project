using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        int sum = 0;
        int last_result = 0;
        List<string> digits = new List<string>();


        public void showFomula()
        {
            textBox_fomula.Text = "";
            foreach(string i in digits) {
                
                textBox_fomula.Text += i;
            }
        }

        public void showSum()
        {
            textBox_fomula.Text = sum.ToString();
        }


        public void inputNum(string n)
        {
            digits.Add(n);
            showFomula();
        }

        public void plus()
        {
            digits.Add("+");
            showFomula();
            sum = last_result;
        }

        public Calculator()
        {
            InitializeComponent();
            showFomula();
        }


        private void buttun_0_Click(object sender, EventArgs e)
        {
            inputNum("0");
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            inputNum("1");
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            inputNum("2");
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            inputNum("3");
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            inputNum("4");
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            inputNum("5");
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            inputNum("6");
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            inputNum("7");
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            inputNum("8");
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            inputNum("9");
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            plus();
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            string fomula = "";
            foreach (string i in digits)
            {
                fomula += i;
            }

            
            string[] sNum = fomula.Split('+');
            foreach (string i in sNum)
            {
                try
                {
                    sum += int.Parse(i);
                }
                catch
                {
                }
            }

            last_result = sum;
            
            showSum();
            sum = 0;
            digits.Clear();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            last_result = 0;
            sum = 0;
            digits.Clear();
            showFomula();
        }



    }
}
