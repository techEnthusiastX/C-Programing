using System;

// Delegate declaration
delegate void MathOperation(int x, int y);

class Program
{
    static void Main(string[] args)
    {
        // Create delegate instances
        MathOperation addDelegate = Add;
        MathOperation subtractDelegate = Subtract;
        MathOperation multiplyDelegate = Multiply;

        // Perform operations using delegates
        PerformOperation(5, 3, addDelegate);
        PerformOperation(5, 3, subtractDelegate);
        PerformOperation(5, 3, multiplyDelegate);

        Console.ReadLine();
    }

    static void PerformOperation(int x, int y, MathOperation operation)
    {
        Console.Write("Result of operation ({x}, {y}): ");
        operation(x, y);
    }

    static void Add(int x, int y)
    {
        Console.WriteLine(x + y);
    }

    static void Subtract(int x, int y)
    {
        Console.WriteLine(x - y);
    }

    static void Multiply(int x, int y)
    {
        Console.WriteLine(x * y);
    }
}
