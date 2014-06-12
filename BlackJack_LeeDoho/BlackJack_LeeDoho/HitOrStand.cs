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
    public partial class HitOrStand : Form
    {
        public int hitStand
        {
            get;
            set;
        }

        public HitOrStand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.hitStand = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.hitStand = 2;
            this.Close();
        }

        private void HitOrStand_Load(object sender, EventArgs e)
        {

        }
    }
}
