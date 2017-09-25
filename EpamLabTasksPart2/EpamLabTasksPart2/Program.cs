using System;
using QuadraticEquationLibrary;
using static System.Console;

namespace EpamLabTasksPart2
{
    class Program
    {

        private static   void PrintMenu() => WriteLine("Input '1' to solve quadratic equation\nInput '2' to solve the linear equation\n ");

        private static double [] InputValuesForQuadraticEquation()
        {
         var myArr = new string []{"a","b","c" };
         var coefficients = new double[3];
         double x = 0;
         int i = 0;

            while (true)
            {
                WriteLine("Input {0}:", myArr[i]);
                string line = ReadLine();
               if( double.TryParse(line, out x))
                {
                    coefficients[i] = x;
                }
                

            }




            return coefficients;
        }









        private static void Menu()
        {
            PrintMenu();
            string select = ReadLine();
             switch (select)
            {
                case "1":
                    break;

                case "2":
                    break;

                default:
                    break;

            }





        }












        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}