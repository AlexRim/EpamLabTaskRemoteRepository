using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;
using EquationLibrary;
using System.IO;
using System.Configuration;


namespace TaskRunner
{
    class Program
    {

        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static void PrintMenu()
        {
            WriteLine("Input '1' to get quadratic equation\nInput '2' to get the linear equation\nInput '3' to MultyPly matrix from file Data.txt ");
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
                   log.Info("Wrong input:"+line);
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
                   log.Info("Quadratic equation: X1="+String.Format("{0:0.00}",getQuadraticRoots.QadraticRoots[0])+" X2="+
                        String.Format("{0:0.00}", getQuadraticRoots.QadraticRoots[1]));

                    break;

                case "2":
                    var coefficientsL = InputValuesForEquation(2);
                    var getLinearRoots = new GetRoots(coefficientsL[0], coefficientsL[1]);
                   log.Info("Linear equation: X = " + String.Format("{ 0:0.00}", getLinearRoots.RootLine));
                           
                    break;
                case "3":
                    GetStringValuesFromSplitedText();
                    break;

                default:
                    break;

            }





        }

        private static void Print(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0:0.00} ", a[i, j]));
                }
                Console.WriteLine();
            }
        }


        private static void GetStringValuesFromSplitedText()
        {
          var   fileName = ConfigurationManager.AppSettings["Key"];
            string line = "";
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    line = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string[] arr = line.Split(';');

            var lines1 = arr[0].Trim().Split('\n');

            int firstMatrixRowsCount = lines1.Length;
            int firstMatrixColumnCount = lines1[0].Trim().Split().Length;

            var lines2 = arr[1].Trim().Split('\n');

            int secondMatrixRowsCount = lines2.Length;
            int secondMatrixColumnCount = lines2[0].Trim().Split().Length;

            var firstStringMatrix=string.Empty;

            foreach(var i in lines1)
            {
                firstStringMatrix += i;
            }

            var secondStringMatrix = string.Empty;

            foreach (var i in lines2)
            {
                secondStringMatrix += i;
            }

            var chars1 = firstStringMatrix.ToCharArray();

            for (int i = 0; i < chars1.Length; i++)
            {
                if(chars1[i]=='\r')
                {
                    chars1[i] = ' ';
                }

            }

            var chars2 = secondStringMatrix.ToCharArray();

            for (int i = 0; i < chars2.Length; i++)
            {
                if (chars2[i] == '\r')
                {
                    chars2[i] = ' ';
                }

            }

            var first = new string(chars1).Trim().Split().Select(x => Convert.ToDouble(x)).ToArray();
            var second=new string(chars2).Split().Select(x => Convert.ToDouble(x)).ToArray();

            double[,] firstMatrix = new double[firstMatrixRowsCount, firstMatrixColumnCount];
            double[,] secondMatrix = new double[secondMatrixRowsCount, secondMatrixColumnCount];

            int k = 0;
            for (int i = 0; i < firstMatrixRowsCount; i++)
            {
                for (int j = 0; j < firstMatrixColumnCount; j++)
                {
                    firstMatrix[i, j] = first[k];
                    k++;

                }
              
            }
            k = 0;
            for (int i = 0; i < secondMatrixRowsCount; i++)
            {
                for (int j = 0; j < secondMatrixColumnCount; j++)
                {
                    secondMatrix[i, j] = second[k];
                    k++;
                }
           
            }

            double[,] multyPlyResult = GetRoots.MultyPlyMatrix(firstMatrix, secondMatrix);
            Print(multyPlyResult);

        }









        static void Main(string[] args)
        {
            
            try
            {           
               Menu();
            }
            catch (NotTheEquationException ex )
            {
                log.Error(ex.Message);
            }
            catch(NegativeDiscriminantException ex)
            {
                log.Error(ex.Message);
            }
           catch (Exception ex)
            {
                WriteLine(ex.StackTrace);
                log.Error(ex.Message);
            }




            ReadKey();
        }
    }
}
