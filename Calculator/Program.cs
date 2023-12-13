using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic;
using Power;

namespace Scientific_Calculator
{
    internal class Program
    {
        static string staticVar1 = "DEG";
        static string staticVar2 = "!F-E";

        public static void Main(string[] args)
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Key Mapping");
            KeyMapping();


            // Move the cursor to a specific position
            Console.SetCursorPosition(0, 0);


            Console.WriteLine();
            Console.WriteLine($"{staticVar1} | {staticVar2}");

            StringBuilder inputExpression = new StringBuilder("0");
            StringBuilder number = new StringBuilder();

            ConsoleKeyInfo keyInfo;
            char inputChar;
            double currentNumber = 0;
            double result = 0;
            char op = '+';
            Console.Write(currentNumber);

            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Delete)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {

                    if (number.Length > 0)
                    {
                        number.Length -= 1;
                        Console.Write("\b \b");
                    }
                }
                else if (keyInfo.Key == ConsoleKey.E && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    staticVar2 = "F-E";
                    ClearStatusLine(staticVar2);
                }
                else if (keyInfo.Key == ConsoleKey.F && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    staticVar2 = "!F-E";
                    ClearStatusLine(staticVar2);
                }

                else if (keyInfo.Key == ConsoleKey.P && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    staticVar1 = "RAD";
                    ClearStatusLine(staticVar1);

                }
                else if (keyInfo.Key == ConsoleKey.Q && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    staticVar1 = "DEG";
                    ClearStatusLine(staticVar1);

                }
                else if (keyInfo.Key == ConsoleKey.R && keyInfo.Modifiers == ConsoleModifiers.Control)
                {

                    staticVar1 = "GRAD";
                    ClearStatusLine(staticVar1);
                }

                else if (keyInfo.Key == ConsoleKey.M && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    inputExpression.Clear();
                    Console.Clear();
                    Environment.Exit(0);
                }
                else if (keyInfo.Key == ConsoleKey.Z && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    inputExpression.Clear();
                    number.Clear();
                    currentNumber = 0;
                    ClearConsoleExceptFirstTwoLine();

                }

                else if (IsValidInputKey(keyInfo.KeyChar))
                {

                    inputChar = keyInfo.KeyChar;

                    if (IsOperatorKey(inputChar))
                    {

                        inputExpression.Append(number.ToString());
                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            ClearConsoleExceptFirstTwoLine();
                            inputExpression.Clear();
                            inputExpression.Append(currentNumber).Append(inputChar);
                            Console.Write(inputExpression);
                            Console.Write($"\n{currentNumber}");
                            op = inputChar;
                        }
                        else if (inputExpression.Length != 0 && IsOperatorKey(inputExpression[inputExpression.Length - 1]))
                        {
                            ClearConsoleExceptFirstTwoLine();
                            inputExpression.Remove(inputExpression.Length - 1, 1);
                            inputExpression.Append(inputChar);
                            Console.Write(inputExpression);
                            op = inputChar;
                            Console.Write($"\n{currentNumber}");
                            number.Clear();
                        }
                        else
                        {
                            ClearConsoleExceptFirstTwoLine();
                            inputExpression.Append(inputChar);
                            Console.Write(inputExpression);
                            Class1.PerformOperation(ref currentNumber, number.ToString(), op, staticVar2);
                            op = inputChar;
                            number.Clear();
                        }
                        number.Clear();

                    }


                    else if (char.IsDigit(inputChar) || inputChar == '.')
                    {
                        if (number.Length == 0)
                        {
                            ClearCurrentConsoleLine();
                        }
                        if (inputExpression.Length > 0 && inputExpression[0] == '0')
                        {
                            inputExpression.Clear();
                        }
                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            ClearConsoleExceptFirstTwoLine();
                            number.Clear();
                            inputExpression.Clear();
                            currentNumber = 0;
                            op = '+';
                        }

