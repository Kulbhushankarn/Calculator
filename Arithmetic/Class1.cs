using System;

namespace Arithmetic
{
    public class Class1
    {
        public static void PerformOperation(ref double currentNumber, string inputExpression, char operatorKey, string Notation)
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
                    case '^':
                        currentNumber = Math.Pow(currentNumber, operand);
                        break;

                    default:
                        Console.Write($"\nError: Invalid operator '{operatorKey}'.");
                        break;
                }

                Console.Write($"\n{CalculateResult(currentNumber, Notation)}");
            }
        }

        public static string CalculateResult(double number, string notation)
        {
            if (notation == "F-E")
                return string.Format("{0:0.#####e+0}", number);
            return number.ToString();
        }
    }
}
