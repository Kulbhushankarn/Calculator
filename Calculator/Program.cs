using System;
using Arithmetic; 
using Power_Operations; 

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            char operation;
            bool validOperation = false;

            Console.Write("Enter the first number: ");
            if (int.TryParse(Console.ReadLine(), out num1))
            {
                Console.Write("Enter the second number: ");
                if (int.TryParse(Console.ReadLine(), out num2))
                {
 
                    do
                    {
                        Console.Write("Select an operation (+, -, *, /, %, CubeRoot(√), SquareRoot(x)): ");
                        operation = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        switch (operation)
                        {
                            case '+':
                            case '-':
                            case '*':
                            case '/':
                            case '%':
                            case '√':
                            case 'x':
                                validOperation = true;
                                break;
                            default:
                                Console.WriteLine("Invalid operation. Please select from the options.");
                                break;
                        }
                    } while (!validOperation);

                    int result = 0;
                   
                    if (operation == '+' || operation == '-' || operation == '*' || operation == '/' || operation == '%')
                    {
                        result = Class1.PerformOperation(num1, num2, operation);
                        Console.WriteLine($"Result of {num1} {operation} {num2} is: {result}");
                    }

                    else if (operation == '√' || operation == 'x')
                    {
                        double doubleResult = Class2.PerformOperation(num1, num2, operation);
                        Console.WriteLine($"Result of {num1} {operation} {num2} is: {doubleResult}");
                    }
                   
                }

                else
                {
                    Console.WriteLine("Invalid input for the second number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for the first number.");
            }
        }
    }
}