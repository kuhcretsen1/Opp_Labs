using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string str = "a, 1, 2, f, -1, 0, 4, 10, 4, f, 4f, 8, 9, 3";
        
        var numbers = str.Split(',')
            .Select(s => s.Trim())
            .Where(s => double.TryParse(s, out _)) 
            .Select(double.Parse)
            .OrderBy(n => n) 
            .Skip(3) 
            .Sum(); 

        Console.WriteLine($"Sum of numbers excluding the three smallest: {numbers}");
    }
}