using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWithPointAndLinq
{
  public static  class IntExtension
    {
        public static bool IsIntSimple(this int x)
        {
            for (int i = 2; i <= (int)(x / 2); i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;

        }


    }
}
