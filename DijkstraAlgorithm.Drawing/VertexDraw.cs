namespace DijkstraAlgorithm.Drawing
{
    using System.Drawing;
    using System.Windows.Forms;

    using DijkstraAlgorithm.Models.Interfaces;
    using DijkstraAlgorithm.Drawing.Contracts;

    public class VertexDraw : IVertexDraw
    {
        public VertexDraw(IVertex vertex)
        {
            this.Vertex = vertex;
        }

        public IVertex Vertex { get; private set; }

        public void Draw(Graphics g)
        {
            var brushFill = new SolidBrush(Vertex.Color);
            var pen = new Pen(Color.Black);

            var fillRectangle = new Rectangle(Vertex.Location, Vertex.Size);
            var drawRectangle = new Rectangle(Vertex.Location, Vertex.Size);

            g.FillEllipse(brushFill, fillRectangle);
            g.DrawEllipse(pen, drawRectangle);

            brushFill.Dispose();
            pen.Dispose();

            var brushDraw = new SolidBrush(Color.Black);
            float x = Vertex.Location.X + 7; 
            float y = Vertex.Location.Y + 9;

            g.DrawString(string.Format("{0,2}", Vertex.Id + 1), Control.DefaultFont, brushDraw, x, y);

            brushDraw.Dispose();
        }
    }
}
