using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;

namespace TaskWithPointAndLinq
{
    class Program
    {


        private static List<int> CreateFibonaciSequence(int n)
        {
            var list = new List<int>();
            int i = 1;
            while (list.Count <= n)
            {
                
                list.Add(MyMathClass.Fibonacci(i));
                i++;
               
              
            }

            return list;
        }










        static void Main(string[] args)
        {

            var fibonachiList = CreateFibonaciSequence(17);

            foreach (var i in fibonachiList)


            {
                WriteLine(i);
            }

            var simple = fibonachiList.Where(x => x.IsIntSimple()).Count();
            var divideByFive = fibonachiList.Where(x => x % 5 == 0).Count();
            var divideByDigitsSum = fibonachiList.Where(x => x % x.ToString().Sum(y => int.Parse(y.ToString()))==0).Count();
            var sqrtFromDigitsContainsTwo = fibonachiList.Where(x => x.ToString().Contains("2")).Select(y =>Floor( Sqrt(y))).ToArray();

            WriteLine();

            WriteLine(" Simple numbers Count:{0}", simple);
            WriteLine("numbers that are divided by 5:{0}", divideByFive);
            WriteLine(" numbers are divided by the sum of their digits:{0}", divideByDigitsSum);
            WriteLine("square roots (rounded down to the whole down) of all numbers that have the number 2:");
            foreach (var i in sqrtFromDigitsContainsTwo)
            {
                WriteLine(i);
            }

           










            // MyPoint myPoint = new MyPoint(1, 1);
            // MyPoint myPoint1 = new MyPoint(1, 1);

            // WriteLine(myPoint.Equals(myPoint1));
            // int x = 15;
            //int fact= MyMathClass.Factorial(x);
            // int fib = MyMathClass.Fibonachi(x);

            // for (int i = 0; i <= x; i++)
            // {
            //  WriteLine(   MyMathClass.Fibonachi(i));
            // }
            // WriteLine();



            // var c = new Keeper();

            // var m = new Keeper();

            // WriteLine("factorial(15)={0};fibonachi(15)={1}", fact, fib);



            //for (int i = 0; i < 5; i++)
            //{
            //    var q = new Keeper();
            //}

            //WriteLine(m.ToString());


            ReadKey();


            
        }
    }
}
