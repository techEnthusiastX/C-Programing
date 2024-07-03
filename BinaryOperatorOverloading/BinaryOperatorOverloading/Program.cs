using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryOperatorOverloading
{
    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            int sumX = v1.X + v2.X;
            int sumY = v1.Y + v2.Y;
            return new Vector(sumX, sumY);
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }

    class Program
    {
        static void Main()
        {
            Vector vector1 = new Vector(2, 3);
            Vector vector2 = new Vector(4, 5);

            Vector sum = vector1 + vector2; // Adding two Vector objects using binary operator

            Console.WriteLine("Vector 1: " + vector1);
            Console.WriteLine("Vector 2: " + vector2);
            Console.WriteLine("Sum: " + sum);
            Console.ReadLine();
        }
    }


}
