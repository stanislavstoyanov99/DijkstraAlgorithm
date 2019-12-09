namespace DijkstraAlgorithm.Models
{
    using System;

    using DijkstraAlgorithm.Models.Interfaces;
    using DijkstraAlgorithm.Models.Utilities.Messages;

    public class Edge : IEdge
    {
        public static int INITIAL_WEIGHT = 1;

        public Edge(IVertex FirstVertex, IVertex SecondVertex)
        {
            this.FirstVertex = FirstVertex;
            this.SecondVertex = SecondVertex;

            this.Weight = INITIAL_WEIGHT;
        }

        public IVertex FirstVertex { get; set; }

        public IVertex SecondVertex { get; set; }

        public int Weight { get; set; }

        public IVertex this[int index] 
        { 
            get
            {
                if (index == 0)
                {
                    return this.FirstVertex;
                }
                else if (index == 1)
                {
                    return this.SecondVertex;
                }
                else
                {
                    throw new IndexOutOfRangeException(ExceptionMessages.InvalidVertexIndex);
                }
            }
        }
    }
}
