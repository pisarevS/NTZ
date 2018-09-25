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

        public void DrawArc(Point coordinateZero, bool clockwise, double zoom, double radius, Point startPoint, Point endPoint)
        {    
            Point square = new Point();
            Rectangle rectangle = new Rectangle();
            startPoint.X = Convert.ToInt32(startPoint.X * zoom);
            startPoint.Z = Convert.ToInt32(startPoint.Z * zoom);
            endPoint.X = Convert.ToInt32(endPoint.X * zoom);
            endPoint.Z = Convert.ToInt32(endPoint.Z * zoom);
            radius = Convert.ToInt32(radius * zoom);    
            int startAngle = 0;
            int sweepAngle = 0;
            double catet;
            double hord = Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Z - endPoint.Z, 2));
            double h = Math.Sqrt(radius * radius - (hord / 2) * (hord / 2));
            if (clockwise)
            {
                double x01 = startPoint.X + (endPoint.X - startPoint.X) / 2 + h * (endPoint.Z - startPoint.Z) / hord;
                double z01 = startPoint.Z + (endPoint.Z - startPoint.Z) / 2 - h * (endPoint.X - startPoint.X) / hord;
                if (startPoint.X > x01 && startPoint.Z >= z01)
                {
                    catet = startPoint.X - x01;
                    if (startPoint.Z == z01)
                    {
                        startAngle = 0;
                    }
                    else { startAngle = Convert.ToInt32(360 - Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
               
                if (startPoint.X >= x01 && startPoint.Z < z01)
                {
                    catet = startPoint.X - x01;
                    if (startPoint.X == x01)
                    {
                        startAngle = 90;
                    }
                    else { startAngle = Convert.ToInt32(Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
               
                if (startPoint.X < x01 && startPoint.Z <= z01)
                {
                    catet =   x01- startPoint.X;
                    if (startPoint.Z == z01)
                    {
                        startAngle = 180;
                    }
                    else { startAngle = Convert.ToInt32(180 - Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
               
                if (startPoint.X <= x01 && startPoint.Z > z01)
                {
                    catet = x01 - startPoint.X;
                    if (startPoint.X == x01)
                    {
                        startAngle = 270;
                    }
                    else { startAngle = Convert.ToInt32(180 + Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                square.X = Convert.ToInt32(x01 - radius);
                square.Z = Convert.ToInt32(z01 + radius);
                sweepAngle = Convert.ToInt32(2 * Math.Asin(hord / (2 * radius)) * (180 / Math.PI));
                rectangle.X = Convert.ToInt32(coordinateZero.X + square.X);
                rectangle.Y = Convert.ToInt32(coordinateZero.Z - square.Z);
                rectangle.Width = Convert.ToInt32(radius * 2);
                rectangle.Height = Convert.ToInt32(radius * 2);
                graphics.DrawArc(pen, rectangle, startAngle, sweepAngle);
            }
            if (!clockwise)
            {
                double x02 = startPoint.X + (endPoint.X - startPoint.X) / 2 - h * (endPoint.Z - startPoint.Z) / hord;
                double z02 = startPoint.Z + (endPoint.Z - startPoint.Z) / 2 + h * (endPoint.X - startPoint.X) / hord;                
            }           
        }

        public void DrawСontour(Point coordinateZero, bool clockwise, double zoom, double radius, Point startPoint, Point endPoint)
        {
            myCollection = new MyCollection();
            startPoint.X = 70;
            startPoint.Z = 88;
            endPoint.X = 89;
            endPoint.Z = 62;
            DrawArc(coordinateZero,true, zoom,radius,startPoint,endPoint);
            startPoint.X = 20;
            startPoint.Z = 50;
            endPoint.X = 0;
            endPoint.Z = 50;
            DrawLine(coordinateZero, zoom, startPoint, endPoint);
        }
    }
}

