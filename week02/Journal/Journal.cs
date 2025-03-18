using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    // Method to add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        Console.WriteLine("\n✅ Entry saved!\n");
    }

    // Method to display all journal entries
    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n📖 No journal entries yet.\n");
            return;
        }

        Console.WriteLine("\n📜 Your Journal Entries:\n");
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    // Method to save journal entries to a CSV file
    public void SaveToCSV(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Write the header
            writer.WriteLine("Date,Prompt,Response,Mood,Tags");

            foreach (var entry in _entries)
            {
                // Escape any commas or quotation marks in the content
                string date = entry.Date;
                string prompt = entry.Prompt.Replace(",", "\\,").Replace("\"", "\"\"");
                string response = entry.Response.Replace(",", "\\,").Replace("\"", "\"\"");
                string mood = entry.Mood.Replace(",", "\\,").Replace("\"", "\"\"");
                string tags = string.Join(",", entry.Tags).Replace(",", "\\,").Replace("\"", "\"\"");

                writer.WriteLine($"\"{date}\",\"{prompt}\",\"{response}\",\"{mood}\",\"{tags}\"");
            }
        }
        Console.WriteLine($"\n💾 Journal saved to {filename} as CSV!\n");
    }

    // Method to save journal entries to a JSON file
    public void SaveToJson(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json);
        Console.WriteLine($"\n💾 Journal saved to {filename} as JSON!\n");
    }

    // Method to load journal entries from a file (CSV or JSON)
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("\n⚠️ File not found! No journal loaded.\n");
            return;
        }

        _entries.Clear();
        string fileExtension = Path.GetExtension(filename).ToLower();

        if (fileExtension == ".csv")
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 5)
                    {
                        List<string> tags = new List<string>(parts[4].Split(','));
                        Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3], tags);
                        _entries.Add(entry);
                    }
                }
            }
            Console.WriteLine($"\n📂 Journal loaded from {filename} (CSV)!\n");
        }
        else if (fileExtension == ".json")
        {
            string json = File.ReadAllText(filename);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json);
            Console.WriteLine($"\n📂 Journal loaded from {filename} (JSON)!\n");
        }
        else
        {
            Console.WriteLine("\n⚠️ Unsupported file format!\n");
        }
    }
}
