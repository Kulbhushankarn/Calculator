using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public class Class1
    {
        public static void PerformOperation(ref double currentNumber, string inputExpression, char operatorKey, String Notation)
        {

            if (!string.IsNullOrEmpty(inputExpression))
            {
                double operand = Convert.ToDouble(inputExpression);
                switch (operatorKey)
                {
                    case '+':
                        currentNumber += operand;
                        break;
                    case '-':
                        currentNumber -= operand;
                        break;
                    case '*':
                        currentNumber *= operand;
                        break;
                    /* case 'J':
                         currentNumber %= operand;
                         break;*/
                    case '/':

                        if (operand != 0)
                        {
                            currentNumber /= operand;
                        }
                        else
                        {
                            Console.WriteLine("\nError: Division by zero.");
                        }
                        break;

                    default:
                        Console.Write($"\nError: Invalid operator '{operatorKey}'.");
                        break;
                }

                Console.Write($"\n{ScientificNotation(currentNumber, Notation)}");
            }

        }

        public static string ScientificNotation(double number, string inputformat)
        {
            if (inputformat == "F-E")

                return string.Format("{0:0.#####e+0}", number);
            return number.ToString();

        }
    }
}