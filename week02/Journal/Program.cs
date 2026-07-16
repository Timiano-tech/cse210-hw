using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search/Filter");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                // Generate a random prompt
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {randomPrompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                // Creativity: Mood rating/tracking
                Console.Write("How are you feeling today? (e.g., Happy, Tired, Excited, Productive): ");
                string mood = Console.ReadLine();

                // Create new Entry
                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = randomPrompt;
                newEntry._entryText = response;
                newEntry._mood = mood;

                // Add to Journal
                journal.AddEntry(newEntry);
                Console.WriteLine("Entry recorded!\n");
            }
            else if (input == "2")
            {
                journal.DisplayAll();
            }
            else if (input == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (input == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (input == "5")
            {
                // Creativity: Keyword search
                Console.Write("Enter a keyword to search for in your journal: ");
                string keyword = Console.ReadLine();
                journal.SearchByKeyword(keyword);
            }
            else if (input == "6")
            {
                running = false;
                Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a number between 1 and 6.\n");
            }
        }
    }
}