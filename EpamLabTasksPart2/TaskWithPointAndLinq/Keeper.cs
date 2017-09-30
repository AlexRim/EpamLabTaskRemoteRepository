using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWithPointAndLinq
{
 public   class Keeper
    {
        static int count;

       public static int Count { get => count;  }

        public Keeper()
        {
            count++;
        }

        public override string ToString()
        {
            return "[" + DateTime.Now.ToString() + "]" + count + " exempliars were created!";
        }
    }
}
