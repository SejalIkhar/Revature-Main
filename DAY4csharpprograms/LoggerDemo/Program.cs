// See https://aka.ms/new-console-template for more information
using System;

class Logger
{
    public void Log(string message)
    {
        Console.WriteLine($"[INFO] {message}");
    }

    public void Log(string message, string level)
    {
        Console.WriteLine($"[{level}] {message}");
    }

    public void Log(string message, params string[] tags)
    {
        Console.WriteLine($"[INFO] {message} | Tags: {string.Join(", ", tags)}");
    }
}

class Programs
{
    static void Main()
    {
        Logger logger = new Logger();

        logger.Log("Application started");
        logger.Log("Disk space low", "WARN");
        logger.Log("User login", "auth", "security");

        // ❌ Uncommenting this line will cause ambiguity error
        // logger.Log(message: "Database error", level: "ERROR");
    }
}
