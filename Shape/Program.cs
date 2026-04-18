class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== KIỂM TRA BÀI TẬP 1: SHAPE ===");

        // Kiểm tra lớp Circle
        Circle c1 = new Circle(5.0, "red", true);
        Console.WriteLine(c1.toString());
        Console.WriteLine($"Diện tích: {c1.getArea():F2}");
        Console.WriteLine($"Chu vi: {c1.getPerimeter():F2}\n");

        // Kiểm tra lớp Rectangle
        Rectangle r1 = new Rectangle(4.0, 5.0, "blue", false);
        Console.WriteLine(r1.toString());
        Console.WriteLine($"Diện tích: {r1.getArea():F2}");
        Console.WriteLine($"Chu vi: {r1.getPerimeter():F2}\n");

        // Kiểm tra lớp Square
        Square s1 = new Square(3.0, "yellow", true);
        Console.WriteLine(s1.toString());
        Console.WriteLine($"Diện tích ban đầu: {s1.getArea():F2}");

        // Thử thay đổi chiều rộng của hình vuông xem chiều dài có tự động đổi theo không
        s1.setWidth(6.0);
        Console.WriteLine("Sau khi gọi SetWidth(6.0): " + s1.toString());
        Console.WriteLine($"Diện tích mới: {s1.getArea():F2}\n");


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