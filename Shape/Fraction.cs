using System;

public class Fraction
{
    public int Numerator { get; set; }   // Tử số
    public int Denominator { get; set; } // Mẫu số

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be 0.");
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
            throw new DivideByZeroException("Cannot divided by 0");
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