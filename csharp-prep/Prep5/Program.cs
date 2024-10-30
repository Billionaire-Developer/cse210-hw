using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");

         // Call DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName function and save the return value
        string userName = PromptUserName();

        // Call PromptUserNumber function and save the return value
        int userNumber = PromptUserNumber();

        // Call SquareNumber function and save the return value
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult function and pass the user's name and squared number
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        return Console.ReadLine();

    }
    static int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"Hello, {userName}! Your favorite number squared is: {squaredNumber}");
    }

}