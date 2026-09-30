using System;
enum University
{
    KGU,
    KAI,
    KHTI
}

struct Worker
{
    public string Name;          
    public University Univ;      
}

class Program
{
    static void Main()
    {
        Worker w = new Worker();
        w.Name = "Евгений";
        w.Univ = University.KAI;
        Console.WriteLine($"Работник: {w.Name}, ВУЗ: {w.Univ}");
    }
}
    
