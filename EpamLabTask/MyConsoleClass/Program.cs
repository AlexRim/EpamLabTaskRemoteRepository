using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCalcLibrary;
using static System.Console;
using System.Configuration;


namespace MyConsoleClass
{
    class Program
    {


      


        private static void ChooseMethodToCalculateValueGetFromConfigurationFile()
        {
            WriteLine("Input key:\n" + "key0:if You want to use ConsoleClassMethod" + "\n" + "key1:if You want to use LibraryMethod");
            var key= ReadLine();
            var val= ConfigurationManager.AppSettings[key];
            switch (val)
            {
                case "0": AddTwoIntegersMethod(); break;
                case "1": UseLibraryMethods(); break;
                default: WriteLine("Wrong key was inputed!"); break;
            }
                             
        }




        private static void UseLibraryMethods()
        {
            var calc = new MyCalcClass();

            int x = 0;
            int y = 0;
            while (true)
            {        
                WriteLine("Input first value:");
                var integer1 = ReadLine();
                WriteLine("Input second value:");
                var integer2 = ReadLine();

                if (Int32.TryParse(integer1, out x) && Int32.TryParse(integer2, out y))
                {

                    WriteLine("Sum={0}", calc.Add(x, y));
                    try
                    {
                        WriteLine("Division Result={0}", calc.Divide(x, y));
                    }
                    catch (DivideByZeroException ex)
                    {
                        WriteLine(ex.Message);
                    }
                    WriteLine("Multyply Result={0}", calc.Multyply(x, y));
                    WriteLine("Substract Result={0}", calc.Substract(x, y));
                    break;
                }
                else
                {
                    WriteLine("One of params has wrong format or size!" + "\n");
                    continue;
                }

            }
        }

        private static void AddTwoIntegersMethod()
        {
            int x = 0;
            int y = 0;

            while (true)
            {
                
             
                WriteLine("Input first value:");
                var integer1 = ReadLine();
                WriteLine("Input second value:");
                var integer2 = ReadLine();

                if (Int32.TryParse(integer1, out x) && Int32.TryParse(integer2, out y))
                {
                    int sum = y + x;
                    WriteLine("Sum={0}", sum);
                    break;
                }
                else
                {
                    WriteLine("One of params has wrong format!"+"\n");
                    continue;
                }
            }



        }


        static void Main(string[] args)
        {
          var i=  Resource1.String1;
         
            try
            {
                ChooseMethodToCalculateValueGetFromConfigurationFile();


            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
               
            }
            ReadKey();
        }
    }
}
