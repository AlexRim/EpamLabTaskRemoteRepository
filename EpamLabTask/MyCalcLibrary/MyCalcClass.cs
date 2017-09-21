using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalcLibrary
{
   public class MyCalcClass
    {
        public double Add(int x, int y) => x + y;

        public double Divide(int x, int y)
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


        public long Multiply(int x, int y) => x * y;


        public double Substract(int x, int y) => x - y;




    }
}
