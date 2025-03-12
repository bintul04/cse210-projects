using System;

class Program
{
    // Function to display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to ask for and return the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();  // Gets the name as a string
        return userName;
    }

    // Function to ask for and return the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber;
        while (!int.TryParse(Console.ReadLine(), out userNumber))  // Ensures the input is a valid integer
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }
        return userNumber;
    }

    // Function to accept an integer and return that number squared
    static int SquareNumber(int number)
    {
        return number * number;  // Squares the input number
    }

    // Function to display the result (user's name and the squared number)
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your favorite number is: {squaredNumber}");
    }

    static void Main()
    {
        // Call DisplayWelcome to show the welcome message
        DisplayWelcome();

        // Call PromptUserName to get the user's name and save it in 'name'
        string name = PromptUserName();
        Console.WriteLine("Hello, " + name + "!");

        // Call PromptUserNumber to get the user's favorite number and save it in 'favoriteNumber'
        int favoriteNumber = PromptUserNumber();
        Console.WriteLine("Your favorite number is " + favoriteNumber + ".");

        // Call SquareNumber to square the user's favorite number and save the result in 'squaredNumber'
        int squaredNumber = SquareNumber(favoriteNumber);

        // Call DisplayResult to display the name and squared number
        DisplayResult(name, squaredNumber);
    }
}
