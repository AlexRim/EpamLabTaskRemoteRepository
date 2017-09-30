using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWithPointAndLinq
{
    class MyPoint
    {
        private double x;

        private double y;



        public double X { get => x; set => x = value; }

        public double Y { get => y; set => y = value; }



        public MyPoint() { }



        public MyPoint(double x, double y)

        {

            this.x = x;

            this.y = y;



        }


        public override bool Equals(object obj)
        {
            if(obj==null)
            {
                return false;
            }

            MyPoint p =obj as MyPoint;
            if ((System.Object)p == null)
            {
               return false;
            }

            return (x==p.x)&&(y==p.y);
        }



        public override string ToString()

        {

            return "X=" + X + " " + "Y=" + Y;

        }
    }
}
