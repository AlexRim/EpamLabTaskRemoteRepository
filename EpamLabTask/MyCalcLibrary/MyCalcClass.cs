﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyCalcLibrary
{
   public class MyCalcClass
    {
        public int Add(int x, int y) => x + y;

        public double Divide(double x, double y)
        {
           
            if(y==0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                return x / y;
            }
          
        }


        public long Multiply(int x, int y) => x * y;


        public int Substract(int x, int y) => x - y;




    }
}
