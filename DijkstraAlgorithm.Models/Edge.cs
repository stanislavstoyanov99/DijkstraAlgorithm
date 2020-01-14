namespace DijkstraAlgorithm.Models
{
    using System;

    using DijkstraAlgorithm.Models.Interfaces;
    using DijkstraAlgorithm.Models.Utilities.Messages;

    using static Utilities.ConstantDelimeters;

    public class Edge : IEdge
    {
        public Edge(IVertex firstVertex, IVertex secondVertex)
        {
            this.FirstVertex = firstVertex;
            this.SecondVertex = secondVertex;

            this.Weight = EdgeConstants.INITIAL_WEIGHT;
        }

        public Edge(IVertex firstVertex, IVertex secondVertex, int weight)
        {
            this.FirstVertex = firstVertex;
            this.SecondVertex = secondVertex;
            this.Weight = weight;
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
