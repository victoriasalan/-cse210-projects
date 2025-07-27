using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_promptText}\nResponse: {_entryText}\n");
    }

    public string ToFileFormat()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length != 3)
        {
            return null;
        }

        Entry entry = new Entry(parts[1], parts[2]);
        entry._date = parts[0];
        return entry;
    }
}