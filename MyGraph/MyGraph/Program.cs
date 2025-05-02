using MyGraph.Models;

namespace MyGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            Vertex v1 = new Vertex(1);
            Vertex v2 = new Vertex(2);
            Vertex v3 = new Vertex(3);
            Vertex v4 = new Vertex(4);
            Vertex v5 = new Vertex(5);
            Vertex v6 = new Vertex(6);
            Vertex v7 = new Vertex(7);
            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddEdge(v1, v2, 12);
            graph.AddVertex(v3);
            graph.AddEdge(v1, v3, 13);
            graph.AddVertex(v4);
            graph.AddEdge(v3, v4, 4);
            graph.AddVertex(v5);
            graph.AddEdge(v2, v5, 25);
            graph.AddVertex(v6);
            graph.AddEdge(v2, v6, 26);
            graph.AddEdge(v5, v6, 1);
            graph.AddVertex(v7);
            graph.AddEdge(v6, v7, 999);

            GetMatrix(graph);

            GetVertices(graph, v2);

            Console.WriteLine("The result of obtaining paths by the wave method");
            Console.WriteLine($"Result find from {v1} to {v5}: {graph.FindPathFromTo(v1, v5)}");
            Console.WriteLine($"Result find from {v2} to {v4}: {graph.FindPathFromTo(v2, v4)}");
            Console.WriteLine($"Result find from {v4} to {v6}: {graph.FindPathFromTo(v4, v6)}");
            Console.WriteLine($"Result find from {v5} to {v6}: {graph.FindPathFromTo(v5, v6)}");
            Console.WriteLine($"Result find from {v1} to {v7}: {graph.FindPathFromTo(v1, v7)}");
            Console.WriteLine();

            Console.WriteLine("The result of obtaining paths using the depth-first traversal method");
            bool result;
            result = graph.FindPathFromToDeep(v2, v1);
            Console.WriteLine($"Result find from {v2} to {v1}: " + result);

            result = graph.FindPathFromToDeep(v2, v3);
            Console.WriteLine($"Result find from {v2} to {v3}: " + result);

            result = graph.FindPathFromToDeep(v2, v5);
            Console.WriteLine($"Result find from {v2} to {v5}: " + result);

            result = graph.FindPathFromToDeep(v2, v6);
            Console.WriteLine($"Result find from {v2} to {v6}: " + result);

            result = graph.FindPathFromToDeep(v2, v4);
            Console.WriteLine($"Result find from {v2} to {v4}: " + result);

            result = graph.FindPathFromToDeep(v2, v7);
            Console.WriteLine($"Result find from {v2} to {v7}: " + result);

            result = graph.FindPathFromToDeep(v6, v4);
            Console.WriteLine($"Result find from {v6} to {v4}: " + result);
        }

        /// <summary>
        /// Get the adjacency matrix
        /// </summary>
        /// <param name="graph"></param>
        private static void GetMatrix(Graph graph)
        {
            int[,] matrix = graph.GetMatrix();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(i + 1);

                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write("|\t");
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.Write("|\t");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Display a list of vertices
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="vertex"></param>
        private static void GetVertices(Graph graph, Vertex vertex)
        {
            List<Vertex> vertices = graph.GetVertexLists(vertex);
            Console.Write(vertex.VertexId + ":\t");
            foreach (Vertex v in vertices)
            {
                Console.Write(v.ToString() + "\t");
            }
            Console.WriteLine();
        }
    }
}