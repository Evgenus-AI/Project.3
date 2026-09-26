using System;

namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Console.Write("Введите 1 коэффицент: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Введите 2 коэффицент: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Введите 3 коэффицент: ");
        double c = double.Parse(Console.ReadLine());
        double d = Math.Pow(b, 2) - 4 * a * c;
        if (d < 0)
        {
            Console.WriteLine("уравнение не имеет решения");
        }

        if (d == 0)
        {
            double x = (-1 * b) / 2;
            Console.WriteLine($"Уравнение имеет 1 корень: {x}");
        }

        if (d > 0)
        {
            double d1 = Math.Sqrt(d);
            double x1 = (-1 * b + d1) / 2;
            double x2 = (-1 * b - d1) / 2;
            Console.WriteLine($"1 корень: {x1}");
            Console.WriteLine($"2 корень: {x2}");

        }
        }
    }
}

    
