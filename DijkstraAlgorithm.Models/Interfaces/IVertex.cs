namespace DijkstraAlgorithm.Models.Interfaces
{
    using System.Drawing;

    public interface IVertex
    {
        int Id { get; set; }

        int X { get; }

        int Y { get; }

        int SourceId { get; }

        int MinCost { get; }

        bool Permanent { get; }

        bool Visited { get; }

        Point Center { get; }

        Point Location { get; }

        Size Size { get; }
    }
}
