using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreeQuestions
{
    /*Class Program
     * Author: Sebastian Arroyo
     * Purpose: Timer
     * Restrictions: None
     */
    internal static class Program
    {
        static ManualResetEvent timerEvent = new ManualResetEvent(false);
        /*Method Main
         * Purpose: Quiz Game
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            do
            {
                //User picks a question
                Console.WriteLine("Choose your question (1-3): ");
                int questionNumber = int.Parse(Console.ReadLine());

                string question = GetQuestion(questionNumber);
                string answer = GetAnswer(questionNumber);

                Console.WriteLine(question);

                // Start a timer for 5 seconds
                Timer timer = new Timer(CheckAnswer, answer, 5000, Timeout.Infinite);

                string userResponse = Console.ReadLine();

                timerEvent.Set();

                // Check the user's response
                if (userResponse.Equals(answer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                }
                timerEvent.Reset();

                // Wait for user input before exiting

                Console.WriteLine("Do you want to play again? (yes/no): ");
            } while (Console.ReadLine().Trim().ToLower().Equals("y", StringComparison.OrdinalIgnoreCase));


            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
        /*Method GetQuestion
         * Purpose: obtain the question the user asked for
         * Restricitons: None
         */
        static string GetQuestion(int questionNumber)
        {
            switch (questionNumber) 
            {
                case 1:
                    return "What is your favorite color?";
                case 2:
                    return "What is the answer to life, the universe, and everything?";
                case 3:
                    return "What is the airspeed velocity of an unladen swallow?";
                default:
                    return "Invalid question";
            }
        }
        /*Method GetAnswer
         * Purpose: obtain the answer to the current question
         * Restrictions None
         */
        static string GetAnswer(int questionNumber)
        {
            switch (questionNumber)
            {
                case 1:
                    return "black";
                case 2:
                    return "42";
                case 3:
                    return "What do you mean? African or European swallow?";
                default:
                    return "Invalid answer";
            }
        }
        /*Method CheckAnswer
         * Purpose: display answer if user runs out of time
         * Restrictions None
         */
        static void CheckAnswer(object answer)
        {
            Console.WriteLine("Time's up! The correct answer was: " + answer);
           
            timerEvent.Set();
        }
    }
}
