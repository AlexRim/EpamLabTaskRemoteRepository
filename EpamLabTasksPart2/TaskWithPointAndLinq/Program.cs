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


        private static List<ulong> CreateFibonaciSequence(int n)
        {
            var list = new List<ulong>();
            int i = 1;
            while (list.Count <= n)
            {
                
                list.Add((ulong)MyMathClass.Fibonacci(i));
                i++;
               
              
            }

            return list;
        }










        static void Main(string[] args)
        {

            var fibonachiList = CreateFibonaciSequence(200);

            foreach (var i in fibonachiList)


            {
                WriteLine(i);
            }

            var simple = fibonachiList.Where(x => x.IsIntSimple()).Count();
            var divideByFive = fibonachiList.Where(x => x % 5 == 0).Count();
            var divideByDigitsSum = fibonachiList.Where(x=>x>0).Where(x =>(int) x % x.ToString().Sum(y => Convert.ToInt32(y.ToString())) == 0).Count();
            var sqrtFromDigitsContainsTwo = fibonachiList.Where(x => x.ToString().Contains("2")).Select(y => Floor(Sqrt(y))).ToArray();
            var sortBySecondDigit = fibonachiList.Where(x => x >= 10).Select(z => z.ToString()).OrderByDescending(x =>Convert.ToInt32(x[1]));


            //  var newArray = fibonachiList.Where(x => x % 3 == 0).Take(5).Where(y => y % 5 == 0).Skip(5).Where(c => c % 5 == 0).Select(m=>(m.ToString()[m.ToString().Length]+ m.ToString()[m.ToString().Length-1]));

            var sq = fibonachiList.Where(x => (int)x%3==0).TakeWhile((s, i) => (int)s%5==0 && i < 6);
            //IEnumerable<string> auto = cars.TakeWhile((s, i) => s.Length < 12 && i < 5);

            //foreach (string str in auto)
            //    Console.WriteLine(str);

            WriteLine();
            WriteLine(" Simple numbers Count:{0}", simple);
            WriteLine("numbers that are divided by 5:{0}", divideByFive);
            WriteLine(" numbers are divided by the sum of their digits:{0}", divideByDigitsSum);
            WriteLine("square roots (rounded down to the whole down) of all numbers that have the number 2:");
            foreach (var i in sqrtFromDigitsContainsTwo)
            {
                WriteLine(i);
            }

            WriteLine("\nSorted by Second Digit Values:");
            foreach(var i in sortBySecondDigit)
            {
                WriteLine(i);
            }



            WriteLine("\nTask 6 values:");
            WriteLine(sq.Count());











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
