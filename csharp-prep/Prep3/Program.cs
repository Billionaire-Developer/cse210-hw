using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello Prep3 World!");

        Console.Write("What is your magic number?: ");
        string magicNumber = Console.ReadLine();
        int numberValue = int.Parse(magicNumber);

        int guessValue;
        do{
            Console.Write("What is your guess number?: ");
            string guessNumber = Console.ReadLine();
            guessValue = int.Parse(guessNumber);
            if (guessValue < numberValue)
            {
                Console.WriteLine("Too low! Guess higher next time.");
            }
            else if (guessValue > numberValue)
            {
                Console.WriteLine("Too high! Guess lower next time.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number");
            }
        } while (guessValue != numberValue);
        System.Console.WriteLine("Congratulations! You guessed the magic number.");

    }
}