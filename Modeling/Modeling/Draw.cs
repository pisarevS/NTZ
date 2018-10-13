using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Modeling
{
    internal class Draw : IDraw
    {
        private PictureBox pictureBox1;
        private readonly Bitmap img;
        private Graphics graphics;
        private readonly Point coordinateZero;
        private readonly Pen solidLine;
        private Pen dottedLine;
        private Pen line;
        private string cadr = "";
        public static Point startPoint;
        public static Point endPoint;
        public static string strS = "+";

        public Draw(PictureBox pictureBox1, Point coordinateZero)
        {
            this.pictureBox1 = pictureBox1;
            try
            {
                img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(img);
            }
            catch { }

            solidLine = new Pen(Color.Green);
            dottedLine = new Pen(Brushes.Gray);
            dottedLine.DashPattern = new float[] { 5f, 5f };
            this.coordinateZero = new Point();
            pictureBox1.Image = img;
            this.coordinateZero.X = pictureBox1.Width / 2;
            this.coordinateZero.Z = pictureBox1.Height / 2;
        }

        public void SystemСoordinate(PictureBox pictureBox1, Point coordinateZero)
        {
            dottedLine.DashPattern = new float[] { 5f, 5f };
            try
            {
                graphics.DrawLine(dottedLine, coordinateZero.X, 0, coordinateZero.X, pictureBox1.Height); //горизонтальная
                graphics.DrawLine(dottedLine, 0, coordinateZero.Z, pictureBox1.Width, coordinateZero.Z); //вертикальная
            }
            catch { }

        }

        public void DrawLine(Pen pen, Point coordinateZero, float zoom, Point startPoint, Point endPoint)
        {
            float startX = startPoint.X;
            float startZ = startPoint.Z;
            float endX = endPoint.X;
            float endZ = endPoint.Z;
            startX = Convert.ToInt32(startX * zoom);
            startZ = Convert.ToInt32(startZ * zoom);
            endX = Convert.ToInt32(endX * zoom);
            endZ = Convert.ToInt32(endZ * zoom);
            if (startZ > 0) startZ = coordinateZero.Z - startZ;
            else startZ = coordinateZero.Z + Math.Abs(startZ);
            if (endZ > 0) endZ = coordinateZero.Z - endZ;
            else endZ = coordinateZero.Z + Math.Abs(endZ);
            try
            {
                graphics.DrawLine(pen, coordinateZero.X + startX, startZ, coordinateZero.X + endX, endZ);
            }
            catch { }
        }

        public void DrawArc(Pen pen, Point coordinateZero, bool clockwise, float zoom, float radius, Point startPoint, Point endPoint)
        {
            float startX = startPoint.X;
            float startZ = startPoint.Z;
            float endX = endPoint.X;
            float endZ = endPoint.Z;
            Point square = new Point();
            RectangleF rectangle = new RectangleF();
            startX = startX * zoom;
            startZ = startZ * zoom;
            endX = endX * zoom;
            endZ = endZ * zoom;
            radius = radius * zoom;
            float startAngle = 0;
            float sweepAngle = 0;
            float catet;
            float hord = (float)Math.Sqrt(Math.Pow(startX - endX, 2) + Math.Pow(startZ - endZ, 2));
            float h = (float)Math.Sqrt(radius * radius - (hord / 2) * (hord / 2));
            if (clockwise)
            {
                float x01 = (startX + (endX - startX) / 2 + h * (endZ - startZ) / hord);
                float z01 = (startZ + (endZ - startZ) / 2 - h * (endX - startX) / hord);
                if (startX > x01 && startZ >= z01)
                {
                    catet = startX - x01;
                    if (startZ == z01)
                    {
                        startAngle = 0;
                    }
                    else { startAngle = (float)(360 - Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                if (startX >= x01 && startZ < z01)
                {
                    catet = startX - x01;
                    if (startX == x01)
                    {
                        startAngle = 90;
                    }
                    else { startAngle = (float)(Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                if (startX < x01 && startZ <= z01)
                {
                    catet = x01 - startX;
                    if (startZ == z01)
                    {
                        startAngle = 180;
                    }
                    else { startAngle = (float)(180 - Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                if (startX <= x01 && startZ > z01)
                {
                    catet = x01 - startX;
                    if (startX == x01)
                    {
                        startAngle = 270;
                    }
                    else { startAngle = (float)(180 + Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                square.X = x01 - radius;
                square.Z = z01 + radius;             
            }
            if (!clockwise)
            {
            
                float x02 = startX + (endX - startX) / 2 - h * (endZ - startZ) / hord;
                float z02 = startZ + (endZ - startZ) / 2 + h * (endX - startX) / hord;
                if (endX > x02 && endZ >= z02)
                {
                    catet = endX - x02;
                    if (endZ == z02)
                    {
                        startAngle = 0;
                    }
                    else { startAngle = (float)(360 - Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                if (endX >= x02 && endZ < z02)
                {
                    catet = endX - x02;
                    if (endX == x02)
                    {
                        startAngle = 90;
                    }
                    else { startAngle = (float)(Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                if (endX < x02 && endZ <= z02)
                {
                    catet = x02 - endX;
                    if (endZ == z02)
                    {
                        startAngle = 180;
                    }
                    else { startAngle = (float)(180 - Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                if (endX <= x02 && endZ > z02)
                {
                    catet = x02 - endX;
                    if (endX == x02)
                    {
                        startAngle = 270;
                    }
                    else { startAngle = (float)(180 + Math.Acos(catet / radius) * (180 / Math.PI)); }
                }
                square.X = x02 - radius;
                square.Z = z02 + radius;               
            }
            sweepAngle = (float)(2 * Math.Asin(hord / (2 * radius)) * (180 / Math.PI));
            rectangle.X = coordinateZero.X + square.X;
            rectangle.Y = coordinateZero.Z - square.Z;
            rectangle.Width = radius * 2;
            rectangle.Height = radius * 2;
            try
            {
                graphics.DrawArc(solidLine, rectangle, startAngle, sweepAngle);
            }
            catch { }
        }

        public void DrawСontour(Point coordinateZero, float zoom)
        {
            startPoint = new Point();
            endPoint = new Point();
            RND rnd = new RND();
            string strHorizontal = "";
            string strVertical = "";
            string strCR = "";
            string horizontal = "X";
            string vertical = "Z";
            string CR = "CR";
            float radius = 0;
            startPoint.X = 650f;
            startPoint.Z = 250f;
            endPoint.X = 650f;
            endPoint.Z = 250f;
            bool isHorizontal = false;
            bool isVertical = false;
            bool isCR = false;
            bool clockwise = true;
            int x = 0;
            int u = 0;

            for (int i = 0; i < MyCollection.ListCadrs.Count; i++)
            {
                if (MyCollection.ListCadrs[i].Contains("X"))
                {
                    x++;
                }
                if (MyCollection.ListCadrs[i].Contains("U"))
                {
                    u++;
                }
            }
            if (x > u)
            {
                horizontal = "X";
                vertical = "Z";
            }
            if (x < u)
            {
                horizontal = "U";
                vertical = "W";
            }

            for (int i = 0; i < MyCollection.ListCadrs.Count; i++)
            {
                dottedLine = new Pen(Brushes.Black);
                dottedLine.DashPattern = new float[] { 5f, 5f };
                cadr = MyCollection.ListCadrs[i];

                if (cadr.Contains("G"))
                {
                    string G = "G";
                    int n = cadr.IndexOf("G", 0);
                    for (int j = n + 1; j < cadr.Length; j++)
                    {
                        if (Check.isDigit(cadr[j]))
                        {
                            G += cadr[j];
                        }
                        else { break; }
                    }
                    switch (G)
                    {
                        case "G0":
                            line = dottedLine;
                            break;
                        case "G00":
                            line = dottedLine;
                            break;
                        case "G1":
                            line = solidLine;
                            break;
                        case "G01":
                            line = solidLine;
                            break;
                        case "G2":
                            if (Check.isG17())
                            {
                                clockwise = true;
                            }
                            else { clockwise = false; }
                            break;
                        case "G02":
                            if (Check.isG17())
                            {
                                clockwise = true;
                            }
                            else { clockwise = false; }
                            break;
                        case "G3":
                            if (Check.isG17())
                            {
                                clockwise = false;
                            }
                            else { clockwise = true; }
                            break;
                        case "G03":
                            if (Check.isG17())
                            {
                                clockwise = false;
                            }
                            else { clockwise = true; }
                            break;
                    }
                }

                if (cadr.Contains(horizontal))
                {
                    isHorizontal = true;
                    int n = cadr.IndexOf(horizontal, 0);
                    if (Check.CheckSymbol(cadr[n + 1]))
                    {
                        for (int j = n + 1; j < cadr.Length; j++)
                        {
                            if (Check.ReadUp(cadr[j]))
                            {
                                strHorizontal += cadr[j];
                                if (strHorizontal.Contains("=") || strHorizontal.Contains(horizontal) || strHorizontal.Contains(" "))
                                {
                                    string s = strHorizontal.Replace("=", "").Replace(horizontal, "").Replace(" ", "");
                                    strHorizontal = null;
                                    strHorizontal = s;
                                }
                            }
                            else { break; }
                        }
                        try
                        {
                            float res;
                            bool isFloat = float.TryParse(strHorizontal, out res);
                            endPoint.X = res;
                            if (!isFloat)
                            {
                                if (strHorizontal[0] == '-')
                                {
                                    strS = strHorizontal;
                                    strHorizontal = strHorizontal.Remove(0, 1);
                                }
                                endPoint.X = rnd.Calculate(strHorizontal);
                                strHorizontal = null;
                                strS = "+";
                            }
                            else
                            {
                                if (strHorizontal.Contains("(") && strHorizontal.Contains(")"))
                                {
                                    strHorizontal = strHorizontal.Replace("(", "").Replace(")", "");
                                }
                                endPoint.X = float.Parse(strHorizontal);
                                strHorizontal = null;
                            }
                        }
                        catch { MessageBox.Show(cadr); return; }
                    }
                }

                if (cadr.Contains(vertical))
                {
                    isVertical = true;
                    int n = cadr.IndexOf(vertical, 0);
                    if (Check.CheckSymbol(cadr[n + 1]))
                    {
                        for (int j = n + 1; j < cadr.Length; j++)
                        {
                            if (Check.ReadUp(cadr[j]))
                            {
                                strVertical += cadr[j];
                                if (strVertical.Contains("=") || strVertical.Contains(vertical) || strVertical.Contains(" "))
                                {
                                    string s = strVertical.Replace("=", "").Replace(vertical, "").Replace(" ", "");
                                    strVertical = null;
                                    strVertical = s;
                                }
                            }
                            else { break; }
                        }
                        try
                        {
                            float res;
                            bool isFloat = float.TryParse(strVertical, out res);
                            endPoint.Z = res;
                            if (!isFloat)
                            {
                                if (strVertical[0] == '-')
                                {
                                    strS = strVertical;
                                    strVertical = strVertical.Remove(0, 1);
                                }
                                endPoint.Z = rnd.Calculate(strVertical);
                                strVertical = null;
                                strS = "+";
                            }
                            else
                            {
                                if (strVertical.Contains("(") && strVertical.Contains(")"))
                                {
                                    strVertical = strVertical.Replace("(", "").Replace(")", "");
                                }
                                endPoint.Z = float.Parse(strVertical);
                                strVertical = null;
                            }
                        }
                        catch { MessageBox.Show(cadr); return; }
                    }
                }

                if (cadr.Contains(CR))
                {
                    isCR = true;
                    int n = cadr.IndexOf(CR, 0);
                    for (int j = n + 2; j < cadr.Length; j++)
                    {
                        if (Check.ReadUp(cadr[j]))
                        {
                            strCR += cadr[j];
                            if (strCR.Contains("=") || strCR.Contains(strCR) || strCR.Contains(" "))
                            {
                                string s = strCR.Replace("=", "").Replace(CR, "").Replace(" ", "");
                                strCR = null;
                                strCR = s;
                            }
                        }
                        else { break; }
                    }
                    if (strCR.Contains("+") || strCR.Contains("-") || strCR.Contains("*") || strCR.Contains("/"))
                    {
                        radius = rnd.Calculate(strCR);
                        strCR = null;
                    }
                    else
                    {
                        if (strCR.Contains("(") && strCR.Contains(")"))
                        {
                            strCR = strCR.Replace("(", "").Replace(")", "");
                        }
                        radius = float.Parse(strCR);
                        strCR = null;
                    }
                }

                if (isHorizontal && isVertical && isCR)
                {
                    DrawArc(line, coordinateZero, clockwise, zoom, radius, startPoint, endPoint);
                    startPoint.X = 0;
                    startPoint.X = endPoint.X;
                    startPoint.Z = 0;
                    startPoint.Z = endPoint.Z;
                    isHorizontal = false;
                    isVertical = false;
                    isCR = false;
                }

                if (isHorizontal || isVertical)
                {
                    DrawLine(line, coordinateZero, zoom, startPoint, endPoint);
                    startPoint.X = 0;
                    startPoint.X = endPoint.X;
                    startPoint.Z = 0;
                    startPoint.Z = endPoint.Z;
                    isHorizontal = false;
                    isVertical = false;
                }
            }
            DrawPoint(coordinateZero, endPoint, 3, zoom);
        }

        public void DrawPoint(Point coordinateZero, Point startPoint, int radius, float zoom)
        {
            RectangleF rectangle = new RectangleF();
            SolidBrush brush1 = new SolidBrush(Color.Brown);
            float startX = startPoint.X;
            float startZ = startPoint.Z;
            startX = startX * zoom;
            startZ = startZ * zoom;
            rectangle.X = coordinateZero.X + startX - radius;
            rectangle.Y = coordinateZero.Z - startZ - radius;
            rectangle.Width = radius * 2;
            rectangle.Height = radius * 2;
            graphics.FillEllipse(brush1, rectangle);
        }
    }
}

