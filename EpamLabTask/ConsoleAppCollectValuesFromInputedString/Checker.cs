using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace ConsoleAppCollectValuesFromInputedString
{
  public static  class Checker
    {
        public static bool IsDouble(string line)
        {
            char separator = Convert.ToChar(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
            string pattern = @"\-?\d+(\.\d{0,})?";
            double x = 0;
            if (line.Contains(separator.ToString())&& Regex.IsMatch(line, pattern)&& double.TryParse(line,out x))
                {
                    return true;
                }
            else
            {
                return false;
            }
        }

        public static bool IsInteger(string line)
        {
            string pattern = @"\-?\d";
            int x = 0;
            if(Regex.IsMatch(line,pattern)&& int.TryParse(line,out x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
