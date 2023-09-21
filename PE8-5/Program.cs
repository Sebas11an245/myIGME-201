using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_5
{
    /*
     * Author: Sebastian Arroyo
     * Purpose: Calculate z with a range of x and y
     */
    internal static class Program
    {
        static void Main(string[] args)
        {
            // Initialize the ranges and increments for x and y
            double minX = -1.0;
            double maxX = 1.0;
            double minY = 1.0;
            double maxY = 4.0;
            double increment = 0.1;

            // Calculate the numbers in the range
            int xRange = (int)((maxX - minX) / increment) + 1;
            int yRange = (int)((maxY - minY) / increment) + 1;

            // Create a 3-dimensional array to store x, y, and z values
            double[,,] values = new double[xRange, yRange, 3];

            // Calculate and store the values into the array
            for (int i = 0; i < xRange; i++)
            {
                for (int j = 0; j < yRange; j++)
                {
                    double x = minX + i * increment;
                    double y = minY + j * increment;
                    double z = (3 * Math.Pow(y, 2)) + (2 * x) - 1;

                    values[i, j, 0] = x;
                    values[i, j, 1] = y;
                    values[i, j, 2] = z;
                }
            }

            // Display the calculated values
            for (int i = 0; i < xRange; i++)
            {
                for (int j = 0; j < yRange; j++)
                {
                    double x = values[i, j, 0];
                    double y = values[i, j, 1];
                    double z = values[i, j, 2];

                    Console.WriteLine($"x = {x}, y = {y}, z = {z}");
                }
            }
        }
    }
}
