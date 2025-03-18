using System;
using System.Collections.Generic;

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }
    public List<string> Tags { get; set; }

    public Entry(string date, string prompt, string response, string mood, List<string> tags)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Tags = tags;
    }

    // Display method with additional info
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Tags: {string.Join(", ", Tags)}");
        Console.WriteLine();
    }

    // Format the entry for saving in a file or CSV
    public string FormatForFile()
    {
        return $"{Date}|{Prompt}|{Response}|{Mood}|{string.Join(",", Tags)}";
    }
}
