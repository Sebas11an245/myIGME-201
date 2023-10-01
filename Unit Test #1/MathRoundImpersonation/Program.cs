using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathRoundImpersonation
{
    delegate double RoundDelegate(double value, int decimals);
    //Class Program
    //Author: Sebastian Arroyo
    //Purpose: Delegate
    //Restrictions: None
    internal static class Program
    {
        //Method Main
        //Purpose: Impersonate Math.Round in different ways
        //Restrictions: None
        static void Main(string[] args)
        {
            // Using a delegate to impersonate Math.Round(double, int)
            RoundDelegate roundFunction = Math.Round;

            Console.WriteLine("Enter a number with decimals");
            double number = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter how many places to round");
            int decimals = int.Parse(Console.ReadLine());

            double roundedValue = roundFunction(number, decimals);

            Console.WriteLine($"Impersonating Math.Round({number}, {decimals}): {roundedValue}");

            // Additional implementations using abbreviated notation, anonymous methods, and lambda expression

            // Abbreviated Notation (Method Group Conversion)
            RoundDelegate roundAbbreviated = Math.Round;
            double roundedValueAbbreviated = roundAbbreviated(number, decimals);
            Console.WriteLine($"Abbreviated Notation: {roundedValueAbbreviated}");

            // Anonymous Method
            RoundDelegate roundAnonymous = delegate (double value, int dec) { return Math.Round(value, dec); };
            double roundedValueAnonymous = roundAnonymous(number, decimals);
            Console.WriteLine($"Anonymous Method: {roundedValueAnonymous}");

            // Lambda Expression
            RoundDelegate roundLambda = (value, dec) => Math.Round(value, dec);
            double roundedValueLambda = roundLambda(number, decimals);
            Console.WriteLine($"Lambda Expression: {roundedValueLambda}");
        }
    }
}
