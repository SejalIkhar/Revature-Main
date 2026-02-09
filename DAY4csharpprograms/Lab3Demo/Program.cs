// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
var animals = new List<Animal>
{
    new Dog("Buddy"),
    new Cat("Misty")
};

foreach (var animal in animals)
{
    Console.WriteLine(animal);
    Console.WriteLine(animal.Speak());
}
