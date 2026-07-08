using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for magic number
        Console.Write("What is the magic number? ");

        int magicNumber = int.Parse(Console.ReadLine());

        // Start guessing loop

        int guess = -1;


        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }


        Console.WriteLine("Thanks for playing!");
    }
}