using System;

namespace numGuess
{
    class MainClass
    {
        public static void UserGuess(int x)
        {
            int i = 1;
            int answer = new Random().Next(1, x);

            Console.WriteLine($"I'm thinking of a number between 1 and {x}.");
            Console.WriteLine("Enter your guess, or exit to give up");

            bool contd = true;
            do
            {
                Console.WriteLine("My guess is ");
                string guess = Console.ReadLine();
                bool result = Int32.TryParse(guess, out int gn);

                if (!result && guess == "exit" || i == 5)
                {
                    Console.WriteLine($"Game Ended!\nThe answer was {answer}.");
                    contd = false;
                }
                else if (result)
                {
                    string g = i > 1 ? "guesses" : "guess";
                    if (gn == answer)
                    {
                        Console.WriteLine($"Correct! You guessed right in {i} {g}");
                        contd = false;
                    }
                    else
                    {
                        i++;
                        Console.WriteLine("Not quite, try again. {0} guesses left\nHINT: {1}", 6 - i, gn > answer ? "Go lower" : "Go higher");
                    }
                }
                else Console.WriteLine("Hmm that's not a number. Try again");
            } while (contd);
        }

        public static void ComputerGuess(int x)
        {
            int i = 0, low = 1, high = x;
            bool contd = true;
            int num;

            Console.WriteLine("I'll attempt to find your number between 1 and {0}", x);

            do
            {
                if (low != high)
                    num = new Random().Next(low, high);
                else
                    num = low;
                Console.WriteLine($"Is {num} higher (H), lower (L), or correct (C)?");

                string feedback = Console.ReadLine().ToLower();

                if (feedback == "h" || feedback == "l")
                {
                    i++;
                    if (feedback == "h") high = num - 1;
                    else if (feedback == "l") low = num + 1;
                    if (i == 5)
                    {
                        Console.WriteLine("Seem like you win this round");
                        contd = false;
                    }
                }
                else if (feedback == "c")
                {
                    Console.WriteLine($"Your number {num} was too easy! Haha. I am AI.");
                    contd = false;
                }
                else Console.WriteLine("Unrecognised input");
            } while (contd);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Guess the Number!");
            Console.WriteLine("Enter maximum value?");
            int val = int.Parse(Console.ReadLine());

            Console.WriteLine("Please choose which mode to play: 'U' for user, 'C' for computer");
            string mode = Console.ReadLine().ToUpper();

            // guess computers number
            if (mode == "U")
            {
                UserGuess(val);
            }
            // computer guesses your number
            else if (mode == "C")
            {
                ComputerGuess(val);
            }         
        }        
    }
}
