using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCalcLibrary;
using static System.Console;


namespace MyConsoleClass
{
    class Program
    {


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
            var m = new MyCalcClass();
          
 

            try
            {
                //  AddTwoIntegersMethod();
                WriteLine(m.Divide(17,0));
         
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
               
            }
            ReadKey();
        }
    }
}
