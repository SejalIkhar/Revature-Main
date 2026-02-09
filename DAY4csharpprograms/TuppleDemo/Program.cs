// See https://aka.ms/new-console-template for more information
//Method Parameters and Return Types
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40 };

        var result = Summarize(numbers);
        Console.WriteLine("Sum = " + result.sum);
        Console.WriteLine("Count = " + result.count);

        var (total, count) = Summarize(numbers);
        Console.WriteLine($"Total = {total}, Count = {count}");
    }

    public static (int sum, int count) Summarize(int[] items)
    {
        int sum = 0;

        foreach (int i in items)
            sum += i;

        return (sum, items.Length);
    }
}

