// Lớp Square kế thừa Rectangle
public class Square : Rectangle
{
    public Square() : base() { }

    public Square(double side) : base(side, side) { }

    public Square(double side, string color, bool filled) : base(side, side, color, filled) { }

    public double getSide()
    {
        return getWidth();
    }

    public void setSide(double side)
    {
        base.setWidth(side);
        base.setLength(side);
    }

    // Ghi đè để đảm bảo hình vuông luôn có chiều dài = chiều rộng
    public override void setWidth(double side)
    {
        setSide(side);
    }

    public override void setLength(double side)
    {
        setSide(side);
    }

    public override string toString()
    {
        return $"Square[{base.toString()}]";
    }
}