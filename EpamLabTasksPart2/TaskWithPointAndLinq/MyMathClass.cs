using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TaskWithPointAndLinq
{

   public static class MyMathClass
    {
        public static List<BigInteger> GetFibonacciList(int n)
        {
            var list = new List<BigInteger>();
           BigInteger first = 0;
            BigInteger second = 1;
           BigInteger result = 0;

            list.Add(0);
            list.Add(1);

            if (n == 0)
            {
                list.Clear();
                list.Add(0);
            }
            if (n == 1)
            {
                list.Clear();
                list.Add(0);
                list.Add(1);
            }
            for (int i = 2; i < n; i++)
            {
                result = first + second;
                first = second;
                second = result;
                list.Add(result);
            }

            return list;

        }

        public static BigInteger Factorial(int x)
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

      public  static BigInteger Fibonachi(int n)
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

        public static BigInteger Fibonacci(BigInteger n)
        {
            BigInteger a = 0;
            BigInteger b = 1;        
            for (int i = 0; i < n; i++)
            {
                BigInteger temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }








    }
}
