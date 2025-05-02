namespace MyGraph.Models
{
    public class Graph
    {
        /// <summary>
        /// List of vertices
        /// </summary>
        public List<Vertex> Vertices { get; set; }

        /// <summary>
        /// List of edges
        /// </summary>
        public List<Edge> Edges { get; set; }

        /// <summary>
        /// An indicator of the orientation of a graph edge
        /// </summary>
        public bool Oriented { get; set; }

        /// <summary>
        /// Count of vertices
        /// </summary>
        public int VertexCount => Vertices.Count;

        /// <summary>
        /// Count of edges
        /// </summary>
        public int EdgeCount => Edges.Count;

        /// <summary>
        /// Graph constructor
        /// </summary>
        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
            Oriented = false;
        }

        /// <summary>
        /// Add vertex to graph
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        /// <summary>
        /// Add edge to graph
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="weight"></param>
        /// <param name="oriented"></param>
        public void AddEdge(Vertex from, Vertex to, int weight = 1, bool oriented = false)
        {
            Oriented = oriented;
            //If the edge is not oriented, then the connections to both vertices
            if (!Oriented)
            {
                Edge EdgeFromTo = new Edge(from, to, weight);
                Edge EdgeToFrom = new Edge(to, from, weight);
                Edges.Add(EdgeFromTo);
                Edges.Add(EdgeToFrom);
            }
            //If the edge is oriented, then the connection from one to the second vertex
            else
            {
                Edge EdgeFromTo = new Edge(from, to, weight);
                Edges.Add(EdgeFromTo);
            }
        }

        /// <summary>
        /// Generating an adjacency matrix
        /// </summary>
        /// <returns>array int[,]</returns>
        public int[,] GetMatrix()
        {
            int[,] matrix = new int[Vertices.Count, Vertices.Count];
            foreach (Edge edge in Edges)
            {
                var row = edge.From.VertexId - 1;
                var column = edge.To.VertexId - 1;
                matrix[row, column] = edge.Weight;
            }
            return matrix;
        }
        /// <summary>
        /// Getting the vertex from the current one
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns>List of vertex</returns>
        public List<Vertex> GetVertexLists(Vertex vertex)
        {
            List<Vertex> result = new List<Vertex>();
            foreach (Edge edge in Edges)
            {
                if (edge.From == vertex)
                {

                    result.Add(edge.To);
                }
            }
            return result;
        }

        /// <summary>
        /// Breadth-first traversal of a graph (wave algorithm) to check if there is a path to a vertex
        /// </summary>
        /// <param name="start"></param>
        /// <param name="serched"></param>
        /// <returns>bool</returns>
        public bool FindPathFromTo(Vertex start, Vertex serched)
        {
            List<Vertex> tempList = new List<Vertex>();
            tempList.Add(start);

            for (int i = 0; i < tempList.Count; i++)
            {

                Vertex temp = tempList[i];
                List<Vertex> adjacentVertices = GetVertexLists(temp);
                foreach (Vertex vertex in adjacentVertices)
                {
                    if (!tempList.Contains(vertex))
                    {
                        tempList.Add(vertex);
                    }
                }
            }
            return tempList.Contains(serched);
        }

        /// <summary>
        /// Depth-first traversal of a graph to check if there is a path to a vertex
        /// </summary>
        /// <param name="start"></param>
        /// <param name="searched"></param>
        /// <returns>bool</returns>
        public bool FindPathFromToDeep(Vertex start, Vertex searched)
        {
            List<Vertex> passedVertices = new List<Vertex>();
            passedVertices.Add(start);
            FindPathFromToDeepRecurse(start, searched, passedVertices);
            return passedVertices.Contains(searched);
        }

        /// <summary>
        /// Recursive depth-first traversal of a graph
        /// </summary>
        /// <param name="current"></param>
        /// <param name="searched"></param>
        /// <param name="passedVertices"></param>
        private void FindPathFromToDeepRecurse(Vertex current, Vertex searched, List<Vertex> passedVertices)
        {
            List<Vertex> adjacentVertices = GetVertexLists(current);
            for (int i = 0; i < adjacentVertices.Count; i++)
            {
                Vertex nextVertex = adjacentVertices[i];
                if (passedVertices.Contains(nextVertex))
                {
                    continue;
                }
                if (nextVertex == searched)
                {
                    passedVertices.Add(nextVertex);
                    return;
                }
                else
                {
                    current = nextVertex;
                    passedVertices.Add(current);
                    FindPathFromToDeepRecurse(current, searched, passedVertices);
                }
            }
            return;
        }

    }
}
