// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        string a = null;
        string b = "";
        string c = "Hello";

        Console.WriteLine(a.IsNullOrEmpty()); // true
        Console.WriteLine(b.IsNullOrEmpty()); // true
        Console.WriteLine(c.IsNullOrEmpty()); // false
    }
}

