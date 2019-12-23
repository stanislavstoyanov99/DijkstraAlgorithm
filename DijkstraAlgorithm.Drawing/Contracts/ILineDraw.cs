namespace DijkstraAlgorithm.Drawing.Contracts
{
    using System.Drawing;
    using System.Windows.Forms;

    using DijkstraAlgorithm.Models.Interfaces;

    public interface ILineDraw
    {
        IEdge Edge { get; }

        void Draw(PaintEventArgs e, Color color);

        void DrawDragDropLine(PaintEventArgs e, Point point, Point destination);
    }
}
