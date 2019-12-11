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

        IEdge GetEdge(IVertex firstVertex, IVertex secondVertex);

        IVertex GetVertex(int x, int y);

        bool Add(IVertex vertex);

        void Remove(IVertex vertex);

        void Connect(IVertex firstVertex, IVertex secondVertex);

        int VertexCount { get; }
    }
}
