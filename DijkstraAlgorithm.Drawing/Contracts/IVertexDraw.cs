namespace DijkstraAlgorithm.Drawing.Contracts
{
    using System.Drawing;
    using System.Windows.Forms;

    using DijkstraAlgorithm.Models.Interfaces;

    public interface IVertexDraw
    {
        IVertex Vertex { get; }

        void Draw(PaintEventArgs e, Color color);
    }
}
