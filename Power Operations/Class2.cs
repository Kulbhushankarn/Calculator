using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Operations
{
    public class Class2
    {
        public double PerformOperation(int num1, int num2, string operation)
        {
            double result = 0.0;
            switch (operation)
            {
                case "cubeRoot":
                    result = CubeRoot(num1);
                    break;
                case "squareRoot":
                    result = SquareRoot(num1);
                    break;
                default:
                    throw new ArgumentException("Invalid operation");
            }
            return result;
        }

        private double CubeRoot(int x)
        {
            return Math.Pow(x, 1.0 / 3.0);
        }

        private double SquareRoot(int x)
        {
            return Math.Sqrt(x);
        }
    }
}
