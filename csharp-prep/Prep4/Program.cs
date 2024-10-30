using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter a number (0 to stop): ");
            string valueNumber = Console.ReadLine();
            int number = int.Parse(valueNumber);

            if (number == 0)
                break;

            numbers.Add(number);
        }
        //compute sum
        int sum = numbers.Sum();

        //compute average
        double average = numbers.Average();

        // Find the smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).Min();

        // Display the new, sorted list
        Console.WriteLine("Sorted Numbers: " + string.Join(", ", numbers));

        //Display sum
        Console.WriteLine("Sum: " + sum);

        //Display Average
        Console.WriteLine("Average: " + average);

        // Display the smallest positive number
        Console.WriteLine("Smallest Positive: " + smallestPositive);

        // Sort the numbers in the list
        numbers.Sort();
    }
}