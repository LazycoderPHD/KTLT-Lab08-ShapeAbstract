// Lớp Rectangle kế thừa Shape
public class Rectangle : Shape
{
    protected double width;
    protected double length;

    public Rectangle() : base()
    {
        width = 1.0;
        length = 1.0;
    }

    public Rectangle(double width, double length) : base()
    {
        this.width = width;
        this.length = length;
    }

    public Rectangle(double width, double length, string color, bool filled) : base(color, filled)
    {
        this.width = width;
        this.length = length;
    }

    public double getWidth() { return width; }
    public virtual void setWidth(double width) { this.width = width; }

    public double getLength() { return length; }
    public virtual void setLength(double length) { this.length = length; }

    public override double getArea()
    {
        return width * length;
    }

    public override double getPerimeter()
    {
        return 2 * (width + length);
    }

    public override string toString()
    {
        return $"Rectangle[{base.toString()}, width={width}, length={length}]";
    }
}