﻿using System;
using static System.Console;
using System.Text.RegularExpressions;
using EquationLibrary;



namespace EpamLabTasksPart2
{
    class Program
    {


        private static bool CheckInputFormatDouble(string line,out double x) 
        {
            x = 0;
            string pattern = @"(\-?\d+\,\d\d$)";
            if(double.TryParse(line,out x) && Regex.IsMatch(line,pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static void PrintMenu()
        {
            WriteLine("Input '1' to get quadratic equation\nInput '2' to get the linear equation\n ");
        }

        private static double [] InputValuesForQuadraticEquation()
        {
         var myArr = new string []{"a","b","c" };
         var coefficients = new double[3];
         double x = 0;
         int y=0;
         int i = 0;
            int j = 0;

            while (true)
            {
                WriteLine("Input {0}:", myArr[i]);
                i++;
                string line = ReadLine();
                if( CheckInputFormatDouble( line, out  x))
                {
                    coefficients[j] = x;
                    j++;
                    if(j==3)
                    {
                        break;
                    }

                }
                else if(int.TryParse(line,out y))
                {
                    coefficients[j] = y;
                    j++;
                    if (j == 3)
                    {
                        break;
                    }

                }
                else
                {
                    WriteLine("Wrong input format, try again!");
                    i--;
                    continue;
                }
                

            }

            return coefficients;
        }


        private static double[] InputValuesForLinearEquation()
        {
            var myArr = new string[] { "a", "b" };
            var coefficients = new double[2];
            double x = 0;
            int y = 0;
            int i = 0;
            int j = 0;

            while (true)
            {
                WriteLine("Input {0}:", myArr[i]);
                i++;
                string line = ReadLine();
                if (CheckInputFormatDouble(line, out x))
                {
                    coefficients[j] = x;
                    j++;
                    if (j == 2)
                    {
                        break;
                    }

                }
                else if (int.TryParse(line, out y))
                {
                    coefficients[j] = y;
                    j++;
                    if (j == 2)
                    {
                        break;
                    }

                }
                else
                {
                    WriteLine("Wrong input format, try again!");
                    i--;
                    continue;
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
               var coefficientsQ = InputValuesForQuadraticEquation();
               var getQuadraticRoots = new GetRoots(coefficientsQ[0], coefficientsQ[1], coefficientsQ[2]);
                    int j= 1;
                    foreach(var i in getQuadraticRoots.QadraticRoots)
                    {
                        WriteLine();
                        WriteLine("X{0}={1}", j, i);
                        j++;
                    }
                    break;

                case "2":
                    var coefficientsL = InputValuesForLinearEquation();
                    var getLinearRoots = new GetRoots(coefficientsL[0], coefficientsL[1]);
                    WriteLine("X=",getLinearRoots.RootLine);
                    break;

                default:
                    break;

            }





        }












        static void Main(string[] args)
       {
            try
            {
                Menu();
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        

            ReadKey();
        }
    }
}