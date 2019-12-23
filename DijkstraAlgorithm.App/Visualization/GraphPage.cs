namespace DijkstraAlgorithm.App.Visualization
{
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    using Point = System.Drawing.Point;

    using DijkstraAlgorithm.Models;
    using DijkstraAlgorithm.App.Interfaces;
    using DijkstraAlgorithm.Models.Interfaces;

    using DijkstraAlgorithm.App.Utilities.Messages;

    using static Models.Utilities.ConstantDelimeters;
    using DijkstraAlgorithm.Drawing;

    public class GraphPage : TabPage, IGraphPage
    {
        private bool onHold = false;

        private Point source = new Point(0, 0);

        private Point destination = new Point(0, 0);

        private Point matrixHoverPoint = new Point(0, 0);

        public CPictureBox PictureBoxGraph { get; private set; }

        public PictureBox PictureBoxMatrix { get; private set; }

        public TabControl TabControl { get; set; }

        public TabPage TabPageMatrix { get; private set; }

        public TabPage TapPageLogs { get; private set; }

        public RichTextBox RichTextBoxLogs { get; set; }

        public IGraph InvokeGraph { get; private set; }

        public GraphPage(IGraph Graph, string tabName = "New tab")
        {
            this.Text = tabName;
            this.BackColor = Color.White;
            this.InvokeGraph = Graph;

            this.AddControls();

            this.PictureBoxGraph.Paint += (sender, e) => Graph_OnPaint(sender, e, Graph);
            this.PictureBoxMatrix.Paint += (sender, e) => Matrix_OnPaint(sender, e, Graph);

            Mouse_Down(Graph);
            Mouse_Up(Graph);
            Mouse_Move();

            Mouse_Down_Matrix(Graph);
            Mouse_Move_Matrix();
        }

        private void Mouse_Move()
        {
            this.PictureBoxGraph.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (onHold)
                {
                    this.destination = new Point(e.X, e.Y);

                    // Redraw graph box
                    PictureBoxGraph.Invalidate();
                }
            };
        }

        private void Mouse_Up(IGraph Graph)
        {
            this.PictureBoxGraph.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int sourceX = this.source.X / VertexConstants.CENTER_DIAMETER;
                    int sourceY = this.source.Y / VertexConstants.CENTER_DIAMETER;

                    int destinationX = this.destination.X / VertexConstants.CENTER_DIAMETER;
                    int destinationY = this.destination.Y / VertexConstants.CENTER_DIAMETER;

                    IVertex firstVertex = Graph.GetVertex(sourceX, sourceY);
                    IVertex secondVertex = Graph.GetVertex(destinationX, destinationY);

                    if (firstVertex != null && secondVertex != null && firstVertex != secondVertex && onHold)
                    {
                        Graph.Connect(firstVertex, secondVertex);
                    }

                    // Redraw graph box and matrix box
                    PictureBoxGraph.Invalidate();
                    PictureBoxMatrix.Invalidate();
                }

                onHold = false;
            };
        }

        private void Mouse_Down(IGraph Graph)
        {
            this.PictureBoxGraph.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                int x = e.X / VertexConstants.CENTER_DIAMETER;
                int y = e.Y / VertexConstants.CENTER_DIAMETER;

                IVertex vertex = Graph.GetVertex(x, y);

                // With left button - adds vertex; with right button - removes it
                if (e.Button == MouseButtons.Left)
                {
                    if (vertex == null)
                    {
                        bool result = Graph.AddVertex(new Vertex(Graph.VertexCount)
                        {
                            X = x,
                            Y = y
                        });

                        if (!result)
                        {
                            MessageBox.Show(OutputMessages.VertexLimitWarning, "Warning");
                        }
                    }
                    else
                    {
                        this.source = this.destination = vertex.Center;

                        this.onHold = true;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    bool isRemoved = Graph.RemoveVertex(vertex);

                    if (!isRemoved)
                    {
                        MessageBox.Show(OutputMessages.VertexCouldNotBeFound, "Warning");
                    }
                }

                // Redraw the box graph and box matrix
                PictureBoxGraph.Invalidate();
                PictureBoxMatrix.Invalidate();
            };
        }

        private void Mouse_Down_Matrix(IGraph Graph)
        {
            this.PictureBoxMatrix.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                int row = e.X / VertexConstants.CENTER_DIAMETER - 1;
                int col = e.Y / VertexConstants.CENTER_DIAMETER - 1;

                if (row != col && row < Graph.VertexCount && col < Graph.VertexCount && row > -1 && col > -1)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Graph.Connect(Graph[row], Graph[col]);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        IEdge edge = Graph.GetEdge(Graph[row], Graph[col]);

                        if (edge != null && edge.Weight - 1 == 0)
                        {
                            Graph.RemoveEdge(edge);
                        }
                        else if (edge == null)
                        {
                            MessageBox.Show(OutputMessages.EdgeCouldNotBeFound, "Warning");
                        }
                        else
                        {
                            edge.Weight--;
                        }

                        PictureBoxMatrix.Invalidate();
                        PictureBoxGraph.Invalidate();
                    }
                }
            };
        }

        private void Mouse_Move_Matrix()
        {
            this.PictureBoxMatrix.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                int x = e.Location.X / VertexConstants.CENTER_DIAMETER * VertexConstants.CENTER_DIAMETER;
                int y = e.Location.Y / VertexConstants.CENTER_DIAMETER * VertexConstants.CENTER_DIAMETER;

                this.matrixHoverPoint = new Point(x, y);

                this.PictureBoxMatrix.Invalidate();
                this.PictureBoxGraph.Invalidate();
            };
        }

        private void AddControls()
        {
            this.PictureBoxGraph = new CPictureBox()
            {
                Location = new Point(15, 15),
                Size = new Size(480, 480)
            };

            this.Controls.Add(PictureBoxGraph);

            this.TabControl = new TabControl()
            {
                Location = new Point(531, 15),
                Size = new Size(480, 480)
            };

            this.Controls.Add(TabControl);

            this.TabPageMatrix = new TabPage("Образуваща се матрица")
            {
                BackColor = Color.White
            };

            this.TabControl.TabPages.Add(TabPageMatrix);

            this.PictureBoxMatrix = new PictureBox()
            {
                Location = new Point(12, 18),
                Size = new Size(480, 480)
            };

            this.TapPageLogs = new TabPage("Резултат от изпълнението")
            {
                BackColor = Color.White
            };

            this.TabControl.TabPages.Add(TapPageLogs);

            this.RichTextBoxLogs = new RichTextBox()
            {
                Location = new Point(12, 12),
                Size = new Size(440, 440)
            };

            this.RichTextBoxLogs.ReadOnly = true;

            this.TabControl.TabPages[0].Controls.Add(PictureBoxMatrix);
            this.TabControl.TabPages[1].Controls.Add(RichTextBoxLogs);
        }

        private void Graph_OnPaint(object sender, PaintEventArgs e, IGraph Graph)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Drag & Drop Connection Line Reconstruction
            if (this.onHold)
            {
                var lineDraw = new LineDraw();
                lineDraw.DrawDragDropLine(e, source, destination);
            }

            foreach (IEdge edge in Graph.Edges)
            {
                var lineDraw = new LineDraw(edge);

                lineDraw.Draw(e, Color.IndianRed);
            }

            // Vertex Ellipse Reconstruction
            foreach (IVertex vertex in Graph.Vertices)
            {
                VertexDraw vertexDraw = new VertexDraw(vertex);

                vertexDraw.Draw(e, Color.LightYellow);
            }
        }

        private void Matrix_OnPaint(object sender, PaintEventArgs e, IGraph Graph)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Grid Hover Highlight
            if (matrixHoverPoint.X > 0 && matrixHoverPoint.Y > 0 &&
                (matrixHoverPoint.X / VertexConstants.CENTER_DIAMETER) <= Graph.VertexCount &&
                matrixHoverPoint.Y / VertexConstants.CENTER_DIAMETER <= Graph.VertexCount)
            {
                var brush = new SolidBrush(Color.LightYellow);
                var pen = new Pen(Color.Black);

                e.Graphics.FillRectangle(brush,
                    matrixHoverPoint.X,
                    matrixHoverPoint.Y,
                    MatrixConstants.MATRIX_GRID_WEIGHT,
                    MatrixConstants.MATRIX_GRID_HEIGHT);

                brush.Dispose();
                pen.Dispose();
            }

            // Horizonal Label Reconstruction
            var font = new Font("Consolas", 10, FontStyle.Italic);
            var solidBrush = new SolidBrush(Color.Black);

            int x = MatrixConstants.MATRIX_GRID_WEIGHT, y = 0;

            for (int i = 0; i < Graph.VertexCount; i++)
            {
                e.Graphics.DrawString(string.Format("{0,2}", i + 1), font, solidBrush, x + 7, y);

                x += MatrixConstants.MATRIX_GRID_WEIGHT;
            }

            // Vertical Label Reconstruction
            x = 0; y = MatrixConstants.MATRIX_GRID_HEIGHT;

            for (int i = 0; i < Graph.VertexCount; i++)
            {
                e.Graphics.DrawString(string.Format("{0,2}", i + 1), font, solidBrush, x, y + 7);

                y += MatrixConstants.MATRIX_GRID_HEIGHT;
            }

            // Matrix reconstruction
            x = MatrixConstants.MATRIX_GRID_WEIGHT; y = MatrixConstants.MATRIX_GRID_HEIGHT;

            for (int row = 0; row < Graph.VertexCount; row++)
            {
                for (int col = 0; col < Graph.VertexCount; col++)
                {
                    var pen = new Pen(SystemColors.ActiveBorder, 1);

                    e.Graphics.DrawRectangle(pen,
                        x,
                        y,
                        MatrixConstants.MATRIX_GRID_WEIGHT,
                        MatrixConstants.MATRIX_GRID_HEIGHT);

                    pen.Dispose();

                    // Ensure there isn't any loop on matrix diagonal
                    if (row == col)
                    {
                        e.Graphics.DrawString(string.Format("{0,2}", "-"), font, solidBrush, x + 2, y + 7);
                    }

                    foreach (IEdge edge in Graph.Edges)
                    {
                        if ((edge[0].Id == row && edge[1].Id == col) || (edge[0].Id == col && edge[1].Id == row))
                        {
                            e.Graphics.DrawString(string.Format("{0,2}", edge.Weight), this.Font, solidBrush, x + 6, y + 9);
                        }
                    }

                    x += MatrixConstants.MATRIX_GRID_WEIGHT;
                }

                x = MatrixConstants.MATRIX_GRID_WEIGHT;
                y += MatrixConstants.MATRIX_GRID_HEIGHT;
            }

            font.Dispose();
            solidBrush.Dispose();
        }
    }
}
