using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryRaise
{
    //Class Program
    //Author: Sebastian Arroyo
    //Purpose: Functions
    //Restrictions: None
    internal static class Program
    {
        //Method Main
        //Purpose: Get a Raise
        //Restrictions: None
        static void Main(string[] args)
        {
            // Variable declarations
            string sName;
            double dSalary = 30000;

            // Prompt for the user's name
            Console.Write("Enter your name: ");
            sName = Console.ReadLine();

            // Call the GiveRaise function
            bool gotRaise = GiveRaise(sName, ref dSalary);

            // Check if the user got a raise
            if (gotRaise)
            {
                Console.WriteLine("Congratulations, you got a raise!");
                Console.WriteLine($"Your new salary is: ${dSalary:F2}");
            }
            else
            {
                Console.WriteLine("Sorry, no raise for you.");
                Console.WriteLine($"Your salary remains: ${dSalary:F2}");
            }
        }

        // Method GiveRaise
        // Purpose: Give a raise if name is Sebastian
        //Restricions: None
        static bool GiveRaise(string name, ref double salary)
        {
            string yourName = "Sebastian";

            if (name.Equals(yourName))
            {
                // Increase the salary by $19,999.99
                salary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
