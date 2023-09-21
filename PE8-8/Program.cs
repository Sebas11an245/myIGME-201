using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_8
{
    /* Author: Sebastian Arroyo
     * Purpose: Accepts a string and changes instances of no to yes
     * Issues: Doesn't work if there is any other characters next to the word, i.e No. will not become Yes.
     */
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            string[] iArray = input.Split();

            //counter for array loop
            int cntr = 0;

            foreach (string word in iArray) 
            {
                if (word == "No")
                {
                    iArray[cntr] = "Yes";
                }
                else if (word.ToLower() == "no") 
                {
                    iArray[cntr] = "yes";
                }
                cntr++;
            }

            foreach (string word in iArray)
            {
                Console.Write("{0} ", word);
            }
        }
    }
}
