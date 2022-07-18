using System;

namespace Calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first value");
            var first = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter opperation");
            var operation = Console.ReadLine();

            Console.WriteLine("Enter second value");
            var second = double.Parse(Console.ReadLine());

            double result;

            /*if (opperation == "+")
                result = first + second;
            else if (opperation == "-")
                result = first - second;
            else if (opperation == "*")
                result = second * first;
            else
                throw new ArgumentException("Wrong operator");*/

            switch (operation)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = second * first;
                    break;
                case "/":
                    result = first / second;
                    break;
                default:
                    throw new ArgumentException("Wrong operator");
            }

            Console.WriteLine(Math.Round(result, 2));
        }
    }
}
