//Class vs object
public class Person
{
    private int _age;

    public string Name { get; set; }
    public int Age
    {
        get => _age;
        set => _age = value < 0 ? 0 : value;
    }

    public Person()
    {
        Name = "Unknown";
        Age = 0;
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}
