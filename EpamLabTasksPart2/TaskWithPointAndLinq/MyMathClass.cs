using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWithPointAndLinq
{

   public static class MyMathClass
    {

        public static int GetFactorial(int x)
        {
            if(x==0)
            {
                return 1;
            }
            else
            {
                return x * (GetFactorial(x - 1));
            }
        }

      public  static int GetFibonachi(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return GetFibonachi(n - 1) + GetFibonachi(n - 2);
            }
        }










    }
}
