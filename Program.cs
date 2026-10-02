using System;
using System.Text;

enum AlcoCategory
{
    A,
    B,
    C,
    D
}

struct Drink
{
    public string Name;
    public double AlcoholPercent;

    public Drink(string name, double alcoholPercent)
    {
        Name = name;
        AlcoholPercent = alcoholPercent;
    }
}

struct Student
{
    public string Surname;
    public string Name;
    public int Id;
    public DateTime BirthDate;
    public AlcoCategory Category;
    public Drink Drink;
    public double VolumeMl;

    public Student(string surname, string name, int id, DateTime birthDate,
                   AlcoCategory category, Drink drink, double volumeMl)
    {
        Surname = surname;
        Name = name;
        Id = id;
        BirthDate = birthDate;
        Category = category;
        Drink = drink;
        VolumeMl = volumeMl;
    }

    public double AlcoholMl() => VolumeMl * Drink.AlcoholPercent / 100;
}

class Program
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }

    static void Task1()
    {
        Console.WriteLine("=== Задача 1 ===");
        Console.WriteLine($"sbyte – {sbyte.MaxValue} – {sbyte.MinValue}");
        Console.WriteLine($"byte – {byte.MaxValue} – {byte.MinValue}");
        Console.WriteLine($"short – {short.MaxValue} – {short.MinValue}");
        Console.WriteLine($"ushort – {ushort.MaxValue} – {ushort.MinValue}");
        Console.WriteLine($"int – {int.MaxValue} – {int.MinValue}");
        Console.WriteLine($"uint – {uint.MaxValue} – {uint.MinValue}");
        Console.WriteLine($"long – {long.MaxValue} – {long.MinValue}");
        Console.WriteLine($"ulong – {ulong.MaxValue} – {ulong.MinValue}");
        Console.WriteLine($"float – {float.MaxValue} – {float.MinValue}");
        Console.WriteLine($"double – {double.MaxValue} – {double.MinValue}");
        Console.WriteLine($"decimal – {decimal.MaxValue} – {decimal.MinValue}");
        Console.WriteLine($"char – {(int)char.MaxValue} – {(int)char.MinValue}");
        Console.WriteLine();
    }

    static void Task2()
    {
        Console.WriteLine("=== Задача 2 ===");

        Console.Write("Имя: ");
        string name = Console.ReadLine();

        Console.Write("Город: ");
        string city = Console.ReadLine();

        Console.Write("Возраст: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("PIN-код: ");
        string pin = Console.ReadLine();

        Console.WriteLine($"Имя: {name}\nГород: {city}\nВозраст: {age}\nPIN-код: {pin}");
        Console.WriteLine();
    }

    static void Task3()
    {
        Console.WriteLine("=== Задача 3 ===");
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsUpper(c))
                result.Append(char.ToLower(c));
            else if (char.IsLower(c))
                result.Append(char.ToUpper(c));
            else
                result.Append(c);
        }

        Console.WriteLine(result.ToString());
        Console.WriteLine();
    }

    static void Task4()
    {
        Console.WriteLine("=== Задача 4 ===");
        Console.Write("Введите строку: ");
        string text = Console.ReadLine();
        Console.Write("Введите подстроку: ");
        string sub = Console.ReadLine();

        if (string.IsNullOrEmpty(sub))
        {
            Console.WriteLine("Подстрока пустая");
            return;
        }

        int count = 0;
        int index = text.IndexOf(sub, StringComparison.Ordinal);

        while (index != -1)
        {
            count++;
            index = text.IndexOf(sub, index + sub.Length, StringComparison.Ordinal);
        }

        Console.WriteLine($"Количество вхождений: {count}");
        Console.WriteLine();
    }

    static int DutyFree(int normPrice, int salePrice, int holidayPrice)
    {
        long savingTimes100 = (long)normPrice * salePrice;
        if (savingTimes100 <= 0) return 0;

        return (int)((long)holidayPrice * 100 / savingTimes100);
    }

    static void Task5()
    {
        Console.WriteLine("=== Задача 5 ===");
        Console.WriteLine($"Бутылок: {DutyFree(10, 10, 500)}");
        Console.WriteLine();
    }

    static void Task6()
    {
        Console.WriteLine("=== Задача 6 ===");

        Drink beer = new Drink("Пиво", 5);
        Drink vodka = new Drink("Водка", 40);
        Drink wine = new Drink("Вино", 12);
        Drink juice = new Drink("Сок", 0);

        Student[] students =
        {
            new Student("Иванов", "Иван", 1, new DateTime(2003, 5, 14), AlcoCategory.A, vodka, 1500),
            new Student("Петров", "Пётр", 2, new DateTime(2004, 1, 20), AlcoCategory.B, beer, 2000),
            new Student("Сидорова", "Анна", 3, new DateTime(2003, 9, 2), AlcoCategory.C, wine, 500),
            new Student("Кузнецов", "Олег", 4, new DateTime(2002, 12, 30), AlcoCategory.D, juice, 700),
            new Student("Смирнова", "Мария", 5, new DateTime(2004, 7, 8), AlcoCategory.C, beer, 800),
        };

        double totalVolume = 0;
        double totalAlcohol = 0;
        foreach (Student s in students)
        {
            totalVolume += s.VolumeMl;
            totalAlcohol += s.AlcoholMl();
        }

        Console.WriteLine($"Общий объём выпитого: {totalVolume} мл");
        Console.WriteLine($"Общий объём чистого спирта: {totalAlcohol:F1} мл");
        Console.WriteLine($"Средняя крепость: {totalAlcohol / totalVolume * 100:F2}%");
        Console.WriteLine();

        foreach (Student s in students)
        {
            double volumePercent = s.VolumeMl / totalVolume * 100;
            double alcoholPercent = totalAlcohol > 0 ? s.AlcoholMl() / totalAlcohol * 100 : 0;

            Console.WriteLine(
                $"{s.Surname} {s.Name} (ID {s.Id}, {s.BirthDate:dd.MM.yyyy}, кат. {s.Category}): " +
                $"{s.Drink.Name} {s.VolumeMl} мл | " +
                $"от общей жидкости: {volumePercent:F2}% | от общего алкоголя: {alcoholPercent:F2}%");
        }
    }
}
