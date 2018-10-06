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
        void DrawLine(Pen pen, Point coordinateZero, float zoom, Point startLine, Point endLine);
        void DrawArcClockwise(Point coordinateZero, float zoom, float radius, Point startPoint, Point endPoint);
        void DrawArcCounterclockwise(Point coordinateZero, float zoom, float radius, Point startPoint, Point endPoint);
        void DrawСontour(Point coordinateZero,float zoom);
        float ConvertToFloat(string str);
    }
}
