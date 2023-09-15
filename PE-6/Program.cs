using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_6
{
    /*
     * Author: Sebastian Arroyo
     * This class generates a random number and gives the person playing 8 tries to guess it
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            // initialize guess
            int guess = 0;

            // initialize counter
            int guesses = 0;

            // seed the random number generator
            Random rand = new Random();

            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);

            // print the random number first
            Console.WriteLine(randomNumber);


            while (guesses < 8)
            {
                Console.WriteLine($"Turn #{guesses+1}: Enter a guess: ");


                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    // catch invalid guesses
                    if (guess < 0 || guess > 100)
                    {
                        Console.WriteLine("Invalid guess - try again");
                        continue;
                    }

                    // increment counter only when valid guesses are made
                    guesses++;

                    // exit loop when the correct guess is made
                    if (guess == randomNumber)
                    {
                        Console.WriteLine($"Correct! You won in {guesses} turns.");
                        break;
                    }
                    else if (guess < randomNumber)
                    {
                        Console.WriteLine("Too low.");
                    }
                    else
                    {
                        Console.WriteLine("Too high.");
                    }
                }
                // catch invalid guesses
                else
                {
                    Console.WriteLine("Invalid guess - try again");
                }
            }
            if (guesses == 8)
            {
                Console.WriteLine($"You ran out of turns. The number was {randomNumber}.");
            }

            Console.ReadLine();
        }
        
    }
}
