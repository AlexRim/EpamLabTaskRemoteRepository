using System;
using static System.Math;

using System.IO;
namespace EquationLibrary
{
    public class GetRoots
    {
        private double a;

        private double b;

        private double c;

        private double [] qadraticRoots;

        private double rootLine;

        public double[] QadraticRoots { get => qadraticRoots; }

        public double RootLine { get => rootLine; }

  
        public GetRoots(double a, double b, double c)
        {
            if(a==0 && b==0)
            {
                throw new NotTheEquationException("First two parameters cant be equal 0!");
            }
            this.a = a;
            this.b = b;
            this.c = c;
            GetRootsIfQuadratic();

        }

        public GetRoots(double b, double c)
        {
            if(b==0)
            {
                throw new NotTheEquationException("First parameter cant be equal 0!");
            }
            this.b=b;
            this.c=c;
            GetRootsIfLine();
        }

        private void GetRootsIfQuadratic()
        {
            double D = Pow(this.b, 2) - 4 * this.a * this.c;
            if(D<0)
            {
                throw new NegativeDiscriminantException("Discriminant<0 , there are no roots!");
            }
            else if(D>=0)
            {
               qadraticRoots = new double[2];
               qadraticRoots[0] = (-this.b + Sqrt(D)) / 2 * this.a;
               qadraticRoots[1]= (-this.b -Sqrt(D)) / 2 * this.a;
            }
        
        }
            
         private void GetRootsIfLine()
            {
                 this.rootLine = -c / b;
            }


       public static double[,] MultyPlyMatrix(double[,] a, double[,] b)
        {
            double[,] c = new double[a.GetLength(0), b.GetLength(1)];

            if (a.GetLength(1) == b.GetLength(0))
            {

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {

                        for (int k = 0; k < b.GetLength(0); k++)
                        {
                            c[i, j] += a[i, k] * b[k, j];
                        }


                    }



                }


            }

            else
            {
                throw new Exception("This action can't be done!");
            }

            return c;

        }


    }
}
