namespace DijkstraAlgorithm.Models.Interfaces
{
    using System.Drawing;

    public interface IVertex
    {
        int Id { get; set; }

        int X { get; }

        int Y { get; }

        int SourceId { get; set; }

        int MinCost { get; set; }

        bool Permanent { get; set; }

        bool Visited { get; set; }

        Point Center { get; }

        Point Location { get; }

        Size Size { get; }

        Color Color { get; set; }
    }
}
