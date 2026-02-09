// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(4, 6);

        Console.WriteLine("Before scaling:");
        Console.WriteLine($"Circle Area: {circle.Area()}");
        Console.WriteLine($"Rectangle Area: {rectangle.Area()}");

        ((ITransformable)circle).Scale(2);
        ((ITransformable)rectangle).Scale(2);

        Console.WriteLine("\nAfter scaling:");
        Console.WriteLine($"Circle Area: {circle.Area()}");
        Console.WriteLine($"Rectangle Area: {rectangle.Area()}");
    }
}

