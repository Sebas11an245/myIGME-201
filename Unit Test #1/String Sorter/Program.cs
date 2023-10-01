using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Sorter
{
    /*Class Program
     *Author: Sebastian Arroyo
     *Purpose: Sorting
     *Restrictions: None
     */
    internal static class Program
    {
        /*Method: Main
         *Purpose: sort strings aphabetically and numbers numerically in ascending or descending order
         *Restrictions: None
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence:");
            string inputSentence = Console.ReadLine();

            // Split the sentence into words
            string[] words = inputSentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Console.Write("Ascending (A) or Descending (D) order? ");
            string sortOrder = Console.ReadLine();

            // Sort the words based on the specified order
            if (sortOrder.ToLower() == "a")
            {
                Array.Sort(words);
            }
            else if (sortOrder.ToLower() == "d")
            {
                Array.Sort(words, (string a, string b) => b.CompareTo(a));
            }
            else
            {
                Console.WriteLine("Invalid sorting order.");
                return;
            }

            // Display the sorted words
            Console.WriteLine("Sorted words:");
            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }

            Console.WriteLine();
        }
    }
}
