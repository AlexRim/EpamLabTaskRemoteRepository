using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;
using EquationLibrary;


namespace TaskRunner
{
    class Program
    {



        private static void PrintMenu()
        {
            WriteLine("Input '1' to get quadratic equation\nInput '2' to get the linear equation\n ");
        }

        private static double[] InputValuesForEquation( int coeficientCount)
        {
            var myArr = new string[] { "a", "b", "c" };
            var coefficients = new double[3];
            double x = 0;
            int i = 0;
            int j = 0;

            while (true)
            {
                WriteLine("Input {0}:", myArr[i]);
                i++;
                string line = ReadLine();
                if (double.TryParse(line, out x))
                {
                    coefficients[j] = x;
                    j++;
                    if ((j == 3 && coeficientCount == 3)||(j==2 && coeficientCount==2))
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
                    var coefficientsQ = InputValuesForEquation(3);
                    var getQuadraticRoots = new GetRoots(coefficientsQ[0], coefficientsQ[1], coefficientsQ[2]);                
                    foreach (var i in getQuadraticRoots.QadraticRoots)
                    {
                        WriteLine();
                        WriteLine(String.Format("{0:0.00}", i));                  
                    }
                    break;

                case "2":
                    var coefficientsL = InputValuesForEquation(2);
                    var getLinearRoots = new GetRoots(coefficientsL[0], coefficientsL[1]);
                    WriteLine(String.Format("{0:0.00}", getLinearRoots.RootLine));
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
            catch (NotTheEquationException ex )
            {
                WriteLine(ex.Message);
            }
            catch(NegativeDiscriminantException ex)
            {
                WriteLine(ex.Message);
            }
           catch (Exception ex)
            {
                WriteLine(ex.Message);
            }




            ReadKey();
        }
    }
}
