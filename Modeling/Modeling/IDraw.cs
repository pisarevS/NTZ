using System;
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
        void DrawLine(Point coordinateZero, double zoom, Point startLine, Point endLine);
        void DrawArc(Point coordinateZero, bool clockwise, double zoom, double radius, Point startPoint, Point endPoint);
        void DrawСontour(Point coordinateZero, bool clockwise, double zoom, double radius, Point startPoint, Point endPoint);
    }
}
