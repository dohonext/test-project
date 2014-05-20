using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GUIRectangle
{
    class Figure
    {
    }
     
    class Rectangle :Figure
    {
        protected Point LeftTop;
        protected Point RightBottom;

        public Rectangle() : this(0, 0)
        {
        }

        public Rectangle(int Left, int Top) : this(Left, Top, Left + 100, Top + 100)
        {
        }

        public Rectangle(int Left, int Top, int Right, int Bottom)
        {
            this.LeftTop = new Point(Left, Top);
            this.RightBottom = new Point(Right, Bottom);
        }

        public virtual void Show(Graphics g)
        {
          
        g.FillRectangle(Brushes. SkyBlue,
            LeftTop.X, LeftTop.Y,
            RightBottom.X - LeftTop.X, 
            RightBottom.Y - LeftTop.Y);

        g.DrawRectangle(Pens. Black,
            LeftTop.X, LeftTop.Y,
            RightBottom.X - LeftTop.X, 
            RightBottom.Y - LeftTop.Y);
    }
}

      
     class Square : Rectangle
     {
        private Brush Color;

        public Square(int Left, int Top, int Width) : base(Left, Top, Left + Width, Top + Width)
        {
            this.Color = Color;
        }

     

        public override void Show(Graphics g) 
            
     
        {
            g.FillRectangle(Brushes.SkyBlue,
           LeftTop.X, LeftTop.Y,
           RightBottom.X - LeftTop.X,
           RightBottom.Y - LeftTop.Y);

            g.DrawRectangle(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);  
        }
     }

    class Circle : Rectangle
    {
        public Circle(int Left, int Top, int Width)
            
        {
        }

        public override void Show(Graphics cir)
        {
            cir.DrawEllipse(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            cir.FillEllipse(Brushes.DarkGoldenrod,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
        }
    }

    class Triangle : Figure
    {
        private Point x;
        private Point y;
        private Point z;

        public Point[] Points = new Point[]{

           new Point (0,0),
           new Point (0,0),
           new Point (0,0)
        };

        public Triangle(int a, int b, int c, int d, int e, int f)
        {
            this.x = new Point(a, b);
            this.y = new Point(c, d);
            this.z = new Point(e, f);

            Points[0] = x;
            Points[1] = y;
            Points[2] = z;
        }


        public virtual void Show(Graphics tri)
        {
            tri.DrawPolygon(Pens.Black, Points);

            tri.FillPolygon(Brushes.CornflowerBlue, Points);
        }
    }



}
