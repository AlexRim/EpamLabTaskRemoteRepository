using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TaskWithPointAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            MyPoint myPoint = new MyPoint(1, 1);
            MyPoint myPoint1 = new MyPoint(1, 1);

            WriteLine(myPoint.Equals(myPoint1));

            ReadKey();


            
        }
    }
}
