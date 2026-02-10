// See https://aka.ms/new-console-template for more information
namespace DelegateDemo;
class Program
{
    // Main method – execution of the program starts here
    static void Main(string[] args)
    {
        // Creating an object of DelegateDemoApp class
        DelegateDemoApp app = new DelegateDemoApp();
        // Calling the Run() method to start delegate demo
        app.Run();
    }
}
 //Declaring a delegate
 // It can store references to methods
 // that take two int parameters and return void
delegate int MathOperation(int a ,int b);
class DelegateDemoApp
{
   
    public void Run()
    {
        MathOperation operation = Add;
        //Multicast delegates
        operation += Substract;
        operation += Multiply;
        operation += Divide;

        operation -= Substract;

        var result = operation(20,5);
        Console.WriteLine($"Final Result:{result}");
        
    }
    public int Add(int a ,int b)
    {
        Console.WriteLine($"the sum of {a} and {b} is : {a+b}");
        return a+b;
    }
    public int Substract (int a ,int b)
    {
        Console.WriteLine($"the difference between {a} and {b} is : {a-b}");
        return a -b;
    }
    public int Multiply (int a ,int b)
    {
        Console.WriteLine($"the product of  {a} and {b} is : {a*b}");
        return a*b;
    }
    public int Divide (int a ,int b)
    {
        Console.WriteLine($"the division of  {a} and {b} is : {a/b}");
        return a/b;
    }
}

