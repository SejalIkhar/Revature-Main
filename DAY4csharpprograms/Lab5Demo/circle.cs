public class Circle : Shape, ITransformable
{
    public double Radius { get; private set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public void Scale(double factor)
    {
        Radius *= factor;
    }
}
