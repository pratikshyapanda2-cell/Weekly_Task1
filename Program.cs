
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Simple Calculator (C#) ===");
        Console.WriteLine("Basic: +  -  *  /");
        Console.WriteLine("Scientific: sin  cos  sqrt");
        Console.WriteLine("Type 'exit' to quit.\n");

        while (true)
        {
            Console.Write("Enter operation: ");
            string op = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrEmpty(op)) continue;
            if (op == "exit") break;

            try
            {
                double result;

                // Scientific functions that take one operand
                if (op == "sin" || op == "cos" || op == "sqrt")
                {
                    double x = ReadDouble("Enter value: ");

                    // If you prefer degrees for sin/cos:
                    // x = x * Math.PI / 180.0;

                    result = op switch
                    {
                        "sin" => Math.Sin(x),
                        "cos" => Math.Cos(x),
                        "sqrt" => Math.Sqrt(x),
                        _ => double.NaN
                    };
                }
                else // Binary operations that take two operands
                {
                    double a = ReadDouble("Enter first number: ");
                    double b = ReadDouble("Enter second number: ");

                    result = op switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => b == 0 ? throw new DivideByZeroException() : a / b,
                        _ => throw new InvalidOperationException("Unknown operation.")
                    };
                }

                Console.WriteLine($"Result: {result}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double value))
                return value;
            Console.WriteLine("Invalid number. Try again.");
        }
    }
}
