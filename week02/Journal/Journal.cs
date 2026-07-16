using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    // Format: Date~|~Prompt~|~Response~|~Mood
                    writer.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._mood}");
                }
            }
            Console.WriteLine($"Journal successfully saved to '{file}'.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"Error: File '{file}' does not exist.\n");
            return;
        }

        try
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(new[] { "~|~" }, StringSplitOptions.None);
                if (parts.Length >= 4)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._promptText = parts[1];
                    entry._entryText = parts[2];
                    entry._mood = parts[3];

                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal successfully loaded from '{file}'. Loaded {_entries.Count} entries.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}\n");
        }
    }

    public void SearchByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Please enter a valid keyword to search.\n");
            return;
        }

        List<Entry> matchingEntries = new List<Entry>();
        foreach (Entry entry in _entries)
        {
            if (entry._promptText.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._entryText.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._mood.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                matchingEntries.Add(entry);
            }
        }

        if (matchingEntries.Count == 0)
        {
            Console.WriteLine($"No entries found matching: '{keyword}'\n");
        }
        else
        {
            Console.WriteLine($"\n--- Found {matchingEntries.Count} entries matching '{keyword}' ---");
            foreach (Entry entry in matchingEntries)
            {
                entry.Display();
            }
        }
    }
}
