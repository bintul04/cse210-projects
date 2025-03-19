/*
1. Improved user experience with clear instructions and error handling.
2. Ensures only unhidden words are selected for hiding.
3. Automatically stops when all words are hidden.
4. Displays scripture in a clean, readable format.
5. Prevents crashes by handling unexpected user input.

These enhancements make the program more user-friendly and robust.
*/


using System;

class Program
{
    static void Main()
    {
        // Create a reference for the scripture (e.g., Proverbs 3:5)
        Reference reference = new Reference("Proverbs", 3, 5);

        // Define the scripture text (e.g., "Trust in the Lord with thine; and lean not unto thine own understanding.")
        string scriptureText = "Trust in the Lord with thine heart; and lean not unto thine own understanding";

        Scripture scripture = new Scripture(reference, scriptureText);

        // Display the scripture before hiding any words
        Console.WriteLine("Scripture Before Hiding Words:\n");
        Console.WriteLine(scripture.GetDisplayText());

        // Loop to hide random words or quit
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nPress Enter to hide one random word, or type 'quit' to exit.");

            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit")
            {
                Console.WriteLine("Exiting the program...");
                break;
            }

            if (userInput == "")
            {
                scripture.HideRandomWords();
                Console.WriteLine("\nScripture After Hiding One Word:\n");
                Console.WriteLine(scripture.GetDisplayText());
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to hide a word or type 'quit' to exit.");
            }
        }

        // Final message when all words are hidden or the user quits
        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nAll words are hidden! You've completed the task.");
        }
        else
        {
            Console.WriteLine("\nYou chose to quit. Thank you for using the program.");
        }
    }
}
