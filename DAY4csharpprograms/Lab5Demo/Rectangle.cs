public class Rectangle : Shape, ITransformable
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Rectangle(double w, double h)
    {
        Width = w;
        Height = h;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public void Scale(double factor)
    {
        Width *= factor;
        Height *= factor;
    }
}
