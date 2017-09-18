using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalcLibrary
{
   public class MyCalcClass
    {
        public double Add(double x, double y) => x + y;

        public double Divide(double x, double y)
        {
            if(y==0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                return x / y;
            }

        }


        public double Multyply(double x, double y) => x * y;


        public double Substract(double x, double y) => x - y;




    }
}
