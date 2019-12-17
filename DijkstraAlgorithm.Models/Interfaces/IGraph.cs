namespace DijkstraAlgorithm.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IGraph
    {
        IEnumerable<IVertex> NonVisited();

        IEnumerable<IVertex> NonPermanent();

        IReadOnlyCollection<IVertex> Vertices { get; }

        IReadOnlyCollection<IEdge> Edges { get; }

        IVertex this[int index] { get; }

        IEdge GetEdge(IVertex firstVertex, IVertex secondVertex);

        IVertex GetVertex(int x, int y);

        bool AddVertex(IVertex vertex);

        bool RemoveVertex(IVertex vertex);

        void Connect(IVertex firstVertex, IVertex secondVertex);

        int VertexCount { get; }

        bool RemoveEdge(IEdge edge);
    }
}
