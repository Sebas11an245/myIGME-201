using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4
{
    static internal class Program
    {
        static void Main(string[] args)
        {
                int num1, num2;

                    Console.Write("First number: ");
                    if (int.TryParse(Console.ReadLine(), out num1))
                    {
                        Console.Write("Second number: ");
                        if (int.TryParse(Console.ReadLine(), out num2))
                        {
                            if (num1 > 10 && num2 > 10)
                            {
                                Console.WriteLine("Both numbers are greater than 10. Try again.");
                            }
                            else
                            {
                                Console.WriteLine($"You entered: Number 1 = {num1}, Number 2 = {num2}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for the second number. Please enter a valid number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for the first number. Please enter a valid number.");
                    }
            }
        }
    }
