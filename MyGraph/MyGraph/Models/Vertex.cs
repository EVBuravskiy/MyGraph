namespace MyGraph.Models
{
    /// <summary>
    /// Vertex of graph
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// Vertex identificator
        /// </summary>
        public int VertexId { get; set; }

        // Here can add other properties

        /// <summary>
        /// Constructor for vertex
        /// </summary>
        /// <param name="vertexId"></param>
        public Vertex(int vertexId)
        {
            VertexId = vertexId;
        }

        /// <summary>
        /// Override method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return VertexId.ToString();
        }
    }
}
