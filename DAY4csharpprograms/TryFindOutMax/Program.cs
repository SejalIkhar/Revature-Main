// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 3, 9, 1, 7 ,13};//array creation

        // ---- OUT PARAMETER VERSION ----
        if (TryFindMax_Out(numbers, out int max1))
        {
            Console.WriteLine($"[OUT] Max value = {max1}");
        }
        else
        {
            Console.WriteLine("[OUT] No max found");
        }

        // ---- TUPLE VERSION ----
        var (success, max2) = TryFindMax_Tuple(numbers);

        if (success)
        {
            Console.WriteLine($"[TUPLE] Max value = {max2}");
        }
        else
        {
            Console.WriteLine("[TUPLE] No max found");
        }
    }

    // OUT parameter version
    static bool TryFindMax_Out(int[] numbers, out int max)
    {
        if (numbers == null || numbers.Length == 0)
        {
            max = default;
            return false;
        }

        max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return true;
    }

    // Tuple version
    static (bool success, int max) TryFindMax_Tuple(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
        {
            return (false, default);
        }

        int max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return (true, max);
    }
}

