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
        private readonly PictureBox pictureBox1;
        private readonly Bitmap img;
        private Graphics graphics;
        private readonly Point coordinateZero;
        private readonly Pen solidLine;
        private Pen dottedLine;
        private Pen line;
        private string cadr = "";
        public static Point startPoint;
        public static Point endPoint;
        private const float FIBO = 01123581321345589144f;
        private bool isHorizontal = false;
        private bool isVertical = false;
        private bool icHorizantal = false;
        private bool icVertical = false;
        public bool clockwise = true;
        
        
        public Draw(PictureBox pictureBox1, Point coordinateZero)
        {
            this.pictureBox1 = pictureBox1;
            try
            {
                img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(img);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
            catch { }
            solidLine = new Pen(Color.Green, 1.5F);
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
            try
            {
                graphics.FillEllipse(brush1, rectangle);
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
            Expression expression = new Expression();
            string strCR = "";
            string horizontal = "X";
            string vertical = "Z";
            string CR = "CR";
            float radius = 0;
            startPoint.X = 650f;
            startPoint.Z = 250f;
            endPoint.X = 650f;
            endPoint.Z = 250f;
            bool isCR = false;
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
                if (cadr.Contains("IC("))
                {
                    string s = cadr.Replace("IC", "|");
                    cadr = null;
                    cadr = s;
                }
                ContainsGcod(cadr);
                if (cadr.Contains(horizontal))
                {
                    if (CoordinateSearch(cadr, horizontal) == FIBO) return;
                    endPoint.X = CoordinateSearch(cadr, horizontal);
                    isHorizontal = true;
                }
                if (cadr.Contains(vertical))
                {
                    if (CoordinateSearch(cadr, vertical) == FIBO) return;
                    endPoint.Z = CoordinateSearch(cadr, vertical);
                    isVertical = true;
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
                        radius = expression.Calculate(strCR);
                        strCR = null;
                    }
                    else
                    {
                        try
                        {
                            if (strCR.Contains("(") && strCR.Contains(")"))
                            {
                                strCR = strCR.Replace("(", "").Replace(")", "");
                            }
                            radius = float.Parse(strCR);
                            strCR = null;
                        }
                        catch 
                        {
                            if (!MyCollection.ErrorList.Contains(cadr))
                            {
                                MyCollection.ErrorList.Add(cadr);
                                if (ModelingForm.isError)
                                {
                                    MessageBox.Show(cadr);
                                }
                            }                                       
                        }
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
                    if (icHorizantal)
                    {
                        endPoint.X = startPoint.X + endPoint.X;
                    }
                    if (icVertical)
                    {
                        endPoint.Z = startPoint.Z + endPoint.Z;
                    }
                    DrawLine(line, coordinateZero, zoom, startPoint, endPoint);
                    startPoint.X = 0;
                    startPoint.X = endPoint.X;
                    startPoint.Z = 0;
                    startPoint.Z = endPoint.Z;
                    isHorizontal = false;
                    isVertical = false;
                    icHorizantal = false;
                    icVertical = false;
                }
            }
            DrawPoint(coordinateZero, endPoint, 3, zoom);
        }

        private float CoordinateSearch(string cadr, string axis)
        {
            Expression expression = new Expression();
            string strAxis = "";
            int n = cadr.IndexOf(axis, 0);
            if (Check.CheckSymbol(cadr[n + 1]))
            {
                for (int j = n + 1; j < cadr.Length; j++)
                {
                    if (Check.ReadUp(cadr[j]))
                    {
                        strAxis += cadr[j];
                        if (strAxis.Contains("=") || strAxis.Contains(axis) || strAxis.Contains(" "))
                        {
                            string s = strAxis.Replace("=", "").Replace(axis, "").Replace(" ", "");
                            strAxis = null;
                            strAxis = s;
                        }
                    }
                    else { break; }
                }
                try
                {
                    if (strAxis.Contains("|"))
                    {
                        if (axis == "X" || axis == "U") icHorizantal = true;
                        if (axis == "Z" || axis == "W") icVertical = true;
                        string d = "";
                        int a = strAxis.IndexOf("|", 0);
                        d = strAxis.Substring(a + 2, strAxis.Length - 3);
                        strAxis = null;
                        strAxis = d;
                    }
                    float res;
                    bool isFloat = float.TryParse(strAxis, out res);
                    if (!isFloat)
                    {
                        if (strAxis.Contains("-") && strAxis[0] != '-')
                        {
                            if (strAxis[strAxis.IndexOf("-", 0) - 1] == '(' || strAxis[strAxis.IndexOf("-", 0) - 1] == ' ')
                            {
                                string strS = strAxis.Replace("-", "0-");
                                strAxis = null;
                                strAxis = strS;
                            }
                            else if (!Check.isDigit(strAxis[strAxis.IndexOf("-", 0) - 1]) && strAxis[strAxis.IndexOf("-", 0) - 1] != ')')
                            {
                                string strS = strAxis.Replace("-", "0-");
                                strAxis = null;
                                strAxis = strS;
                            }
                        }
                        else if (strAxis.Contains("-") && strAxis[0] == '-')
                        {
                            string strS = "0" + strAxis;
                            strAxis = null;
                            strAxis = strS;
                        }
                        return expression.Calculate(strAxis);
                    }
                    else
                    {
                        if (strAxis.Contains("(") && strAxis.Contains(")"))
                        {
                            strAxis = strAxis.Replace("(", "").Replace(")", "");
                            return float.Parse(strAxis);
                        }
                        return res;
                    }
                }
                catch
                {
                    if (!MyCollection.ErrorList.Contains(cadr))
                    {
                        MyCollection.ErrorList.Add(cadr);
                        if (ModelingForm.isError)
                        {
                            MessageBox.Show(cadr);
                        }                    
                    }                              
                    return FIBO;
                }
            }
            if (axis == "X" || axis == "U") return endPoint.X;
            if (axis == "Z" || axis == "W") return endPoint.Z;
            return FIBO;
        }

        private void ContainsGcod(string cadr)
        {
            if (cadr.Contains("G"))
            {
                string G = "G";
                for (int i = 0; i < cadr.Length; i++)
                {
                    if (cadr[i] == 'G')
                    {
                        for (int j = i + 1; j < cadr.Length; j++)
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
                        G = "G";
                    }
                }
            }
        }
    }
}

