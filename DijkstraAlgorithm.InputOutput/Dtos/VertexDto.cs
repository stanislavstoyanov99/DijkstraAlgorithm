namespace DijkstraAlgorithm.InputOutput.Dtos
{
    using System.Drawing;

    public class VertexDto
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int SourceId { get; set; }

        public int MinCost { get; set; }

        public Point Center { get; set; }
    }
}
