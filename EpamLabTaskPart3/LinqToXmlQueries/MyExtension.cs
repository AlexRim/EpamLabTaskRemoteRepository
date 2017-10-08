using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LinqToXmlQueries
{
    public static class MyExtensions
    {
        public static string FormatingDoubleValue(this string str) => str.Replace('.', ',');

        public static double ConvertToDoubleValue(this string str) => double.Parse(str.Replace('.', ','));

        public static string ConvertDateTimeFormat(this string str) => DateTime.Parse(str).ToShortDateString();

        public static DateTime ConvertToDateTime(this string str) => DateTime.Parse(str);

        public static bool NoneNumberFormat(this string str) => str.All(char.IsDigit);

        public static bool PhoneCodeDoesntMatch(this string str)
        {
            Regex regex = new Regex(@"^(\d+)");
            if (regex.IsMatch(str))
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
