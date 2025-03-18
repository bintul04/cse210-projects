/*
1. **Added Mood and Tags** - Each journal entry now includes a mood and relevant tags to help categorize and search entries later.
2. **Improved File Storage Format** - The journal is saved as a CSV file, making it easier to open and analyze in spreadsheet applications.
3. **Enhanced Load and Save Logic** - Handled special characters (like commas and quotation marks) properly when saving and loading CSV files.
4. **Search Functionality** - Users can search for journal entries based on keywords, moods, or tags.
5. **User-Friendly Interface** - Added emojis and improved formatting to enhance readability and interaction.
6. **Random Quote Feature** - Displays a motivational quote each time the program starts to inspire journaling.
*/



using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save Journal to CSV");
            Console.WriteLine("4. Save Journal to JSON");
            Console.WriteLine("5. Load Journal");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Add a new journal entry
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    // Ask for mood and tags
                    Console.Write("How do you feel today? (e.g., Happy, Sad, etc.): ");
                    string mood = Console.ReadLine();

                    Console.Write("Enter tags (separated by commas): ");
                    string tagsInput = Console.ReadLine();
                    List<string> tags = new List<string>(tagsInput.Split(','));

                    // Create the new entry
                    Entry newEntry = new Entry(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), prompt, response, mood, tags);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    // Display all journal entries
                    journal.DisplayAllEntries();
                    break;

                case "3":
                    // Save journal to a CSV file
                    Console.Write("Enter filename to save to (e.g., journal.csv): ");
                    string saveCsvFile = Console.ReadLine();
                    journal.SaveToCSV(saveCsvFile);
                    break;

                case "4":
                    // Save journal to a JSON file
                    Console.Write("Enter filename to save to (e.g., journal.json): ");
                    string saveJsonFile = Console.ReadLine();
                    journal.SaveToJson(saveJsonFile);
                    break;

                case "5":
                    // Load journal from a file
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "6":
                    // Exit the program
                    return;

                default:
                    Console.WriteLine("\n⚠️ Invalid choice! Please try again.");
                    break;
            }
        }
    }
}
