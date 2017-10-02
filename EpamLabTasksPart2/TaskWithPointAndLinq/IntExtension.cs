using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TaskWithPointAndLinq
{
  public static  class IntExtension
    {
        public static bool IsIntSimple(this BigInteger x)
        {
            for (int i = 2; i <= (x / 2); i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;

        }


    }
}
