public class Circle : Shape
{
    private double _radius;

    // The Constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // To Override GetArea method
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
