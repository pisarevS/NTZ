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
        private PictureBox pictureBox1;
        private Bitmap img;
        private Graphics graphics;
        private Point coordinateZero;
        private Pen solidLine;
        private Pen dottedLine;
        private Pen line;

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
            startPoint.X = Convert.ToInt32(startPoint.X * zoom);
            startPoint.Z = Convert.ToInt32(startPoint.Z * zoom);
            endPoint.X = Convert.ToInt32(endPoint.X * zoom);
            endPoint.Z = Convert.ToInt32(endPoint.Z * zoom);
            if (startPoint.Z > 0) startPoint.Z = coordinateZero.Z - startPoint.Z;
            else startPoint.Z = coordinateZero.Z + Math.Abs(startPoint.Z);
            if (endPoint.Z > 0) endPoint.Z = coordinateZero.Z - endPoint.Z;
            else endPoint.Z = coordinateZero.Z + Math.Abs(endPoint.Z);
            try
            {
                graphics.DrawLine(pen, coordinateZero.X + startPoint.X, startPoint.Z, coordinateZero.X + endPoint.X, endPoint.Z);
            }
            catch { }            
        }

        public void DrawArc(Pen pen,Point coordinateZero, bool clockwise, float zoom, float radius, Point startPoint, Point endPoint)
        {
            if (clockwise)
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
                graphics.DrawArc(solidLine, rectangle, startAngle, sweepAngle);
            }
            if (!clockwise)
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
                graphics.DrawArc(solidLine, rectangle, startAngle, sweepAngle);
            }
        }
       
        public float ConvertToFloat(string str)
        {
            float num = 0;
            float num2 = 0;
            float num3 = 0;
            float myltiplyNum = 0;
            float divideNum = 0;
            string s = "";          
            if (str.Contains("*"))
            {
                s = str.Replace("*", ":*");
                str = null;
                str = s;
                s = null;
            }
            if (str.Contains("/"))
            {
                s = str.Replace("/", ";/");
                str = null;
                str = s;
                s = null;
            }
            if (str.Contains("-"))
            {
                s = str.Replace("-", ".-");
                str = null;
                str = s;
                s = null;
            }
            if (str.Contains("+"))
            {
                s = str.Replace("+", ".+");
                str = null;
                str = s;
                s = null;
            }

            string[] array = str.Split('.');
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains("*") && array[i].Contains("/"))
                {
                    if (array[i].IndexOf('*') < array[i].IndexOf("/"))
                    {
                        string[] multiplyArr = array[i].Split(';');
                        for (int t = 0; t < multiplyArr.Length; t++)
                        {
                            if (multiplyArr[t].Contains(":"))
                            {
                                string[] multiplyArr2 = multiplyArr[t].Split(':');
                                for (int d = 0; d < multiplyArr2.Length; d++)
                                {
                                    if (multiplyArr2[d].Contains("*"))
                                    {
                                        string g = multiplyArr2[d].Replace("*", "");
                                        multiplyArr2[d] = null;
                                        multiplyArr2[d] = g;
                                        g = null;
                                    }
                                    if (myltiplyNum == 0)
                                    {
                                        myltiplyNum = float.Parse(multiplyArr2[0]);
                                    }
                                    else
                                    {
                                        myltiplyNum *= float.Parse(multiplyArr2[d]);
                                    }
                                }
                            }
                            else
                            {
                                if (multiplyArr[t].Contains("/"))
                                {
                                    string g = multiplyArr[t].Replace("/", "");
                                    multiplyArr[t] = null;
                                    multiplyArr[t] = g;
                                    g = null;
                                }
                                divideNum = float.Parse(multiplyArr[t]);
                                myltiplyNum /= divideNum;
                                divideNum = 0;
                            }
                        }
                    }
                    else
                    {
                        string[] divideArr = array[i].Split(':');
                        for (int y = 0; y < divideArr.Length; y++)
                        {
                            if (divideArr[y].Contains(";"))
                            {
                                string[] divideArr2 = divideArr[y].Split(';');
                                for (int u = 0; u < divideArr2.Length; u++)
                                {
                                    if (divideArr2[u].Contains("/"))
                                    {
                                        string g = divideArr2[u].Replace("/", "");
                                        divideArr2[u] = null;
                                        divideArr2[u] = g;
                                        g = null;
                                    }
                                    if (divideNum == 0)
                                    {
                                        divideNum = float.Parse(divideArr2[0]);
                                    }
                                    else
                                    {
                                        divideNum /= float.Parse(divideArr2[u]);
                                    }
                                }
                            }
                            else
                            {
                                if (divideArr[y].Contains("*"))
                                {
                                    string g = divideArr[y].Replace("*", "");
                                    divideArr[y] = null;
                                    divideArr[y] = g;
                                    g = null;
                                }
                                myltiplyNum = float.Parse(divideArr[y]);
                                divideNum *= myltiplyNum;
                                myltiplyNum = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (array[i].Contains("*") && !array[i].Contains("/"))
                    {
                        string[] array2 = array[i].Split(':');
                        for (int j = 0; j < array2.Length; j++)
                        {
                            if (array2[j].Contains("*"))
                            {
                                string g = array2[j].Replace("*", "");
                                array2[j] = null;
                                array2[j] = g;
                                g = null;
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
                    if (array[i].Contains("/") && !array[i].Contains("*"))
                    {
                        string[] array3 = array[i].Split(';');
                        for (int k = 0; k < array3.Length; k++)
                        {
                            if (array3[k].Contains("/"))
                            {
                                string g = array3[k].Replace("/", "");
                                array3[k] = null;
                                array3[k] = g;
                                g = null;
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
                num += num2 + num3 + myltiplyNum + divideNum;
                num2 = 0;
                num3 = 0;
                myltiplyNum = 0;
                divideNum = 0;
            }
            
            return num;
        }

        public void DrawСontour(Point coordinateZero, float zoom)
        {
            Point startPoint = new Point();
            Point endPoint = new Point();
            string cadr = "";
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
            bool clockwise=true;
            int x = 0;
            int u = 0;

            for(int i = 0; i < MyCollection.ListCadrs.Count; i++)
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

                if (cadr.Contains("G1 ")|| cadr.Contains("G01 "))
                {
                    line = solidLine;
                }
                if (cadr.Contains("G0 ")|| cadr.Contains("G00 "))
                {
                    line = dottedLine; 
                }
                if (cadr.Contains("G2 ") || cadr.Contains("G02 "))
                {
                    clockwise = false;
                }
                if (cadr.Contains("G3 ") || cadr.Contains("G03 "))
                {
                    clockwise = true;
                }

                if (MyCollection.ListCadrs[i].Contains(horizontal))
                {
                    isHorizontal = true;
                  
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
                            }
                        }
                        else { break; }
                    }
                    endPoint.X = ConvertToFloat(strHorizontal);
                    strHorizontal = null;
                }

                if (MyCollection.ListCadrs[i].Contains(vertical))
                {
                    isVertical = true;
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
                            }
                        }
                        else { break; }
                    }
                    endPoint.Z = ConvertToFloat(strVertical);
                    strVertical = null;
                }

                if (MyCollection.ListCadrs[i].Contains(CR))
                {
                    isCR = true;
                    int n = cadr.IndexOf(CR, 0);
                    for (int j = n; j < cadr.Length; j++)
                    {
                        if (cadr[j] != ' ')
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
                    radius = ConvertToFloat(strCR);
                    strCR = null;
                }

                if (isHorizontal && isVertical && isCR)
                {
                    float startX = startPoint.X;
                    float startZ = startPoint.Z;
                    float endX = endPoint.X;
                    float endZ = endPoint.Z;
                    DrawArc(line, coordinateZero, clockwise, zoom, radius, startPoint, endPoint);
                    startPoint.X = startX;
                    startPoint.Z = startZ;
                    endPoint.X = endX;
                    endPoint.Z = endZ;
                    startPoint.X = 0;
                    startPoint.X = endPoint.X;
                    startPoint.Z = 0;
                    startPoint.Z = endPoint.Z;
                    isHorizontal = false;
                    isVertical = false;
                    isCR = false;
                }

                if (isHorizontal||isVertical)
                {
                    float startX = startPoint.X;
                    float startZ = startPoint.Z;
                    float endX = endPoint.X;
                    float endZ = endPoint.Z;
                    DrawLine(line,coordinateZero, zoom, startPoint, endPoint);
                    startPoint.X = startX;
                    startPoint.Z = startZ;
                    endPoint.X = endX;
                    endPoint.Z = endZ;
                    startPoint.X = 0;
                    startPoint.X = endPoint.X;
                    startPoint.Z = 0;
                    startPoint.Z = endPoint.Z;
                    isHorizontal = false;
                    isVertical = false;
                }                 
            }
        }       
    }
}

