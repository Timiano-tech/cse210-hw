using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the numbers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a series of numbers (enter 0 to stop):");

        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter a number: ");
            userNumber = int.Parse(Console.ReadLine());


            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        if (numbers.Count > 0)
        {
            // Calculate the sum
            int sum = 0;
            foreach (int number in numbers)
            {
                sum = sum + number;
            }


            float average = (float)sum / numbers.Count;

            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            // Display the results
            Console.WriteLine();
            Console.WriteLine("The numbers you entered were:");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The sum is: " + sum);
            Console.WriteLine("The average is: " + average);
            Console.WriteLine("The largest number is: " + max);
        }
        else
        {
            Console.WriteLine("You didn't enter any numbers!");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}