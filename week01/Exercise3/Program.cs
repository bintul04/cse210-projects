using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true; // This flag will control the replay loop

        while (playAgain)
        {
            // Step 1: Generate a random number between 1 and 100 (magic number)
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);

            int userGuess = 0; 
            int guessCount = 0;
            while (userGuess != magicNumber)
            {
                // Ask the user for their guess
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                guessCount++;

                // Step 3: Determine if the guess is higher, lower, or correct
                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                }
            }

            // Step 4: Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            if (response != "yes")
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}
