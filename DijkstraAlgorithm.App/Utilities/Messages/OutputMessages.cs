namespace DijkstraAlgorithm.App.Utilities.Messages
{
    public static class OutputMessages
    {
        public const string TabLimitWarning 
            = "Tab limit is set to {0}!";

        public const string TabConstraintWarning 
            = "Cannot close the last standing tab!";

        public const string VertexLimitWarning 
            = "Vertex limit reached!";

        public const string VertexCouldNotBeFound 
            = "The requested vertex could not be found.";

        public const string InvalidStartVertexId 
            = "Initial Vertex Id textbox should not be empty or contain letters.";

        public const string EdgeCouldNotBeFound 
            = "Cannot lower value of missing edge.";

        public const string InvalidTabName 
            = "Tab name cannot consist of numbers. Lowercase and uppercase letters, special symbols are allowed.";

        public const string InfinityMessage 
            = "Shortest distance between vertices {0} and {1} is INFINITY";

        public const string DistanceMessage 
            = "Shortest distance between vertices {0} and {1} is {2}";

        public const string AlgorithmDefinedMessage
            = "Please choose algorithm to run.";

        public const string TabPageNotFound 
            = "Please add new work tab page.";
    }
}
