using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //int nY
            //compile-time error
            //missing a semicolon at the end
            int nY;
            int nAnswer;

            //Console.WriteLine(This program calculates x ^ y.);
            //Compile-time error
            //missing double quotes
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //Console.ReadLine();
                //Logical error
                //assign the result to the variable
                sNumber = Console.ReadLine();

            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nY));
            //while (int.TryParse(sNumber, out nX));
             //Logical error
             //replace nX with nY, missing !

            // compute the exponent of the number using a recursive function
            nAnswer = Power(nX, nY);

            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            //Logical Error
            // missing $
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");

        }

        //int Power(int nBase, int nExponent)
        //Compile-time error
        //missing static
        static int Power(int nBase, int nExponent)
        {
            //int returnVal = 0;
            //Logical Error
            //initialize returnVal to 1
            int returnVal = 1;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //returnVal = 0;
                //Logical Error
                // x^0 = 1
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                nextVal = Power(nBase, nExponent - 1);
                //nextVal = Power(nBase, nExponent + 1);
                //run-time error
                //nExponent -1 for recursion


                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //returnVal;
            //compile-tome error
            //add return statement
            return returnVal;
        }
    }
}
