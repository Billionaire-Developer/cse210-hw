using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name?: ");
        string name = Console.ReadLine();
        Console.Write("What is your last name?: ");
        string name2 = Console.ReadLine();

        Console.WriteLine($"Your name is {name2}, {name} {name2}");

    }
}