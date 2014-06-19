using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Betting : Form
    {
        
        public int Bet
        {
            get;
            set;
        }

        public Betting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Bet = 10;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Bet = 20;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Bet = 40;
            this.Close();
        }

        private void Betting_Load(object sender, EventArgs e)
        {

        }
    }
}
