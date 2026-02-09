public abstract class Animal
{
    public string Name { get; }

    protected Animal(string name)
    {
        Name = name;
    }

    public virtual string Speak()
    {
        return "Animal sound";
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}";
    }
}
