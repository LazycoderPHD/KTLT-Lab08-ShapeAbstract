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

    public double GetWidth() { return width; }
    public virtual void SetWidth(double width) { this.width = width; }

    public double GetLength() { return length; }
    public virtual void SetLength(double length) { this.length = length; }

    public override double GetArea()
    {
        return width * length;
    }

    public override double GetPerimeter()
    {
        return 2 * (width + length);
    }

    public override string ToString()
    {
        return $"Rectangle[{base.ToString()}, width={width}, length={length}]";
    }
}

// Lớp Square kế thừa Rectangle
public class Square : Rectangle
{
    public Square() : base() { }

    public Square(double side) : base(side, side) { }

    public Square(double side, string color, bool filled) : base(side, side, color, filled) { }

    public double GetSide()
    {
        return GetWidth();
    }

    public void SetSide(double side)
    {
        base.SetWidth(side);
        base.SetLength(side);
    }

    // Ghi đè để đảm bảo hình vuông luôn có chiều dài = chiều rộng
    public override void SetWidth(double side)
    {
        SetSide(side);
    }

    public override void SetLength(double side)
    {
        SetSide(side);
    }

    public override string ToString()
    {
        return $"Square[{base.ToString()}]";
    }
}
using System;

public class Fraction
{
    public int Numerator { get; set; }   // Tử số
    public int Denominator { get; set; } // Mẫu số

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Mẫu số không được bằng 0.");
        }
        Numerator = numerator;
        Denominator = denominator;
        Simplify(); // Tự động rút gọn khi khởi tạo
    }

    // Hàm tìm Ước chung lớn nhất (UCLN) để rút gọn phân số
    private static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Rút gọn phân số
    private void Simplify()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;

        // Đẩy dấu âm lên tử số nếu mẫu số âm
        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    // Phương thức tĩnh Cộng (Add)
    public static Fraction Add(Fraction f1, Fraction f2)
    {
        int num = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
        int den = f1.Denominator * f2.Denominator;
        return new Fraction(num, den);
    }

    // Phương thức tĩnh Trừ (Subtract)
    public static Fraction Subtract(Fraction f1, Fraction f2)
    {
        int num = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
        int den = f1.Denominator * f2.Denominator;
        return new Fraction(num, den);
    }

    // Phương thức tĩnh Nhân (Multiply)
    public static Fraction Multiply(Fraction f1, Fraction f2)
    {
        int num = f1.Numerator * f2.Numerator;
        int den = f1.Denominator * f2.Denominator;
        return new Fraction(num, den);
    }

    // Phương thức tĩnh Chia (Divide)
    public static Fraction Divide(Fraction f1, Fraction f2)
    {
        if (f2.Numerator == 0)
        {
            throw new DivideByZeroException("Không thể chia cho phân số có tử số bằng 0.");
        }
        int num = f1.Numerator * f2.Denominator;
        int den = f1.Denominator * f2.Numerator;
        return new Fraction(num, den);
    }

    public override string ToString()
    {
        if (Denominator == 1) return Numerator.ToString();
        if (Numerator == 0) return "0";
        return $"{Numerator}/{Denominator}";
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== KIỂM TRA BÀI TẬP 1: SHAPE ===");

        // Kiểm tra lớp Circle
        Circle c1 = new Circle(5.0, "red", true);
        Console.WriteLine(c1.ToString());
        Console.WriteLine($"Diện tích: {c1.GetArea():F2}");
        Console.WriteLine($"Chu vi: {c1.GetPerimeter():F2}\n");

        // Kiểm tra lớp Rectangle
        Rectangle r1 = new Rectangle(4.0, 5.0, "blue", false);
        Console.WriteLine(r1.ToString());
        Console.WriteLine($"Diện tích: {r1.GetArea():F2}");
        Console.WriteLine($"Chu vi: {r1.GetPerimeter():F2}\n");

        // Kiểm tra lớp Square
        Square s1 = new Square(3.0, "yellow", true);
        Console.WriteLine(s1.ToString());
        Console.WriteLine($"Diện tích ban đầu: {s1.GetArea():F2}");

        // Thử thay đổi chiều rộng của hình vuông xem chiều dài có tự động đổi theo không
        s1.SetWidth(6.0);
        Console.WriteLine("Sau khi gọi SetWidth(6.0): " + s1.ToString());
        Console.WriteLine($"Diện tích mới: {s1.GetArea():F2}\n");


        Console.WriteLine("=== KIỂM TRA BÀI TẬP 2: FRACTION ===");

        // Khởi tạo 2 phân số
        Fraction f1 = new Fraction(1, 2); // 1/2
        Fraction f2 = new Fraction(3, 4); // 3/4

        Console.WriteLine($"Phân số 1: {f1}");
        Console.WriteLine($"Phân số 2: {f2}");

        // Gọi các phương thức tĩnh (static method) từ tên lớp Fraction
        Fraction sum = Fraction.Add(f1, f2);
        Fraction difference = Fraction.Subtract(f1, f2);
        Fraction product = Fraction.Multiply(f1, f2);
        Fraction quotient = Fraction.Divide(f1, f2);

        Console.WriteLine($"Cộng: {sum}");
        Console.WriteLine($"Trừ: {difference}");
        Console.WriteLine($"Nhân: {product}");
        Console.WriteLine($"Chia: {quotient}");
    }
}