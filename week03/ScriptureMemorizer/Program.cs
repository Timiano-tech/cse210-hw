using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // My Creativity: Scripture Library of multiple scriptures
        List<Scripture> library = new List<Scripture>()
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Joshua", 1, 9),
                "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."
            ),
            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            ),
            new Scripture(
                new Reference("Psalm", 23, 1),
                "The Lord is my shepherd; I shall not want."
            )
        };

        // Select a scripture at random
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            // Hide 3 random words at a time
            scripture.HideRandomWords(3);
        }
    }
}