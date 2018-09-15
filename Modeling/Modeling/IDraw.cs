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
        void SystemСoordinate(PictureBox pictureBox1, Point point);
        void DrawLine(Point startLine, Point endLine);
        void DrawArc(Point point);
    }
}
