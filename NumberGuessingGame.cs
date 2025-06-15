using System;

namespace MyNumberGuessingGameApp
{
    public class GuessingGame
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            bool playAgain = true;
            int min = 1;
            int max = 100;
            int guess;
            int number;
            int guesses;
            string response;

            while (playAgain)
            {
                guess = 0;
                guesses = 0;
                response = "";
                number = random.Next(min, max + 1);

                Console.WriteLine($"Guess a number between {min} and {max}:");

                while (guess != number)
                {
                    guess = GetValidGuess(min, max);
                    Console.WriteLine($"Your guess: {guess}");

                    if (guess > number)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else if (guess < number)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    guesses++;
                }

                Console.WriteLine($"\n🎉 YOU WIN! The number was: {number}");
                Console.WriteLine($"Total guesses: {guesses}");

                Console.Write("\nWould you like to play again? (Y/N): ");
                response = Console.ReadLine()?.Trim().ToUpper();

                playAgain = response == "Y";
            }

            Console.WriteLine("Thanks for playing! 🎮");
        }

        static int GetValidGuess(int min, int max)
        {
            int guess;
            while (true)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out guess) && guess >= min && guess <= max)
                {
                    return guess;
                }

                Console.WriteLine($"⚠️ Invalid input! Please enter a number between {min} and {max}.");
            }
        }
    }
}
