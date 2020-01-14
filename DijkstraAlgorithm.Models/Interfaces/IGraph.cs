namespace DijkstraAlgorithm.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IGraph
    {
        ICollection<IVertex> NonVisited();

        ICollection<IVertex> NonPermanent();

        IVertex GetNonPermanentVertex();

        IReadOnlyCollection<IVertex> Vertices { get; }

        IReadOnlyCollection<IEdge> Edges { get; }

        IVertex this[int index] { get; }

        int VertexCount { get; }

        IEdge GetEdge(IVertex firstVertex, IVertex secondVertex);

        IVertex GetVertex(int x, int y);

        bool AddVertex(IVertex vertex);

        bool RemoveVertex(IVertex vertex);

        void Connect(IVertex firstVertex, IVertex secondVertex);

        void Connect(IVertex firstVertex, IVertex secondVertex, int weight);

        bool RemoveEdge(IEdge edge);
    }
}
