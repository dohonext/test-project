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
  
        private ArrayList rectangles = new ArrayList();
        private ArrayList squares = new ArrayList();
        private ArrayList circles = new ArrayList();
        private ArrayList triangles = new ArrayList();

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
                    rectangle.Show(g);
                }

                foreach (Square square in squares)
                {
                    square.Show(g);
                }

                foreach (Circle circle in circles)
                {
                    circle.Show(g);
                }

                foreach (Triangle triangle in triangles)
                {
                    triangle.Show(g);
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
            int width = random.Next(1, 200);
            int OneMoreRandomNumber = random.Next(1,200);

            Rectangle rectangle =  new Rectangle(left, top, right, bottom);
            Square square = new Square(left, top, width);
            Circle circle = new Circle(left, top, width);
            Triangle triangle = new Triangle(left, top, right, bottom, width, OneMoreRandomNumber);

            int figure = random.Next(0, 4);

            if (figure == 0)
            {
                rectangles.Add(rectangle);
            }
            else if (figure == 1)
            {
                squares.Add(square);
            }
            else if (figure == 2)
            {
                circles.Add(circle);
            }
            else if (figure == 3)
            {
                triangles.Add(triangle);
            }
                

            Form1_Paint(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}