// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose Demo:");
        Console.WriteLine("1 - ExecuteReader");
        Console.WriteLine("2 - ExecuteNonQuery");
        Console.WriteLine("3 - ExecuteScalar");
        Console.WriteLine("4 - DataAdapter");
        Console.WriteLine("5 - SQL Injection");
        Console.WriteLine("6 - Parameterized Query");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1": ExecuteReaderDemo.Run(); break;
            case "2": ExecuteNonQueryDemo.Run(); break;
            case "3": ExecuteScalarDemo.Run(); break;
            case "4": DataAdapterDemo.Run(); break;
            case "5": SqlInjectionDemo.Run(); break;
            case "6": ParameterizedQueryDemo.Run(); break;
            default: Console.WriteLine("Invalid choice"); break;
        }
    }
}