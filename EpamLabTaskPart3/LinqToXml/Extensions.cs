using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LinqToXml
{
   static class Extensions
    {



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


        public static List<Customer> GetTask1List(this List<Customer> list, double x)=> list.Where(z =>z.Orders.Sum(y => y.Total) > x).ToList();

        public static List<IGrouping<string, Customer>> GetTask2List(this List<Customer> list)=>list.GroupBy(x => x.Country).ToList();

        public static List<Customer> GetTask3List(this List<Customer> list, double x) => list.Select(b=>b).Where(z => z.Orders.Select(y => y.Total).Max() > x).ToList(); 
           
    }
}
