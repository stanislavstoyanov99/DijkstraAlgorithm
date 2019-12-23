namespace DijkstraAlgorithm.Models.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidVertexIndex 
            = "Vertex index should be zero or one.";

        public const string InvalidStartVertexId 
            = "Vertex start number should be greater than or equal to zero.";

        public const string MissingGraph 
            = "Please firstly construct your graph.";

        public const string DistanceMessage
            = "Shortest distance between vertices {0} and {1} is {2}";

        public const string InfinityMessage
            = "Shortest distance between vertices {0} and {1} is INFINITY";
    }
}
