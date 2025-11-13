using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// CLASS: Reference
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        return _verseStart == _verseEnd 
            ? $"{_book} {_chapter}:{_verseStart}" 
            : $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
    }
}

// CLASS: Word
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden() => _isHidden;
    public void Hide() => _isHidden = true;
    public void Reveal() => _isHidden = false;
    public string GetDisplayText() => _isHidden ? new string('_', _text.Length) : _text;
    public string GetOriginal() => _text;
}

// CLASS: Scripture
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        if (visibleWords.Count == 0) return;

        count = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllHidden() => _words.All(w => w.IsHidden());

    public void RevealRandomHiddenWord()
    {
        var hiddenWords = _words.Where(w => w.IsHidden()).ToList();
        if (hiddenWords.Count == 0) return;

        int index = _random.Next(hiddenWords.Count);
        hiddenWords[index].Reveal();
    }

    public int WordsRemaining() => _words.Count(w => !w.IsHidden());
    public int TotalWordCount() => _words.Count;

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{scriptureText}";
    }
}

// CLASS: Program
public class Program
{
    private static void ClearScreen() => Console.Clear();

    public static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to the Enhanced Scripture Memorizer ===\n");

        // Load scriptures from file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in scriptures.txt. Exiting...");
            return;
        }

        // Pick random scripture
        Random rnd = new Random();
        Scripture scripture = scriptures[rnd.Next(scriptures.Count)];

        // Difficulty selection
        Console.Write("Choose difficulty (easy / normal / hard): ");
        string difficulty = Console.ReadLine()?.Trim().ToLower() ?? "normal";
        int hideCount = difficulty switch
        {
            "easy" => 2,
            "hard" => 5,
            _ => 3
        };

        Console.WriteLine("\nPress Enter to begin, type 'hint' for help, or 'quit' to exit.");
        Console.ReadLine();

        while (true)
        {
            ClearScreen();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(scripture.GetDisplayText());
            Console.ResetColor();

            // Show progress
            int hidden = scripture.TotalWordCount() - scripture.WordsRemaining();
            int total = scripture.TotalWordCount();
            double percent = (double)hidden / total * 100;
            Console.WriteLine($"\nProgress: [{new string('#', hidden / 2)}{new string('-', scripture.WordsRemaining() / 2)}] {percent:0}%");
            Console.WriteLine($"Words remaining: {scripture.WordsRemaining()}");

            Console.WriteLine("\nPress Enter to hide more words, type 'hint' to reveal one word, or 'quit' to end:");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
            {
                Console.WriteLine("\nGoodbye! Keep practicing your scripture!");
                break;
            }
            else if (input == "hint")
            {
                scripture.RevealRandomHiddenWord();
                Console.WriteLine("\nA hidden word was revealed as a hint!");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                scripture.HideRandomWords(hideCount);

                if (scripture.AllHidden())
                {
                    ClearScreen();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.ResetColor();
                    Console.WriteLine("\n🎉 Congratulations! You have successfully hidden all words!");
                    break;
                }
            }
        }
    }

    public static List<Scripture> LoadScripturesFromFile(string path)
    {
        var scriptures = new List<Scripture>();

        if (!File.Exists(path))
        {
            Console.WriteLine($"File {path} not found!");
            return scriptures;
        }

        foreach (var line in File.ReadAllLines(path))
        {
            var parts = line.Split('|');
            if (parts.Length < 5) continue;

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int verseStart = int.Parse(parts[2]);
            int verseEnd = int.Parse(parts[3]);
            string text = parts[4];

            var reference = new Reference(book, chapter, verseStart, verseEnd);
            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}
