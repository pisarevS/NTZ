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

        public void DrawLine(Point coordinateZero, float zoom, Point startPoint, Point endPoint)
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

        public void DrawArcClockwise(Point coordinateZero, float zoom, float radius, Point startPoint, Point endPoint)
        {
            Point square = new Point();
            RectangleF rectangle = new RectangleF();
            startPoint.X = startPoint.X * zoom;
            startPoint.Z = startPoint.Z * zoom;
            endPoint.X = endPoint.X * zoom;
            endPoint.Z = endPoint.Z * zoom;
            radius = radius * zoom;
            float startAngle = 0;
            float sweepAngle = 0;
            float catet;
            float hord = (float)Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Z - endPoint.Z, 2));
            float h = (float)Math.Sqrt(radius * radius - (hord / 2) * (hord / 2));
            float x01 = (startPoint.X + (endPoint.X - startPoint.X) / 2 + h * (endPoint.Z - startPoint.Z) / hord);
            float z01 = (startPoint.Z + (endPoint.Z - startPoint.Z) / 2 - h * (endPoint.X - startPoint.X) / hord);
            if (startPoint.X > x01 && startPoint.Z >= z01)
            {
                catet = startPoint.X - x01;
                if (startPoint.Z == z01)
                {
                    startAngle = 0;
                }
                else { startAngle = (float)(360 - Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (startPoint.X >= x01 && startPoint.Z < z01)
            {
                catet = startPoint.X - x01;
                if (startPoint.X == x01)
                {
                    startAngle = 90;
                }
                else { startAngle = (float)(Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (startPoint.X < x01 && startPoint.Z <= z01)
            {
                catet = x01 - startPoint.X;
                if (startPoint.Z == z01)
                {
                    startAngle = 180;
                }
                else { startAngle = (float)(180 - Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (startPoint.X <= x01 && startPoint.Z > z01)
            {
                catet = x01 - startPoint.X;
                if (startPoint.X == x01)
                {
                    startAngle = 270;
                }
                else { startAngle = (float)(180 + Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            square.X = x01 - radius;
            square.Z = z01 + radius;
            sweepAngle = (float)(2 * Math.Asin(hord / (2 * radius)) * (180 / Math.PI));
            rectangle.X = coordinateZero.X + square.X;
            rectangle.Y = coordinateZero.Z - square.Z;
            rectangle.Width = radius * 2;
            rectangle.Height = radius * 2;
            graphics.DrawArc(pen, rectangle, startAngle, sweepAngle);
        }

        public void DrawArcCounterclockwise(Point coordinateZero, float zoom, float radius, Point startPoint, Point endPoint)
        {
            Point square = new Point();
            RectangleF rectangle = new RectangleF();
            startPoint.X = startPoint.X * zoom;
            startPoint.Z = startPoint.Z * zoom;
            endPoint.X = endPoint.X * zoom;
            endPoint.Z = endPoint.Z * zoom;
            radius = radius * zoom;
            float startAngle = 0;
            float sweepAngle = 0;
            float catet;
            float hord = (float)Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Z - endPoint.Z, 2));
            float h = (float)Math.Sqrt(radius * radius - (hord / 2) * (hord / 2));
            float x02 = startPoint.X + (endPoint.X - startPoint.X) / 2 - h * (endPoint.Z - startPoint.Z) / hord;
            float z02 = startPoint.Z + (endPoint.Z - startPoint.Z) / 2 + h * (endPoint.X - startPoint.X) / hord;
            if (endPoint.X > x02 && endPoint.Z >= z02)
            {
                catet = endPoint.X - x02;
                if (endPoint.Z == z02)
                {
                    startAngle = 0;
                }
                else { startAngle = (float)(360 - Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (endPoint.X >= x02 && endPoint.Z < z02)
            {
                catet = endPoint.X - x02;
                if (endPoint.X == x02)
                {
                    startAngle = 90;
                }
                else { startAngle = (float)(Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (endPoint.X < x02 && endPoint.Z <= z02)
            {
                catet = x02 - endPoint.X;
                if (endPoint.Z == z02)
                {
                    startAngle = 180;
                }
                else { startAngle = (float)(180 - Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            if (endPoint.X <= x02 && endPoint.Z > z02)
            {
                catet = x02 - endPoint.X;
                if (endPoint.X == x02)
                {
                    startAngle = 270;
                }
                else { startAngle = (float)(180 + Math.Acos(catet / radius) * (180 / Math.PI)); }
            }
            square.X = x02 - radius;
            square.Z = z02 + radius;
            sweepAngle = (float)(2 * Math.Asin(hord / (2 * radius)) * (180 / Math.PI));
            rectangle.X = coordinateZero.X + square.X;
            rectangle.Y = coordinateZero.Z - square.Z;
            rectangle.Width = radius * 2;
            rectangle.Height = radius * 2;
            graphics.DrawArc(pen, rectangle, startAngle, sweepAngle);
        }

        private float ConvertToFloat(string str)
        {
            float num = 0;
            float num2 = 0;
            float num3 = 0;
            string s = "";
            if (str.Contains("*"))
            {
                s = str.Replace("*", ":*");
                str = null;
                str = s;
            }
            if (str.Contains("/"))
            {
                s = str.Replace("/", ";/");
                str = null;
                str = s;
            }
            if (str.Contains("-"))
            {
                s = str.Replace("-", ".-");
                str = null;
                str = s;
            }
            if (str.Contains("+"))
            {
                s = str.Replace("+", ".+");
                str = null;
                str = s;
            }

            string[] array = str.Split('.');
            for (int i = 0; i < array.Length; i++)
            {

                if (array[i].Contains("*") && array[i].Contains("/"))
                {
                    if (array[i].IndexOf('*') > array[i].IndexOf("/"))
                    {

                    }

                }
                else
                {
                    if (array[i].Contains("*"))
                    {
                        string[] array2 = array[i].Split(':');
                        for (int j = 0; j < array2.Length; j++)
                        {
                            if (array2[j].Contains("*"))
                            {
                                string g = array2[j].Replace("*", "");
                                array2[j] = null;
                                array2[j] = g;
                            }
                            if (num2 == 0)
                            {
                                num2 = float.Parse(array2[0]);
                            }
                            else
                            {
                                num2 *= float.Parse(array2[j]);
                            }
                        }
                    }

                    if (array[i].Contains("/"))
                    {
                        string[] array3 = array[i].Split(';');
                        for (int k = 0; k < array3.Length; k++)
                        {
                            if (array3[k].Contains("/"))
                            {
                                string g = array3[k].Replace("/", "");
                                array3[k] = null;
                                array3[k] = g;
                            }
                            if (num3 == 0)
                            {
                                num3 = float.Parse(array3[0]);
                            }
                            else
                            {
                                num3 /= float.Parse(array3[k]);
                            }
                        }
                    }
                }

                if (!array[i].Contains("*"))
                {
                    if (!array[i].Contains("/"))
                    {
                        if (!array[i].Equals(""))
                        {
                            num += float.Parse(array[i]);
                        }
                    }
                }
            }

            return num + num2 + num3;
        }

        public void DrawСontour(Point coordinateZero, float zoom)
        {
            Point startPoint = new Point();
            Point endPoint = new Point();
            string cadr = "";
            string strHorizontal = "";
            string strVertical = "";
            string horizontal = "X";
            string vertical = "Z";
            int x1 = 0;
            int x2 = 0;

            for (int i = 0; i < MyCollection.ListCadrs.Count; i++)
            {
                if (MyCollection.ListCadrs[i].Contains(horizontal))
                {
                    cadr = MyCollection.ListCadrs[i];
                    int n = cadr.IndexOf(horizontal, 0);
                    for (int j = n; j < cadr.Length; j++)
                    {
                        if (cadr[j] != ' ')
                        {
                            strHorizontal += cadr[j];
                            if (strHorizontal.Contains("=") || strHorizontal.Contains(horizontal) || strHorizontal.Contains(" "))
                            {
                                string s = strHorizontal.Replace("=", "").Replace(horizontal, "").Replace(" ", "");
                                strHorizontal = null;
                                strHorizontal = s;
                                x1++;
                                if (x2 % 2 != 0)
                                {
                                    startPoint.X = ConvertToFloat(strHorizontal);
                                }
                                else
                                {
                                    endPoint.X = ConvertToFloat(strHorizontal);
                                }
                                strHorizontal = null;
                                
                            }
                        }
                        else { break; }
                    }
                }
                if (MyCollection.ListCadrs[i].Contains(vertical))
                {
                    int n = cadr.IndexOf(vertical, 0);
                    for (int j = n; j < cadr.Length; j++)
                    {
                        if (cadr[j] != ' ')
                        {
                            strVertical += cadr[j];
                            if (strVertical.Contains("=") || strVertical.Contains(vertical) || strVertical.Contains(" "))
                            {
                                string s = strVertical.Replace("=", "").Replace(vertical, "").Replace(" ", "");
                                strVertical = null;
                                strVertical = s;
                                x2++;
                                if (x1 % 2 != 0)
                                {
                                    startPoint.Z = ConvertToFloat(strVertical);
                                }
                                else
                                {
                                    endPoint.Z = ConvertToFloat(strVertical);
                                }
                                strVertical = null;
                                                              
                            }
                        }
                        else { break; }
                    }
                }

                DrawLine(coordinateZero, zoom, startPoint, endPoint);
            }

        }
    }
}

