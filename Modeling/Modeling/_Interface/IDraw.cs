﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modeling
{
    interface IDraw
    {
        void SystemСoordinate(PictureBox pictureBox1, Point coordinateZero);
        void DrawLine(Pen pen, Point coordinateZero, float zoom, Point startLine, Point endLine);
        void DrawArc(Pen pen, Point coordinateZero,int clockwiseInt, float zoom, float radius, Point startPoint, Point endPoint);
        void DrawСontour(Point coordinateZero, float zoom, int numberLine);
        void DrawPoint(Point coordinateZero, Point endLine,int radius,float zoom);
    }
}
