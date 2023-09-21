using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_7
{
    /*
     * Author: Sebastian Arroyo
     * Purpose: Accepts a string from the user and outputs a string with the characters in reverse order
     */
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            //turns input into a character array to reverse it and then turns it back into a string
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);

            Console.WriteLine("Reversed string: " + reversed);
        }
    }
}
