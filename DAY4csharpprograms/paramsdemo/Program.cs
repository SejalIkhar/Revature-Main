// See https://aka.ms/new-console-template for more informatio
//Params keyword
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Sum(1, 2, 3));       // 6
        Console.WriteLine(Sum(10, 20));        // 30
        Console.WriteLine(Sum());              // 0

        int[] arr = { 5, 5, 5 };
        Console.WriteLine(Sum(arr));           // 15
    }

    static int Sum(params int[] numbers)
    {
        int total = 0;

        foreach (int n in numbers)
            total += n;

        return total;
    }
}

