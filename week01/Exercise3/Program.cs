using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());


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


        Console.WriteLine("\n--- Now with a loop! ---");


        Console.Write("What is the magic number? ");
        magicNumber = int.Parse(Console.ReadLine());

        // Start the loop
        guess = -1;

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

        Console.WriteLine("\n--- Now with a random number! ---");

        // Create a random number generator
        Random randomGenerator = new Random();
        magicNumber = randomGenerator.Next(1, 101); // 1 to 100

        // Reset the guess
        guess = -1;

        // Play the game with the random number
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