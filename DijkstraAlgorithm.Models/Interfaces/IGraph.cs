namespace DijkstraAlgorithm.Models.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IGraph : IEnumerable
    {
        IEnumerable<IVertex> NonVisited();

        IEnumerable<IVertex> NonPermanent();

        IReadOnlyCollection<IVertex> Vertices { get; }

        IReadOnlyCollection<IEdge> Edges { get; }

        IVertex this[int index] { get; }

        IEdge GetEdge(IVertex firstVertex, IVertex secondVertex);

        IVertex GetVertex(int x, int y);

        bool Add(IVertex vertex);

        bool Remove(IVertex vertex);

        void Connect(IVertex firstVertex, IVertex secondVertex);

        int VertexCount { get; }
    }
}
