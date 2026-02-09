// See https://aka.ms/new-console-template for more information
//local functions
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Fibonacci(6)); // 8
    }

    static int Fibonacci(int n)
    {
        int Fib(int k)
        {
            if (k < 2)
                return k;

            return Fib(k - 1) + Fib(k - 2);
        }

        return Fib(n);
    }
}
/*
Fib(6)
= Fib(5) + Fib(4)
= (Fib(4) + Fib(3)) + (Fib(3) + Fib(2))
= (3 + 2) + (2 + 1)
= 5 + 3
= 8

*/