                        number.Append(inputChar);
                        Console.Write(inputChar);
                        result = Convert.ToDouble(number.ToString());

                    }

                    else if (inputChar == '=')
                    {
                        if (inputExpression.Length != 0 && inputExpression[inputExpression.Length - 1] == '=')
                        {
                            continue;
                        }
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append(number.ToString()).Append('=');
                        Console.Write(inputExpression);
                        Class1.PerformOperation(ref currentNumber, number.ToString(), op, staticVar2);
                        number.Clear();
                    }

                    else if (inputChar == 's' || inputChar == 'c' || inputChar == 't' || inputChar == 'L' || inputChar == 'O'
                        || inputChar == 'S' || inputChar == 'C' || inputChar == 'T' || inputChar == 'Q' || inputChar == '#' || inputChar == 'q' ||
                        inputChar == 'Z' || inputChar == 'z' || inputChar == 'b' || inputChar == 'f' || inputChar == 'i' || inputChar == 'A' ||
                        inputChar == 'e' || inputChar == 'E' || inputChar == 'p' || inputChar == 'F' || inputChar == 'B' || inputChar == 'd' || inputChar == 'r'
                        || inputChar == 'g' || inputChar == 'G' || inputChar == 'h' || inputChar == 'H' || inputChar == 'k' || inputChar == 'K' || inputChar == 'l'
                        || inputChar == 'm' || inputChar == 'n')
                    {
                        IsTrigonometricFunctionKey(inputChar);


                    }


                    /* else if (inputChar == 'J' || inputChar == 'H' || inputChar == 'I' || inputChar == 'J')
                     {
                         ClearConsoleExceptFirstLine();
                         inputExpression.Append(inputChar);
                         Console.Write(inputExpression);
                         Class1.PerformOperation(ref currentNumber, number.ToString(), op);
                         op = inputChar;
                         number.Clear();
                     }*/



                }
            } while (true);

            bool IsValidInputKey(char input)
            {
                char[] allowedKeys = { 'Q', 'M', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '+',
                    '-', '*', '/', '=', 'S', 's', 'C', 'c', 'T', 't', ')', 'L', 'O', '=','Q','#','q','Z','z'
                    ,'b','f','i','A','e','p','E','F','B','d','r','J','G','g','h','H','k','K','l','m','n'};

                return Array.IndexOf(allowedKeys, input) != -1;
            }

            bool IsOperatorKey(char c)
            {
                return c == '+' || c == '-' || c == '*' || c == '/' || c == ')';
            }
            void IsTrigonometricFunctionKey(char c)
            {
                switch (c)
                {
                    case 's':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "sin(" + number).Append(")");
                        /*// StringBuilder a = number;
                        //number.Insert(0, "sin(" + number).Append(")");
                        //  inputExpression.Append(number.Insert(0, "sin(").Append(")"));
                        number.Insert(0, "sin(").Append(")");
                        Console.Write(inputExpression.ToString()+number.ToString());*/
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Sine(CalculateTrigonometricValue(result, staticVar1));
                        break;

                    case 'c':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cos(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Cosine(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 't':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "tan(" + number).Append(")");
                        Console.Write(inputExpression);

                        currentNumber = PowerOperations.Tangent(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'S':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "sin^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);

                        currentNumber = PowerOperations.SineInverse(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'C':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cos^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CosineInverse(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'T':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "tan^(-1)(" + number).Append(")"); ;
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.TangentInverse(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'g':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Cosec(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Cosec(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'G':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cosec^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CosecInverse(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'h':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Sec(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Sec(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'H':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Sec^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.SecInverse(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'k':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Cot(" + number).Append(")"); ;
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Cot(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'K':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Cot^(-1)(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CotInverse(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'l':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "sinh(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.SineHyp(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'm':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cosh(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CosineHyp(CalculateTrigonometricValue(result, staticVar1));
                        break;
                    case 'n':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "tanh(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.TangentHyp(CalculateTrigonometricValue(result, staticVar1));
                        break;




                    case 'L':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Log" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Log(result, 10);
                        break;
                    case 'O':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Ln" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Ln(result);
                        break;

                    case 'Q':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "sqr(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Exponentiation(result, 2);
                        break;
                    case '#':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "Cube(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Exponentiation(result, 3);
                        break;
                    case 'q':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "√(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.SquareRoot(result);
                        break;
                    case 'Z':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "cuberoot(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CubeRoot(result);
                        break;
                    case 'z':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "10^(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Exponentiation(10, result);
                        break;
                    case 'b':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "2^(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Exponentiation(2, result);
                        break;
                    case 'f':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "fact(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.Factorial(result);
                        break;
                    case 'i':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "1/(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.inverse(result);
                        break;
                    case 'A':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "abs(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.AbsoluteFunction(result);
                        break;
                    case 'E':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "e^(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.ePowerx(result);
                        break;
                    case 'e':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append("2.7182818284590452353602874713527");
                        currentNumber = 2.7182818284590452353602874713527;
                        break;
                    case 'p':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append("3.1415926535897932384626433832795");
                        currentNumber = 3.1415926535897932384626433832795;
                        break;
                    case 'r':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Append(PowerOperations.RandomFunction().ToString());
                        currentNumber = PowerOperations.RandomFunction();
                        break;
                    case 'F':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "floor(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.FloorFunction(result);
                        break;
                    case 'B':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "ceil(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.CeilingFunction(result);
                        break;


                    case 'd':
                        ClearConsoleExceptFirstTwoLine();
                        inputExpression.Insert(0, "dms(" + number).Append(")");
                        Console.Write(inputExpression);
                        currentNumber = PowerOperations.ConvertToDMS(result);
                        break;



                }
                Console.Write($"\n{currentNumber}");
                result = currentNumber;




            }



        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        static void ClearConsoleExceptFirstTwoLine()
        {
            Console.SetCursorPosition(0, 2); // Move cursor to the beginning of the second line
            int currentLineCursor = Console.CursorTop;
            for (int i = 2; i <= currentLineCursor + 3; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth)); // Clear each line from the second line onward
            }
            Console.SetCursorPosition(0, 2); // Move cursor back to the beginning of the second line
        }

        public static void ClearStatusLine(String status)
        {
            int originalLeft = Console.CursorLeft;
            int originalTop = Console.CursorTop;
            Console.SetCursorPosition(0, 1);
            //  Console.SetCursorPosition(0, Console.CursorTop - 2);
            // Clear the line and write new content
            Console.Write(new string(' ', Console.WindowWidth - 1)); // Clear the line
            Console.SetCursorPosition(0, Console.CursorTop); // Move back to the beginning of the line
            Console.Write($"{staticVar1} | {staticVar2}");
            // Restore the original cursor position
            Console.SetCursorPosition(originalLeft, originalTop);
        }



        static double CalculateTrigonometricValue(double angle, string inputUnit)
        {
            double angleRad;

            switch (inputUnit)
            {
                case "RAD":
                    angleRad = angle;
                    break;
                case "DEG":
                    angleRad = Math.PI * angle / 180.0;
                    break;
                case "GRAD":
                    angleRad = Math.PI * angle * 0.9 / 180.0;
                    break;
                default:
                    throw new ArgumentException("Invalid unit. Supported units are 'radian', 'degree', and 'gradian'.");
            }
            return angleRad;


        }

        public static void KeyMapping()
        {

            KeyMapping1("RAD -  ctrl+P", "DEG-  ctrl+Q", "GRAD  - ctrl+R", 12);
            KeyMapping1("F-E  -  ctrl+E", "!F-E  -  ctrl+F", "Exist  - ctrl+M", 13);
            KeyMapping1("Sin -  s", "Sin^(-1) -  S", "Sinh -  l", 15);
            KeyMapping1("Cos -  c", "Cos^(-1) -  C", "Cosh -  m", 16);
            KeyMapping1("tan -  t", "tan^(-1) -  T", "tanh -  n", 17);
            KeyMapping1("Cosec -  g", "Cosec^(-1) -  G", " ", 18);
            KeyMapping1("Sec -  h", "Sec^(-1) -  H", " ", 19);
            KeyMapping1("Cot -  k", "Cot^(-1) -  K", " ", 20);
            KeyMapping1("Log   -  L", "ln  - O", " ", 22);
            KeyMapping1("Square  -  Q", "Cube  -  #", "SquareRoot - q", 23);
            KeyMapping1("CubeRoot  -  Z", "10^x  -  z", "2^x  - b", 24);
            KeyMapping1("Factorial  -  f", "1/X  -  i", "Absolute - A", 25);
            KeyMapping1("e^x  -  E", "floor  -  F", "Ceil - B", 26);
            KeyMapping1("dms  -  d", "  ", "  ", 27);
            KeyMapping1("Pie  -  p", "Random  -  r", "e  - e", 29);


        }
        public static void KeyMapping1(string c1, string c2, string c3, int row)
        {
            Console.SetCursorPosition(0, row);
            Console.Write($"{c1}");
            Console.SetCursorPosition(30, row);
            Console.Write($"{c2}");
            Console.SetCursorPosition(60, row);
            Console.Write($"{c3}");

        }
    }
}