using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWithPointAndLinq
{

   public static class MyMathClass
    {


        public static int Factorial(int x)
        {
            if(x==0)
            {
                return 1;
            }
            else
            {
             return      x * (Factorial(x - 1));
              
            }
        }

      public  static int Fibonachi(int n)
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
          return     Fibonachi(n - 1) + Fibonachi(n - 2);
         
                
            }
        }

        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;        
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }








    }
}
