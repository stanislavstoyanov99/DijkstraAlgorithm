namespace DijkstraAlgorithm.App.Visualization
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Point = System.Drawing.Point;

    using DijkstraAlgorithm.App.Interfaces;
    using DijkstraAlgorithm.Models;
    using DijkstraAlgorithm.Models.Interfaces;
    using System.ComponentModel;
    using System.Drawing.Design;

    public class GraphPage : TabPage, IGraphPage
    {
        private bool onHold = false;

        private Point source = new Point(0, 0);

        private Point destination = new Point(0, 0);

        private Point matrixHoverPoint = new Point(0, 0);

        public CPictureBox PictureBoxGraph { get; private set; }

        // TODO
        public PictureBox PictureBoxMatrix { get; private set; }

        public TabControl tabControl { get; set; }

        // TODO
        public TabPage TabPageMatrix { get; private set; }

        public TabPage TapPageLogs { get; private set; }

        public RichTextBox RichTextBoxLogs { get; set; }

        public IGraph InvokeGraph { get; set; }

        public GraphPage(IGraph Graph, string tabName)
        {
            this.Text = tabName;
            this.BackColor = Color.White;
            this.InvokeGraph = Graph;

            this.AddControls();

            this.PictureBoxGraph.Paint += (sender, e) => Graph_OnPaint(sender, e, Graph);
            this.PictureBoxMatrix.Paint += (sender, e) => Matrix_OnPaint(sender, e, Graph);
        }

        private void AddControls()
        {
            var pbGraph = new CPictureBox()
            {
                Location = new Point(15, 15),
                Size = new Size(510, 510)
            };

            this.Controls.Add(pbGraph);

            tabControl = new TabControl()
            {
                Location = new Point(531, 15),
                Size = new Size(488, 510)
            };

            this.Controls.Add(tabControl);

            var tbMatrix = new TabPage("Образуваща се матрица")
            {
                BackColor = Color.White
            };

            this.tabControl.TabPages.Add(tbMatrix);

            var pbMatrix = new PictureBox()
            {
                Location = new Point(12, 18),
                Size = new Size(480, 480)
            };

            var rtbLogs = new RichTextBox()
            {
                Location = new Point(12, 12),
                Size = new Size(450, 450)
            };

            this.tabControl.TabPages[0].Controls.Add(pbMatrix);
            this.tabControl.TabPages[1].Controls.Add(rtbLogs);

            var tpLogs = new TabPage("Логове")
            {
                BackColor = Color.White
            };

            this.tabControl.TabPages.Add(tpLogs);
        }

        private void Graph_OnPaint(object sender, PaintEventArgs e, IGraph Graph)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Drag & Drop Connection Line Reconstruction
            if (this.onHold)
            {
                var pen = new Pen(Color.IndianRed, 2)
                {
                    DashPattern = new[]
                    {
                        2f,
                        2f,
                        2f,
                        2f
                    },
                };

                var brush = new SolidBrush(Color.Black);
                float x = 0.5f * (source.X + destination.X);
                float y = 0.5f * (source.Y + destination.Y);

                e.Graphics.DrawLine(pen, source, destination);
                e.Graphics.DrawString(Edge.INITIAL_WEIGHT.ToString(), this.Font, brush, x, y);
            }

            // Connection Line Reconstruction
            foreach (IEdge edge in Graph)
            {
                using (var pen = new Pen(Color.IndianRed, 2))
                {
                    e.Graphics.DrawLine(pen, edge[0].Center, edge[1].Center);
                }
            }

            // Connection Weigh-Label Reconstruction
            foreach (IEdge edge in Graph.Edges)
            {
                using (var brush = new SolidBrush(Color.Black))
                {
                    float x = 0.5f * (edge[0].Center.X + edge[1].Center.X);
                    float y = 0.5f * (edge[0].Center.Y + edge[1].Center.Y);

                    e.Graphics.DrawString(edge.Weight.ToString(), this.Font, brush, x, y);
                };
            }

            // Vertex Ellipse Reconstruction
            foreach (IVertex vertex in Graph)
            {
                var brushFill = new SolidBrush(Color.LightYellow);
                var pen = new Pen(Color.Black);

                var fillRectangle = new Rectangle(vertex.Location, vertex.Size);
                var drawRectangle = new Rectangle(vertex.Location, vertex.Size);

                e.Graphics.FillEllipse(brushFill, fillRectangle);
                e.Graphics.DrawEllipse(pen, drawRectangle);

                var brushDraw = new SolidBrush(Color.Black);
                float x = vertex.Location.X + 7;
                float y = vertex.Location.Y + 9;

                e.Graphics.DrawString(string.Format("{0,2}", vertex.Id + 1), this.Font, brushDraw, x, y);
            }
        }

        // TODO
        private void Matrix_OnPaint(object sender, PaintEventArgs e, IGraph Graph)
        {

        }
    }
}
