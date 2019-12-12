namespace DijkstraAlgorithm.Models
{
    using System;
    using System.Drawing;

    using DijkstraAlgorithm.Models.Interfaces;

    using static Utilities.ConstantDelimeters;

    public class Vertex : IComparable, IVertex
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        // Does not set in constructor - why?
        public int SourceId { get; set; }

        public int MinCost { get; set; }

        public bool Permanent { get; set; }

        public bool Visited { get; set; }

        public Vertex(int id)
        {
            this.Id = id;
            this.MinCost = int.MaxValue;
            this.Permanent = false;
            this.Visited = false;
        }

        /// <summary>
        /// Returns center point of a Vertex
        /// </summary>
        public Point Center =>
            new Point(this.X * VertexConstants.CENTER_DIAMETER + VertexConstants.CENTER_RADIUS,
                this.Y * VertexConstants.CENTER_DIAMETER + VertexConstants.CENTER_RADIUS);

        /// <summary>
        /// Returns location point of a Vertex
        /// </summary>
        public Point Location =>
            new Point(this.X * VertexConstants.CENTER_DIAMETER, this.Y * VertexConstants.CENTER_DIAMETER);

        /// <summary>
        /// Returns default size of a Vertex
        /// </summary>
        public Size Size =>
            new Size(VertexConstants.CENTER_DIAMETER, VertexConstants.CENTER_DIAMETER);

        public int CompareTo(object obj)
        {
            return this.Id.CompareTo((obj as Vertex).Id);
        }

        public static int operator +(Vertex x, Edge y)
        {
            return x.MinCost + y.Weight;
        }
    }
}
