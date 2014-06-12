using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace GUIRectangle
{
    public partial class Form1 : Form
    {
        Rectangle[] rectangles = new Rectangle[2] 
            {
                new Rectangle(10, 10, 100, 100),
                new Rectangle(40, 40, 50, 50)
            };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                foreach (Rectangle rectangle in rectangles)
                {
                    rectangle.Show(g); //show에 매개변수를 적는다

                }
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
         
            Random random = new Random();
            int left    = random.Next(1, 100);
            int top     = random.Next(1, 100);
            int right   = random.Next(200, 300);
            int bottom  = random.Next(200, 300);

            Rectangle rectangle =  new Rectangle(left, top, right, bottom);

            if (rectangles.Length == 1)
            {
                rectangles[0] = rectangle;
            } if (rectangles.Length == 2)
            {
                rectangles[1] = rectangle;
            }
            if (rectangles.Length > 2)
            {
                Rectangle[] newArray = new Rectangle[rectangles.Length + 1];
                newArray[0] = rectangles[0];
                Array.Copy(rectangles, 1, newArray, 2, rectangles.Length-2);
                newArray[1] = rectangle;
               
            }

            
           
     
            Form1_Paint(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}