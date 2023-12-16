using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    // Author: Sebastian Arroyo
    // Purpose: Digraph to AdjacencyMatrix/List with DFS
    // Restrictions: None
    class Graph
    {
        private int[,] adjacencyMatrix;
        private List<List<int>> adjacencyList;
        private bool[] visited;

        // Purpose: Constructor
        // Restrictions: None
        public Graph(int vertices)
        {
            adjacencyMatrix = new int[vertices, vertices];
            adjacencyList = new List<List<int>>(vertices);
            visited = new bool[vertices];

            for (int i = 0; i < vertices; i++)
            {
                adjacencyList.Add(new List<int>());
                visited[i] = false;
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

        // Purpose: Perform Depth-First Search starting from a given vertex
        // Restrictions: None
        public void DFS(int startVertex)
        {
            Console.WriteLine("DFS Output:");

            // Reset the visited array
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }

            // Call the recursive DFS function
            DFSRecursive(startVertex);
        }

        // Purpose: Recursive function for Depth-First Search
        // Restrictions: None
        private void DFSRecursive(int vertex)
        {
            visited[vertex] = true;
            Console.WriteLine($"Vertex {vertex} - Color: {GetColorName(vertex)}");

            foreach (var neighbor in adjacencyList[vertex])
            {
                if (!visited[neighbor])
                {
                    DFSRecursive(neighbor);
                }
            }
        }

        // Purpose: Get color name based on the vertex index
        // Restrictions: Assumes vertex index corresponds to color
        private string GetColorName(int vertex)
        {
            string[] colorNames = { "Red", "Blue", "Gray", "SkyBlue", "Orange", "Yellow", "Purple", "Green" };
            return colorNames[vertex];
        }
    }

    // Author: Sebastian Arroyo
    // Purpose: Program
    // Restrictions: None
    internal class Program
    {
        // Purpose: Recreate digraph and perform DFS
        // Restrictions: None
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

            // Perform Depth-First Search starting from the red vertex
            graph.DFS(red);
        }
    }
}
