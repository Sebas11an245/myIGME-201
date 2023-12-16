using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    //Author: Sebastian Arroyo
    //Purpose: Digraph to AdjanceyMatrix/List
    //Restrictions: None
    class Graph
    {
        private int[,] adjacencyMatrix;
        private List<List<int>> adjacencyList;

        // Purpose: Constructor
        // Restrictions: None
        public Graph(int vertices)
        {
            adjacencyMatrix = new int[vertices, vertices];
            adjacencyList = new List<List<int>>(vertices);

            for (int i = 0; i < vertices; i++)
            {
                adjacencyList.Add(new List<int>());
            }
        }

        // Purpose: Create edge between vertices
        // Restrictions: None
        public void AddEdge(int from, int to)
        {
            adjacencyMatrix[from, to] = 1;
            adjacencyList[from].Add(to);
        }

        // Purpose: Display Adjacency Matrix
        // Restrictions: None
        public void DisplayAdjacencyMatrix()
        {
            Console.WriteLine("Adjacency Matrix:");
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Purpose: Display Adjacency List
        // Restrictions: None
        public void DisplayAdjacencyList()
        {
            Console.WriteLine("Adjacency List:");
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                Console.Write($"{i}: ");
                foreach (var neighbor in adjacencyList[i])
                {
                    Console.Write($"{neighbor} ");
                }
                Console.WriteLine();
            }
        }
    }
    //Author: Sebastian Arroyo
    //Purpose: Program
    //Restrictions: None
    internal class Program
    {
        //Purpose: Recreate digraph
        //Restrictions: None
        static void Main(string[] args)
        {
            // Create a graph with 8 vertices
            Graph graph = new Graph(8);

            // Give vertices colors
            int red = 0;
            int blue = 1;
            int gray = 2;
            int skyblue = 3;
            int orange = 4;
            int yellow = 5;
            int purple = 6;
            int green = 7;

            // Add edges to the graph
            graph.AddEdge(red, blue);
            graph.AddEdge(red, gray);
            graph.AddEdge(blue, skyblue);
            graph.AddEdge(blue, yellow);
            graph.AddEdge(yellow, green);
            graph.AddEdge(skyblue, blue);
            graph.AddEdge(skyblue, gray);
            graph.AddEdge(gray, skyblue);
            graph.AddEdge(gray, orange);
            graph.AddEdge(orange, purple);
            graph.AddEdge(purple, yellow);

            // Display adjacency matrix and adjacency list
            graph.DisplayAdjacencyMatrix();
            Console.WriteLine();
            graph.DisplayAdjacencyList();
        }
    }
}
