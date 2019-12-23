namespace DijkstraAlgorithm.Drawing
{
    using System.Drawing;
    using System.Windows.Forms;

    using DijkstraAlgorithm.Drawing.Contracts;
    using DijkstraAlgorithm.Models.Interfaces;

    using static DijkstraAlgorithm.Models.Utilities.ConstantDelimeters;

    public class LineDraw : ILineDraw
    {
        public LineDraw(IEdge edge)
        {
            this.Edge = edge;
        }

        public LineDraw() { }

        public IEdge Edge { get; private set; }

        public void DrawDragDropLine(PaintEventArgs e, Point source, Point destination)
        {
            var pen = new Pen(Color.DarkBlue, 2)
            {
                DashPattern = new[]
                    {
                        4f,
                        4f,
                        4f,
                        4f
                    },
            };

            var brush = new SolidBrush(Color.Black);
            float x = 0.5f * (source.X + destination.X);
            float y = 0.5f * (source.Y + destination.Y);

            e.Graphics.DrawLine(pen, source, destination);
            e.Graphics.DrawString(EdgeConstants.INITIAL_WEIGHT.ToString(), Control.DefaultFont, brush, x, y);

            pen.Dispose();
        }

        public void Draw(PaintEventArgs e, Color color)
        {
            // Connection Line Reconstruction
            using (var pen = new Pen(color, 2))
            {
                e.Graphics.DrawLine(pen, this.Edge[0].Center, this.Edge[1].Center);
            }

            //Connection Weigh-Label Reconstruction
            using (var brush = new SolidBrush(Color.Black))
            {
                float x = 0.5f * (this.Edge[0].Center.X + this.Edge[1].Center.X);
                float y = 0.5f * (this.Edge[0].Center.Y + this.Edge[1].Center.Y);

                e.Graphics.DrawString(this.Edge.Weight.ToString(), Control.DefaultFont, brush, x, y);
            };
        }
    }
}
