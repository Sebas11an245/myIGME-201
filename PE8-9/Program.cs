using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_9
{
    /* Author: Sebastian Arroyo
     * Purpose: Accepts a string and adds double quotes around each word.
     */
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            // Split the input string into words
            string[] words = input.Split();

            // Add double quotes around each word
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = '"' + words[i] + '"';
                Console.Write(words[i]);
            }
            Console.WriteLine();
        }
    }
}
