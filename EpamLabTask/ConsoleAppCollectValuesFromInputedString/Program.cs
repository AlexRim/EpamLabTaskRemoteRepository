using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Console;
using System.Collections.Immutable;





namespace ConsoleAppCollectValuesFromInputedString
{
    class Program
    {

        private static List<string> InputLines()
        {
        
            var list = new List<string>();
            int i = 0;
            while(true)
            {
                WriteLine("Input line {0}", i);
               var line = ReadLine();
                if (line == "stop")
                {
                    break;
                }
                i++;
                if(line=="")
                {
                    i--;
                    WriteLine("Line can not be empty!");
                    continue;
                }
                else
                {
                    list.Add(line);
                }             
            }

                return list;
        }


        private static String GetAverage(IEnumerable<string> numbers)=>String.Format("{0:0.00}",numbers.Average(x =>Convert.ToDouble(x)));
       

        private static void Display()
        {
            var list = InputLines();
         //  var list = new List<string>() {"3","3,5","4","5","3,5","3","8,87768768","fvdf","avdf","bvdf","abcdfgh" };
            var integers =list.Select(x => x.Replace(" ", string.Empty)).Where(b => Checker.IsInteger(b));
            var doubles = list.Select(x => x.Replace(" ", string.Empty)).Where(b => Checker.IsDouble(b));
            var strings = list.Where(x => !Checker.IsDouble(x) && !Checker.IsInteger(x));
            WriteLine("Defulte values:");
           foreach(var i in list)
            {
                Write(i + ":");
            }

            WriteLine();
            WriteLine("Integers count={0}",integers.Count());
            WriteLine("Doubles count={0}", doubles.Count());
            if (integers.Count() > 0)
            {
                WriteLine("Integers:");
                foreach (var i in integers)
                {
                    WriteLine(i.PadLeft(10));
                }
                WriteLine("Average=" + GetAverage(integers).PadLeft(5));
            }
            if (doubles.Count() > 0)
            {
                WriteLine("Doubles:");
                foreach (var i in doubles)
                {
                    WriteLine(String.Format("{0:0.00}", Convert.ToDouble(i)).PadLeft(12));
                }
                WriteLine("Average:" + GetAverage(doubles).PadLeft(4));
            }
            if (strings.Count() > 0)
                {
                List<string> stringList = strings.ToList();
                stringList.Sort();
                stringList.Reverse();
                WriteLine("NoNs:");
                foreach (var i in stringList)
                {
                    WriteLine(i.PadLeft(10));
                }
            }

        }





        static void Main(string[] args)
        {
            try
            {
                Display();
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }


            ReadKey();
        }
    }
}