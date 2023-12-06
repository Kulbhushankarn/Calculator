using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public class Class1
    {
        public static int PerformOperation(int a, int b, char operation)
        {
            int result = 0;

            switch (operation)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    if (b != 0)
                        result = a / b;
                    else
                        Console.WriteLine("Division by zero is not allowed.");
                    break;
                case '%':
                    if (b != 0)
                        result = a % b;
                    else
                        Console.WriteLine("Modulus by zero is not allowed.");
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            return result;
        }
    }
}