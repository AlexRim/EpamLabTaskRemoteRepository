using System;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationToChangeTextFromFileOrConsole
{
    class Program
    {


        private static string ReadTextFromFile(string path) => File.ReadAllText(path);

        private static string ChangeUpperCaseLiteralsToLowerCase(string text)
        {
            char[] myCharArray = text.ToCharArray();

            for (int i = 0; i < myCharArray.Length; i++)
            {
                if (char.IsUpper(myCharArray[i]))
                {
                    myCharArray[i] = char.ToLower(myCharArray[i]);
                }
            }

            string str = new string(myCharArray);
            return str;
        }









        static void Main(string[] args)
        {
            string str = ReadTextFromFile(@".\TextFile.txt");
            Console.WriteLine(ChangeUpperCaseLiteralsToLowerCase(str));
            Console.ReadKey();
        }
    }
}