//Lớp trừu tượng cho Shape
public abstract class Shape
{
    protected string color;
    protected bool filled;

    public Shape()
    {
        color = "green";
        filled = true;
    }

    public Shape(string color, bool filled)
    {
        this.color = color;
        this.filled = filled;
    }

    public string getColor() { return color; }
    public void setColor(string color) { this.color = color; }

    public bool isFilled() { return filled; }
    public void setFilled(bool filled) { this.filled = filled; }

    public abstract double getArea();
    public abstract double getPerimeter();

    public virtual string toString()
    {
        return $"Shape[color={color}, filled={filled}]";
    }
}