using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for input
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();

        // Try parsing the input to ensure it's a valid number
        if (int.TryParse(answer, out int percent))
        {
            string letter = "";
            string sign = "";

            // Determine the letter grade based on percentage
            if (percent >= 90)
            {
                letter = "A";
                sign = ""; // No sign for A
            }
            else if (percent >= 80)
            {
                letter = "B";
            }
            else if (percent >= 70)
            {
                letter = "C";
            }
            else if (percent >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
                sign = ""; // No sign for F
            }

            // Determine the sign (+ or -) for grades that aren't A or F
            if (letter != "A" && letter != "F")
            {
                int lastDigit = percent % 10; // Get the last digit of the grade

                if (lastDigit >= 7)
                {
                    sign = "+"; // Add plus sign
                }
                else if (lastDigit < 3)
                {
                    sign = "-"; // Add minus sign
                }
            }

            // Special handling for A grades (no A+ grade, only A and A-)
            if (letter == "A" && percent < 90)
            {
                sign = "-"; // Grades between 87 and 89 should be A-
            }

            // Display the result with letter grade and sign in one statement
            Console.WriteLine($"Your grade is: {letter}{sign}");

            // Check if the student passed
            if (percent >= 70)
            {
                Console.WriteLine("Congratulations! You passed.");
            }
            else
            {
                Console.WriteLine("Don't give up! Keep working hard. Better luck next time!");
            }
        }
        else
        {
            // Handle invalid input
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
