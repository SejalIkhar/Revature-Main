// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        string s1 = "madam";
        string s2 = "A man, a plan, a canal: Panama";
        string s3 = "hello";

        Console.WriteLine(s1.IsPalindrome());
        Console.WriteLine(s2.IsPalindrome());
        Console.WriteLine(s3.IsPalindrome());
    }
}
