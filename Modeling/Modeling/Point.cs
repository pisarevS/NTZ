using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modeling
{
    class Point
    {
        public Point()
        {
        }

        public Point(int x, int z)
        {
            this.X = x;
            this.Z = z;
        }

        public int X { get; set; } = 0;
        public int Z { get; set; } = 0;
    }
}
