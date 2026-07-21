using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitText = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string textWord in splitText)
        {
            _words.Add(new Word(textWord));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // EXtra Creativity: randomly select from only those words that are not already hidden
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0)
        {
            return;
        }

        int actualToHide = Math.Min(numberToHide, visibleWords.Count);
        Random random = new Random();

        for (int i = 0; i < actualToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        List<string> wordDisplays = new List<string>();
        foreach (Word word in _words)
        {
            wordDisplays.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", wordDisplays)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
