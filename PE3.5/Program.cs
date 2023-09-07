using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3._5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int num1 =  0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;

            Console.Write("Enter the first integer: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second integer: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the third integer: ");
            num3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the fourth integer: ");
            num4 = Convert.ToInt32(Console.ReadLine());
            int product = num1 * num2 * num3 * num4;
            Console.WriteLine($"The product of {num1}, {num2}, {num3}, and {num4} is: {product}");
        }
    }
}
