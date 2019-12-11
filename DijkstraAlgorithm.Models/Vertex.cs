namespace DijkstraAlgorithm.Models
{
    using System;
    using System.Drawing;

    using DijkstraAlgorithm.Models.Interfaces;

    public class Vertex : IComparable, IVertex
    {
        public static int CENTER_DIAMETER = 30;

        public static int CENTER_RADIUS = 15;

        public int Id { get; set; }

        // Does not set in constructor - why?
        public int X { get; set; }

        // Does not set in constructor - why?
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
            new Point(this.X * CENTER_DIAMETER + CENTER_RADIUS, this.Y * CENTER_DIAMETER + CENTER_RADIUS);

        /// <summary>
        /// Returns location point of a Vertex
        /// </summary>
        public Point Location =>
            new Point(this.X * CENTER_DIAMETER, this.Y * CENTER_DIAMETER);

        /// <summary>
        /// Returns default size of a Vertex
        /// </summary>
        public Size Size =>
            new Size(CENTER_DIAMETER, CENTER_DIAMETER);

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
