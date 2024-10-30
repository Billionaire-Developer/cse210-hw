using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
       Console.Write("Enter Your Percentage: ");
       string valueFromUser = Console.ReadLine();
       int number = int.Parse(valueFromUser);

       if(number >= 90)
       {
         Console.WriteLine("A");
       }
       else if (number >= 80)
       {
        Console.WriteLine("B");
       }
       else if (number >= 70)
       {
        Console.WriteLine("C");
       }
       else if (number >= 60)
       {
        Console.WriteLine("D");
       }
       else
       {
        Console.WriteLine("F");
       }

    }
}