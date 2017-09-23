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
            string line = null;
            var list = new List<string>();
            int i = 0;
            while(line!="stop")
            {
                WriteLine("Input line {0}", i);
                line = ReadLine();
                i++;
                if(line=="")
                {
                    i--;
                    WriteLine("Line have not to be empty!");
                    continue;
                }
                else
                {
                    list.Add(line);
                }             
            }

                return list;
        }





        static void Main(string[] args)
        {
            double x;
            var i = ReadLine();
            if(!double.TryParse(i,out x))
            {
                Write("Error");
            }
            else
            {
                WriteLine(x);
            }
         //   var l = InputLines();
            ReadKey();
        }
    }
}