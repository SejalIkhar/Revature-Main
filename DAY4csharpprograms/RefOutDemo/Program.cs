// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        // ----- out example -----
        string input = "456";
        int value;

        bool isValid = TryParseInt(input, out value);
        Console.WriteLine($"Success: {isValid}, Value: {value}");

        // ----- ref example -----
        int x = 10;
        int y = 20;

        Console.WriteLine($"Before Swap: x = {x}, y = {y}");

        Swap(ref x, ref y);

        Console.WriteLine($"After Swap: x = {x}, y = {y}");
    }

    static bool TryParseInt(string s, out int value)
    {
        return int.TryParse(s, out value);
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}

