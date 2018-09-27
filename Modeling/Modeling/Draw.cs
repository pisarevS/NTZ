using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modeling
{
    internal class Draw : IDraw
    {
        private MyCollection myCollection;
        private PictureBox pictureBox1;
        private Bitmap img;
        private Graphics graphics;
        private Point coordinateZero;
        private Pen pen;
        private Pen pen2;

        public Draw(PictureBox pictureBox1, Point coordinateZero)
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

        public void DrawArcClockwise(Point coordinateZero, double zoom, double radius, Point startPoint, Point endPoint)
        {
            Point square = new Point();
            Rectangle rectangle = new Rectangle();
            startPoint.X = (int)(startPoint.X * zoom);
            startPoint.Z = (int)(startPoint.Z * zoom);
            endPoint.X = (int)(endPoint.X * zoom);
            endPoint.Z = (int)(endPoint.Z * zoom);
            radius = (int)(radius * zoom);
            float startAngle = 0;
            float sweepAngle = 0;
            int catet;
            double hord = Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Z - endPoint.Z, 2));
            double h = Math.Sqrt(radius * radius - (hord / 2) * (hord / 2));
            int x01 =(int) (startPoint.X + (endPoint.X - startPoint.X) / 2 + h * (endPoint.Z - startPoint.Z) / hord);
            int z01 =(int) (startPoint.Z + (endPoint.Z - startPoint.Z) / 2 - h * (endPoint.X - startPoint.X) / hord);
            if (startPoint.X > x01 && startPoint.Z >= z01)
            {
                catet =(int) (startPoint.X - x01);
                if (startPoint.Z == z01)
                {
                    startAngle = 0;
                }
                else { startAngle = (float)(360 - Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (startPoint.X >= x01 && startPoint.Z < z01)
            {
                catet =(int) (startPoint.X - x01);
                if (startPoint.X == x01)
                {
                    startAngle = 90;
                }
                else { startAngle = (float)(Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (startPoint.X < x01 && startPoint.Z <= z01)
            {
                catet =(int) (x01 - startPoint.X);
                if (startPoint.Z == z01)
                {
                    startAngle = 180;
                }
                else { startAngle = (float)(180 - Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (startPoint.X <= x01 && startPoint.Z > z01)
            {
                catet =(int) (x01 - startPoint.X);
                if (startPoint.X == x01)
                {
                    startAngle = 270;
                }
                else { startAngle = (float)(180 + Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            square.X = (int)(x01 - radius);
            square.Z = (int)(z01 + radius);
            sweepAngle = (float)(2 * Math.Asin(hord / (2 * radius)) * (180 / Math.PI));
            rectangle.X = (coordinateZero.X + square.X);
            rectangle.Y = (coordinateZero.Z - square.Z);
            rectangle.Width = (int)(radius * 2);
            rectangle.Height = (int)(radius * 2);
            graphics.DrawArc(pen, rectangle, startAngle, sweepAngle);
        }

        public void DrawArcCounterclockwise(Point coordinateZero, double zoom, double radius, Point startPoint, Point endPoint)
        {
            Point square = new Point();
            Rectangle rectangle = new Rectangle();
            startPoint.X = (int)(startPoint.X * zoom);
            startPoint.Z = (int)(startPoint.Z * zoom);
            endPoint.X = (int)(endPoint.X * zoom);
            endPoint.Z = (int)(endPoint.Z * zoom);
            radius = (int)(radius * zoom);
            float startAngle = 0;
            float sweepAngle = 0;
            int catet;
            double hord = Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Z - endPoint.Z, 2));
            double h = Math.Sqrt(radius * radius - (hord / 2) * (hord / 2));
            int x02 = (int)(startPoint.X + (endPoint.X - startPoint.X) / 2 - h * (endPoint.Z - startPoint.Z) / hord);
            int z02 = (int)(startPoint.Z + (endPoint.Z - startPoint.Z) / 2 + h * (endPoint.X - startPoint.X) / hord);
            if (endPoint.X > x02 && endPoint.Z >= z02)
            {
                catet =(int) (endPoint.X - x02);
                if (startPoint.Z == z02)
                {
                    startAngle = 0;
                }
                else { startAngle = (float)(360 - Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (endPoint.X >= x02 && endPoint.Z < z02)
            {
                catet =(int) (endPoint.X - x02);
                if (startPoint.X == x02)
                {
                    startAngle = 90;
                }
                else { startAngle = (float)(Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (endPoint.X < x02 && endPoint.Z <= z02)
            {
                catet =(int) (x02 - endPoint.X);
                if (startPoint.Z == z02)
                {
                    startAngle = 180;
                }
                else { startAngle = (float)(180 - Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (endPoint.X <= x02 && endPoint.Z > z02)
            {
                catet =(int) (x02 - endPoint.X);
                if (endPoint.X == x02)
                {
                    startAngle = 270;
                }
                else { startAngle = (float)(180 + Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            square.X = (int)(x02 - radius);
            square.Z = (int)(z02 + radius);
            sweepAngle = (float)(2 * Math.Asin(hord / (2 * radius)) * (180 / Math.PI));
            rectangle.X = (coordinateZero.X + square.X);
            rectangle.Y = (coordinateZero.Z - square.Z);
            rectangle.Width = (int)(radius * 2);
            rectangle.Height = (int)(radius * 2);
            graphics.DrawArc(pen, rectangle, startAngle, sweepAngle);
        }

        public void DrawСontour(Point coordinateZero, double zoom)
        {
            Point startPoint = new Point();
            Point endPoint = new Point();
            double radius = 50;
            myCollection = new MyCollection();
            startPoint.X = 120;
            startPoint.Z = 50;
            endPoint.X = 70;
            endPoint.Z = 100;
            DrawArcClockwise(coordinateZero, zoom, radius, startPoint, endPoint);
            startPoint.X = 120;
            startPoint.Z = 50;
            endPoint.X = 70;
            endPoint.Z = 100;
            DrawArcCounterclockwise(coordinateZero, zoom, radius, startPoint, endPoint);
            startPoint.X = 120;
            startPoint.Z = 50;
            endPoint.X = 120;
            endPoint.Z = 0;
            DrawLine(coordinateZero, zoom, startPoint, endPoint);
            startPoint.X = 70;
            startPoint.Z = 100;
            endPoint.X = 0;
            endPoint.Z = 100;
            DrawLine(coordinateZero, zoom, startPoint, endPoint);
        }
    }
}

