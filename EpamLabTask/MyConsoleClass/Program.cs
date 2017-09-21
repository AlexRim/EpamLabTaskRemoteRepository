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
        private static List<int> InputFromConsoleData()
        {
            int number = 0;
            var intList = new List<int>();

            while (intList.Count != 2)
            {
                WriteLine("Input {0} value:", intList.Count);
                var str = ReadLine();
               if(int.TryParse(str, out number))
                {
                    intList.Add(number);
                }
		        else
		        {
                    WriteLine("Wrong input format or size of variable ");
                    continue;
                }  
            }
                return intList;
        }

        private static int ConsoleAddMethod(List<int> list) => list[0] +list[1];

        private static List<int> DataFromResources()
        {
            int num1 = 0;
            int num2 = 0;

            var number1 = Resource1.String1;
            var number2 = Resource1.String2;

            var intList = new List<int>();

            if (int.TryParse(number1, out num1) && int.TryParse(number2, out num2))
            {
                intList.Add(num1);
                intList.Add(num2);
            }
            else
            {
                WriteLine("Variable(s) from resource file has(ve) wrong format or size");
            }

            return intList;
        }

        private static void PrintMenu() => WriteLine("Input: '1' task 'b' solution\n" + "Input '2' task 'e' solution\n" + 
            "Input: '3' task 'f' solution\n" + "Input '4' task i");

        private static void PrintResultsUsindLibraryClassMethods(int x, int y)
        {
            var myObj = new MyCalcClass();
            WriteLine(myObj.Add(x, y));
            WriteLine(myObj.Divide(x, y));
            WriteLine(myObj.Substract(x, y));
            WriteLine(myObj.Multiply(x, y));

        }


        private static void Calculate()
        {
            PrintMenu();
            string str = null;

            str = ReadLine();
            List<int> list;

            switch (str)
            {
                case "1":
                     list = InputFromConsoleData();
                    WriteLine(ConsoleAddMethod(list));
                    break;

                case "2":
                     list = InputFromConsoleData();
                    PrintResultsUsindLibraryClassMethods(list[0], list[1]);
                    break;

                case "3":
                     list = InputFromConsoleData();
                    WriteLine("Input 'key0' to use methods from library\n Input 'key1' to use method from this class\n");
                    string str1 = ReadLine();
                    var switchKey = ConfigurationManager.AppSettings[str1];
                    if (switchKey == "0")
                    {
                        PrintResultsUsindLibraryClassMethods(list[0], list[1]);
                    }
                    else if (switchKey == "1")
                    {
                        WriteLine(ConsoleAddMethod(list));
                    }
                    else
                    {
                        WriteLine("Wrong configuration parameter was inputed!");
                    }
                    break;


                case "4":
                    WriteLine("Input 'key0' to use methods from library\n Input 'key1' to use method from this class\n");
                    var str2 = ReadLine();
                    switchKey = ConfigurationManager.AppSettings[str2];
                    WriteLine("Input 'key2' to use data from file\n");
                    var str3 = ReadLine();
                    var switchKey1 = ConfigurationManager.AppSettings[str2];
                    
                    if (switchKey == "0" && switchKey1 == "2")
                    {
                         list = DataFromResources();
                        PrintResultsUsindLibraryClassMethods(list[0], list[1]);
                    }
                    else if (switchKey == "1" && switchKey1=="2")
                     {
     
                        list = DataFromResources();
                        WriteLine(ConsoleAddMethod(list));
                    }
 	                    else if (switchKey == "0" && switchKey1 != "2")
                    {
                         list = InputFromConsoleData();
                        PrintResultsUsindLibraryClassMethods(list[0], list[1]);
                    }
                    else if (switchKey == "1" && switchKey1 != "2")
                    {
                        list = InputFromConsoleData();
                        WriteLine(ConsoleAddMethod(list));
                    }
                    break;

            }








        }









        static void Main(string[] args)
        {
          
         
            try
            {

                Calculate();

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
               
            }
            ReadKey();
        }
    }
}
