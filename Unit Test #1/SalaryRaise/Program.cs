using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryRaise
{
    //Struct Employee
    //Purpose: employee template
    //Restrictions None
    struct Employee
    {
        public string sName;
        public double dSalary;
    }

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
            Employee employee = new Employee
            {
                sName = "",
                dSalary = 30000
            };           

            // Prompt for the user's name
            Console.Write("Enter your name: ");
            employee.sName = Console.ReadLine();

            // Call the GiveRaise function
            bool gotRaise = GiveRaise(ref employee);

            // Check if the user got a raise
            if (gotRaise)
            {
                Console.WriteLine("Congratulations, you got a raise!");
                Console.WriteLine($"Your new salary is: ${employee.dSalary:F2}");
            }
            else
            {
                Console.WriteLine("Sorry, no raise for you.");
                Console.WriteLine($"Your salary remains: ${employee.dSalary:F2}");
            }
        }

        // Method GiveRaise
        // Purpose: Give a raise if name is Sebastian
        //Restricions: None
        static bool GiveRaise(ref Employee employee)
        {
            string yourName = "Sebastian";

            if (employee.sName.Equals(yourName))
            {
                // Increase the salary by $19,999.99
                employee.dSalary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
