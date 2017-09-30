using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TaskWithPointAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            MyPoint myPoint = new MyPoint(1, 1);
            MyPoint myPoint1 = new MyPoint(1, 1);

            WriteLine(myPoint.Equals(myPoint1));
            int x = 15;
           int fact= MyMathClass.GetFactorial(x);
            int fib = MyMathClass.GetFibonachi(x);

         var c =new  Keeper();

            var m = new Keeper();

            WriteLine("factorial(15)={0};fibonachi(15)={1}",fact,fib);



            for (int i = 0; i <5; i++)
            {
                var q = new Keeper();
            }

            WriteLine(m.ToString());


            ReadKey();


            
        }
    }
}
