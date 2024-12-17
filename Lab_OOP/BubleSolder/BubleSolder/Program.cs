using System;

public class BubbleSorter
{
    public delegate bool SortDelegate(int a, int b);

    private const int ArrayLengthOffset = 1; 
    private const int LengthFactor = 1; 

    public void Sort(int[] array, SortDelegate sortDelegate)
    {
        int length = array.Length;
        for (int i = 0; i < length - ArrayLengthOffset; i++)
        {
            for (int j = 0; j < length - ArrayLengthOffset - i; j++)
            {
                if (!sortDelegate(array[j], array[j + ArrayLengthOffset]))
                {
                    Swap(ref array[j], ref array[j + ArrayLengthOffset]);
                }
            }
        }
    }

    public bool Ascending(int a, int b)
    {
        return a < b;
    }

    public bool Descending(int a, int b)
    {
        return a > b;
    }

    private void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}

class Program
{
    static void Main()
    {
        BubbleSorter sorter = new BubbleSorter();
        int[] numbers = { 5, 2, 9, 1, 5, 6 };

        Console.WriteLine("Original Array: " + string.Join(", ", numbers));

        sorter.Sort(numbers, sorter.Ascending);
        Console.WriteLine("Sorted Ascending: " + string.Join(", ", numbers));

        sorter.Sort(numbers, sorter.Descending);
        Console.WriteLine("Sorted Descending: " + string.Join(", ", numbers));
    }
}