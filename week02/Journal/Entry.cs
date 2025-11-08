using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public int Mood { get; set; } // new field: 1 = bad, 5 = great

    public Entry() { }

    public Entry(string date, string prompt, string response, int mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public string Display()
    {
        string moodDescription = Mood switch
        {
            1 => "😞 Very Bad",
            2 => "😕 Bad",
            3 => "😐 Okay",
            4 => "🙂 Good",
            5 => "😄 Great",
            _ => "Unknown"
        };

        return $"Date: {Date}\nPrompt: {Prompt}\nMood: {moodDescription}\nResponse: {Response}\n";
    }
}
