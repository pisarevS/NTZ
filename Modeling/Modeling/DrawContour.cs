using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modeling
{
    internal class DrawContour : IDraw
    {
        private PictureBox pictureBox1;
        private Bitmap img;
        private Graphics graphics;
        private Point point;
        private Pen pen;
        private Pen pen2;


        public DrawContour(PictureBox pictureBox1, Point point)
        {
           // this.point.X = point.X;
            //this.point.Y = point.Y;
            this.pictureBox1 = pictureBox1;
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(img);
            pen = new Pen(Color.Black);
            pen2 = new Pen(Brushes.Black);
            point = new Point();
            pictureBox1.Image = img;
            point.X = pictureBox1.Width / 2;
            point.Y = pictureBox1.Height / 2;
        }

        public void SystemСoordinate(PictureBox pictureBox1, Point point)
        {
            pen2.DashStyle = DashStyle.Dash;
            graphics.DrawLine(pen2, point.X, 0, point.X, pictureBox1.Height); //горизонтальная
            graphics.DrawLine(pen2, 0, point.Y, pictureBox1.Width, point.Y); //вертикальная
        }

        public void DrawLine(Point startPoint, Point endPoint)
        {
            if (startPoint.Y > 0) { startPoint.Y = -startPoint.Y; } else if (startPoint.Y < 0) { startPoint.Y = +startPoint.Y; }
            if (endPoint.Y > 0) { endPoint.Y = -endPoint.Y; } else if (endPoint.Y < 0) { endPoint.Y = +endPoint.Y; }

            graphics.DrawLine(pen, startPoint.X + point.X, startPoint.Y + point.Y, endPoint.X + point.X, endPoint.Y + point.Y);
        }

        public void DrawArc(Point point)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = point.X + 100;
            rectangle.Y = point.Y + 100;
            rectangle.Width = 50;
            rectangle.Height = 50;
            graphics.DrawArc(pen, rectangle, 0, 90);
        }
    }
}

