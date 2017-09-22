using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Console;

namespace ConsoleApplicationToChangeTextFromFileOrConsole
{
    class Program
    {

        private static string ReadTextFromFile(string path) => File.ReadAllText(path);

        private static string[] SplitTextOnSentences(string text) => Regex.Split(text, @"(?<=['""A-Za-z0-9][\.\!\?])\s+(?=[A-Z])");

        private static List<StringBuilder> ChangeUpperCaseLiteralsToLowerCase(string [] splitTextArray)
        {
            var strBuildList = new List<StringBuilder>();
            foreach   (var i in splitTextArray)
            {
                var sr = new StringBuilder(i);              
                for (int j = 0; j < sr.Length; j++)
                {
                    if(char.IsUpper(sr[j]))
                    {
                        sr[j] = char.ToLower(i[j]);
                    }
                }
                sr.Append("\n");
                strBuildList.Add(sr);
            }
            return strBuildList;
        }

        private static string AddCurrentDateTime(List<StringBuilder> list)
        {
            string newText = null;

            foreach(var i in list)
            {
                newText +="["+DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff")+"] "+i.ToString();
            }

            return newText;
        }


        static void Main(string[] args)
        {
            string text = ReadTextFromFile(@".\TextFile.txt");
            string[] strArr = SplitTextOnSentences(text);
            var listStrBuilder = ChangeUpperCaseLiteralsToLowerCase(strArr);
            var finalString = AddCurrentDateTime(listStrBuilder);
            WriteLine(finalString);


            Console.ReadKey();
        }
    }
}