using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5
{
    // Author: Sebastian Arroyo
    // Purpose: Digraph to AdjacencyMatrix/List with DFS and Dijkstra's Algorithm
    // Restrictions: None
    class Graph
    {
        private int[,] adjacencyMatrix;
        private List<List<int>> adjacencyList;
        private Dictionary<int, string> colorNames;

        // Purpose: Constructor
        // Restrictions: None
        public Graph(int vertices)
        {
            adjacencyMatrix = new int[vertices, vertices];
            adjacencyList = new List<List<int>>(vertices);
            colorNames = new Dictionary<int, string>();

            for (int i = 0; i < vertices; i++)
            {
                adjacencyList.Add(new List<int>());
            }

            InitializeColorNames();
        }

        // Purpose: Create edge between vertices
        // Restrictions: None
        public void AddEdge(int from, int to)
        {
            adjacencyMatrix[from, to] = 1;
            adjacencyList[from].Add(to);
        }

        // Purpose: Initialize color names
        // Restrictions: None
        private void InitializeColorNames()
        {
            colorNames.Add(0, "Red");
            colorNames.Add(1, "Blue");
            colorNames.Add(2, "Gray");
            colorNames.Add(3, "SkyBlue");
            colorNames.Add(4, "Orange");
            colorNames.Add(5, "Yellow");
            colorNames.Add(6, "Purple");
            colorNames.Add(7, "Green");
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
                Console.Write($"{colorNames[i]}: ");
                foreach (var neighbor in adjacencyList[i])
                {
                    Console.Write($"{colorNames[neighbor]} ");
                }
                Console.WriteLine();
            }
        }

        // Purpose: Perform Dijkstra's shortest path algorithm
        // Restrictions: None
        public void DijkstraShortestPath(int startVertex, int endVertex)
        {
            Console.WriteLine("Shortest Path:");

            int[] distance = new int[adjacencyList.Count];
            int[] previous = new int[adjacencyList.Count];
            bool[] visited = new bool[adjacencyList.Count];

            // Initialize distance and previous arrays
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                distance[i] = int.MaxValue;
                previous[i] = -1;
                visited[i] = false;
            }

            distance[startVertex] = 0;

            for (int i = 0; i < adjacencyList.Count - 1; i++)
            {
                int u = MinDistance(distance, visited);
                visited[u] = true;

                foreach (var neighbor in adjacencyList[u])
                {
                    if (!visited[neighbor] && distance[u] != int.MaxValue && distance[u] + 1 < distance[neighbor])
                    {
                        distance[neighbor] = distance[u] + 1;
                        previous[neighbor] = u;
                    }
                }
            }

            PrintShortestPath(startVertex, endVertex, previous);
        }

        // Purpose: Find the vertex with the minimum distance value
        // Restrictions: None
        private int MinDistance(int[] distance, bool[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < adjacencyList.Count; i++)
            {
                if (!visited[i] && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        // Purpose: Print the shortest path from startVertex to endVertex
        // Restrictions: None
        private void PrintShortestPath(int startVertex, int endVertex, int[] previous)
        {
            if (previous[endVertex] == -1)
            {
                Console.WriteLine("No path found.");
                return;
            }

            Console.Write($"{colorNames[startVertex]} ");
            PrintShortestPathRecursive(startVertex, endVertex, previous);
        }

        // Purpose: Recursive function to print the shortest path
        // Restrictions: None
        private void PrintShortestPathRecursive(int startVertex, int currentVertex, int[] previous)
        {
            if (previous[currentVertex] == -1)
                return;

            PrintShortestPathRecursive(startVertex, previous[currentVertex], previous);
            Console.Write($"{colorNames[currentVertex]} ");
        }
    }

    // Author: Sebastian Arroyo
    // Purpose: Program
    // Restrictions: None
    internal class Program
    {
        // Purpose: Recreate digraph and perform Dijkstra's shortest path
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
            Console.WriteLine();


            // Perform Dijkstra's shortest path from "Red" to "Green"
            graph.DijkstraShortestPath(red, green);
            Console.WriteLine();

        }
    }
}
