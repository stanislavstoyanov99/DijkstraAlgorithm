namespace DijkstraAlgorithm.Drawing.Contracts
{
    using System.Drawing;
    using System.Windows.Forms;

    using DijkstraAlgorithm.Models.Interfaces;

    public interface ILineDraw
    {
        IEdge Edge { get; }

        void Draw(PaintEventArgs e);

        void DrawDragDropLine(PaintEventArgs e, Point point, Point destination);
    }
}
