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

        public void Draw(PaintEventArgs e)
        {
            var brushFill = new SolidBrush(Color.LightYellow);
            var pen = new Pen(Color.Black);

            var fillRectangle = new Rectangle(Vertex.Location, Vertex.Size);
            var drawRectangle = new Rectangle(Vertex.Location, Vertex.Size);

            e.Graphics.FillEllipse(brushFill, fillRectangle);
            e.Graphics.DrawEllipse(pen, drawRectangle);

            brushFill.Dispose();
            pen.Dispose();

            var brushDraw = new SolidBrush(Color.Black);
            float x = Vertex.Location.X + 7; 
            float y = Vertex.Location.Y + 9;

            e.Graphics.DrawString(string.Format("{0,2}", Vertex.Id + 1), Control.DefaultFont, brushDraw, x, y);

            brushDraw.Dispose();
        }
    }
}
