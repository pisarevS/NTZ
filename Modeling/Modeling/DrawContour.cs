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
        private Point coordinateZero;
        private Pen pen;
        private Pen pen2;

        public DrawContour(PictureBox pictureBox1, Point coordinateZero)
        {
            this.pictureBox1 = pictureBox1;
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(img);
            pen = new Pen(Color.Black);
            pen2 = new Pen(Brushes.Gray);
            this.coordinateZero = new Point();
            pictureBox1.Image = img;
            this.coordinateZero.X = pictureBox1.Width / 2;
            this.coordinateZero.Z = pictureBox1.Height / 2;
        }

        public void SystemСoordinate(PictureBox pictureBox1, Point coordinateZero)
        {
            pen2.DashStyle = DashStyle.Dash;
            graphics.DrawLine(pen2, coordinateZero.X, 0, coordinateZero.X, pictureBox1.Height); //горизонтальная
            graphics.DrawLine(pen2, 0, coordinateZero.Z, pictureBox1.Width, coordinateZero.Z); //вертикальная
        }

        public void DrawLine(Point coordinateZero, double zoom, Point startPoint, Point endPoint)
        {
            startPoint.X = Convert.ToInt32(startPoint.X * zoom);
            startPoint.Z = Convert.ToInt32(startPoint.Z * zoom);
            endPoint.X = Convert.ToInt32(endPoint.X * zoom);
            endPoint.Z = Convert.ToInt32(endPoint.Z * zoom);
            if (startPoint.Z > 0) startPoint.Z = coordinateZero.Z - startPoint.Z;
            else startPoint.Z = coordinateZero.Z + Math.Abs(startPoint.Z);
            if (endPoint.Z > 0) endPoint.Z = coordinateZero.Z - endPoint.Z;
            else endPoint.Z = coordinateZero.Z + Math.Abs(endPoint.Z);

            graphics.DrawLine(pen, coordinateZero.X + startPoint.X, startPoint.Z, coordinateZero.X + endPoint.X, endPoint.Z);
        }

        public void DrawArc(Point coordinateZero, double zoom, int radius)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = coordinateZero.X + 100;
            rectangle.Y = coordinateZero.Z + 100;
            rectangle.Width = 50;
            rectangle.Height = 50;
            graphics.DrawArc(pen, rectangle, 0, 90);
        }
    }
}

