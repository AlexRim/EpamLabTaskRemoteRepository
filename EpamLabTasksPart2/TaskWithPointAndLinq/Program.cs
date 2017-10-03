using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using System.Numerics;

namespace TaskWithPointAndLinq
{
    class Program
    {

        private static List<BigInteger> CreateFibonaciSequence(int n)

        {

            var list = new List<BigInteger>();

            BigInteger i = 1;

            while (list.Count <= n)

            {



                list.Add(MyMathClass.Fibonacci(i));

                i++;


            }

            return list;

        }









        static void Main(string[] args)
        {
            try
            {
                var fibonachiList = CreateFibonaciSequence(30);

              
         
                var simple = fibonachiList.Where(x => x.IsIntSimple()).Count();
                var divideByFive = fibonachiList.Where(x => x % 5 == 0).Count();
                var divideByDigitsSum = fibonachiList.Where(x => x > 0).Where(x => x % x.ToString().Sum(y => Convert.ToInt32(y.ToString())) == 0).Count();
                var sqrtFromDigitsContainsTwo = fibonachiList.Where(x => x.ToString().Contains("2")).Select(y => Floor(Sqrt((double)y))).ToArray();
                var sortBySecondDigit = fibonachiList.Where(x => x >= 10).Select(z => z.ToString()).OrderByDescending(x => Convert.ToInt32(x[1]));
                var val = fibonachiList.SkipWhile((m, i) => m % 5 == 0 && i < 6).Concat(fibonachiList.TakeWhile((x, i) => x % 5 == 0 && i < 6)).Where(b => b % 3 == 0 && b >= 10).Select(x => x.ToString().ToCharArray()).Select(x => x[x.Length - 2] + x[x.Length - 1].ToString());
                var maxSumPowDigits = fibonachiList.Select(x => x.ToString()).OrderBy(x => x.Sum(b => Math.Pow(Convert.ToInt32(b.ToString()), 2))).Last();
                var average = fibonachiList.Average(x => x.ToString().Count(b => b == '0'));

                
                WriteLine("-----------------------------");
                WriteLine(" Simple numbers Count:{0}", simple);
                WriteLine("-----------------------------");
                WriteLine("numbers that are divided by 5:{0}", divideByFive);
                WriteLine("-----------------------------");
                WriteLine(" numbers are divided by the sum of their digits:{0}", divideByDigitsSum);
                WriteLine("-----------------------------");
                WriteLine("square roots (rounded down to the whole down) of all numbers that have the number 2:");
                foreach(var i in sqrtFromDigitsContainsTwo)
                {
                    WriteLine(i);
                }
                WriteLine("-----------------------------");
                foreach (var i in sortBySecondDigit)
                {
                    WriteLine(i);
                }
                WriteLine("-----------------------------");
                foreach (var i in val)
                {
                    WriteLine(i);
                }
                WriteLine("-----------------------------");
                WriteLine(maxSumPowDigits);
                WriteLine("-----------------------------");
                WriteLine("Average count zero {0}:",average);










            }
            catch (Exception ex)
            {
                WriteLine(ex.StackTrace);
                WriteLine(ex.Message);
            }

            ReadKey();


            
        }
    }
}
