// See https://aka.ms/new-console-template for more information
//Method Invocation
using System;

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        // ----- Using class method -----
        Calculator c = new Calculator();
        int result = c.Add(2, 3);
        Console.WriteLine("Class method result: " + result);

        // ----- Using Func and lambda -----
        Func<int, int, int> func = (x, y) => x + y;
        int r = func(3, 4);
        Console.WriteLine("Lambda result: " + r);
    }
}

