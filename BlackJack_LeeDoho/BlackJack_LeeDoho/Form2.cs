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
    public partial class Form2 : Form
    {
        public int Betting
        {
            get;
            set;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Betting = 5;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Betting = 10;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Betting = 20;
            this.Close();
        }


    }
}
