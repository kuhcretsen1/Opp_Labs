using Calculator;

internal class Program
{
    public static void Main(string[] args)
    {
        Calculator<bool> intCalculator = new Calculator<bool>();
        Calculator<double> doubleCalculator = new Calculator<double>();

        UseIntegerCalculator(intCalculator);
        UseDoubleCalculator(doubleCalculator);


    }
    public static void UseIntegerCalculator(Calculator<int> calculator)
    {
        Console.WriteLine("Using Integer Calculator:");
        Console.WriteLine($"Add: {calculator.Add(2, 3)}");
        Console.WriteLine($"Subtract: {calculator.Subtract(5, 3)}");
        Console.WriteLine($"Multiply: {calculator.Multiply(4, 5)}");
        Console.WriteLine($"Divide: {calculator.Divide(10, 2)}");
        Console.WriteLine($"Power: {calculator.Power(2, 3)}");
        Console.WriteLine();
    }

    public static void UseDoubleCalculator(Calculator<double> calculator)
    {
        Console.WriteLine("Using Double Calculator:");
        Console.WriteLine($"Add: {calculator.Add(2.5, 3.7)}");
        Console.WriteLine($"Subtract: {calculator.Subtract(5.5, 3.2)}");
        Console.WriteLine($"Multiply: {calculator.Multiply(4.5, 5.2)}");
        Console.WriteLine($"Divide: {calculator.Divide(10.5, 2.1)}");
        Console.WriteLine($"Power: {calculator.Power(2.5, 3)}");
        Console.WriteLine();
    }
}