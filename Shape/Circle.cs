// Lớp Circle kế thừa Shape
public class Circle : Shape
{
    protected double radius;

    public Circle() : base()
    {
        radius = 1.0;
    }

    public Circle(double radius) : base()
    {
        this.radius = radius;
    }

    public Circle(double radius, string color, bool filled) : base(color, filled)
    {
        this.radius = radius;
    }

    public double GetRadius() { return radius; }
    public void SetRadius(double radius) { this.radius = radius; }

    public override double getArea()
    {
        return Math.PI * radius * radius;
    }

    public override double getPerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override string toString()
    {
        return $"Circle[{base.ToString()}, radius={radius}]";
    }
}