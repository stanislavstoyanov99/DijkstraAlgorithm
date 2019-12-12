﻿
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

    using DijkstraAlgorithm.Models;
    using DijkstraAlgorithm.App.Interfaces;
    using DijkstraAlgorithm.Models.Interfaces;

    using static Models.Utilities.ConstantDelimeters;
    using DijkstraAlgorithm.App.Utilities.Messages;

    public class GraphPage : TabPage, IGraphPage
    {
        private bool onHold = false;

        private Point source = new Point(0, 0);

        private Point destination = new Point(0, 0);

        private Point matrixHoverPoint = new Point(0, 0);

        public CPictureBox PictureBoxGraph { get; private set; }

        // TODO
        public PictureBox PictureBoxMatrix { get; private set; }

        public TabControl TabControl { get; set; }

        // TODO
        public TabPage TabPageMatrix { get; private set; }

        public TabPage TapPageLogs { get; private set; }

        public RichTextBox RichTextBoxLogs { get; set; }

        public IGraph InvokeGraph { get; set; }

        public GraphPage(IGraph Graph, string tabName = null)
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

                var vertex = Graph.GetVertex(x, y);

                // With left button - adds vertex; with right button - removes it
                if (e.Button == MouseButtons.Left)
                {
                    if (vertex == null)
                    {
                        bool result = Graph.Add(new Vertex(Graph.VertexCount)
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
                    bool isRemoved = Graph.Remove(vertex);

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

            this.TapPageLogs = new TabPage("Логове")
            {
                BackColor = Color.White
            };

            this.TabControl.TabPages.Add(TapPageLogs);

            this.RichTextBoxLogs = new RichTextBox()
            {
                Location = new Point(12, 12),
                Size = new Size(450, 450)
            };

            this.TabControl.TabPages[0].Controls.Add(PictureBoxMatrix);
            this.TabControl.TabPages[1].Controls.Add(RichTextBoxLogs);
        }

        private void Graph_OnPaint(object sender, PaintEventArgs e, IGraph Graph)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Drag & Drop Connection Line Reconstruction
            if (this.onHold)
            {
                var pen = new Pen(Color.DarkBlue, 2)
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
                e.Graphics.DrawString(EdgeConstants.INITIAL_WEIGHT.ToString(), this.Font, brush, x, y);
            }

            // Connection Line Reconstruction
            foreach (IEdge edge in Graph.Edges)
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
