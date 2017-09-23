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

        private static void Menu()
        {
            WriteLine("Press '1' to get Text from file\nPress '2' to input text from console\nPress '3' to use my file\n Press '4'to exit");
            string select = ReadLine();
            switch (select)
            {      
                

                case "1":
                    string textFromFile = null;
                    WriteLine("input the path:");
                    string path = ReadLine();
                    try
                    {
                        textFromFile = ReadTextFromFile(path);
                    }
                    catch(IOException ex)
                    {
                       WriteLine( ex.StackTrace);
                    }
                    string result= ManageMethod(textFromFile);
                    WriteLine(result);
                    break;

                case "2":
                    WriteLine("Input text:");
                    string textFromConsole = ReadLine();
                     WriteLine(ManageMethod(textFromConsole));
                    break;

                case "3":
                    string textFromMyFile = null;
                    try
                    {
                        textFromMyFile = ReadTextFromFile(@".\TextFile.txt");
                    }
                    catch (IOException ex)
                    {
                        WriteLine(ex.StackTrace);
                    }
                   WriteLine( ManageMethod(textFromMyFile));

                    break;
                case "4": break;
            }


        }

        private static string ManageMethod(string text)
        {
            string[] strArr = SplitTextOnSentences(text);
            var listStrBuilder = ChangeUpperCaseLiteralsToLowerCase(strArr);
            var finalString = AddCurrentDateTime(listStrBuilder);
            return finalString;

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

            Console.ReadKey();
        }
    }
}