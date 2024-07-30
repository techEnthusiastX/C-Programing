using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace functionoverloading
{
    class Calculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            int result1 = calculator.Add(5, 10);
            double result2 = calculator.Add(2.5, 3.7);

            Console.WriteLine("Result 1: " + result1);
            Console.WriteLine("Result 2: " + result2);

            Console.ReadLine();
        }
    }

}
