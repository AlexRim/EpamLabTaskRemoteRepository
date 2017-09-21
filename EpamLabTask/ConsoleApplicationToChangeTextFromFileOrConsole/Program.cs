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

        private static void AddNewLine(string text)
        {
            var st = new StringBuilder(text);

            for(int i=0; i<st.Length;i++)
            {
                if(st[i]=='.')
                {
                   
                }
            }

        }







        static void Main(string[] args)
        {
            string str = ReadTextFromFile(@".\TextFile.txt");
            Console.WriteLine(ChangeUpperCaseLiteralsToLowerCase(str));
            Console.ReadKey();
        }
    }
}