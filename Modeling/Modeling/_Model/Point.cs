using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modeling
{
    class Point
    {
        private float x = 0;
        private float z = 0;

        public Point()
        {
        }

        public Point(int x, int z)
        {
            this.x = x;
            this.z = z;
        }



        public float X
        {
            get { return x; }
            set { x = value; }
        }


        public float Z
        {
            get { return z; }
            set { z = value; }
        }
    }
}
