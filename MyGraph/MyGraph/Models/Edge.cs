namespace MyGraph.Models
{
    /// <summary>
    /// Edge of graph
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// The vertex from which the edge goes
        /// </summary>
        public Vertex From { get; set; }
        /// <summary>
        /// The vertex to which the edge goes
        /// </summary>
        public Vertex To { get; set; }
        /// <summary>
        /// Edge weight 
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Edge constructor 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="weight"></param>
        /// <exception cref="NullReferenceException"></exception>
        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            if (from == null || to == null)
            {
                throw new NullReferenceException("Input vertex is null");
            }
            From = from;
            To = to;
            Weight = weight;
        }

        /// <summary>
        /// Override method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"From: {From} To: {To}, Weight: {Weight}";
        }
    }
}
