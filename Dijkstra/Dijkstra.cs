namespace Dijkstra
{
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;

    using DijkstraAlgorithm.Drawing;
    using DijkstraAlgorithm.Models.Interfaces;

    public static class Dijkstra
    {
        /// <summary>
        /// Calculates the shortest distance between vertices using Dijkstra's algorithm.
        /// </summary>
        public static void GetShortestPath(IGraph Graph, int startId, PictureBox pictureBoxGraph)
        {
            IVertex initialVertex = Graph[startId];

            initialVertex.MinCost = 0;
            initialVertex.Permanent = true;
            initialVertex.SourceId = initialVertex.Id;

            foreach (var vertex in Graph.Vertices)
            {
                int minCost = int.MaxValue;
                int index = 0;

                foreach (IVertex currVertex in Graph.NonPermanent())
                {
                    IEdge edge = Graph.GetEdge(initialVertex, currVertex);

                    if (edge != null)
                    {
                        int sum = initialVertex.MinCost + edge.Weight;

                        if (sum < currVertex.MinCost)
                        {
                            currVertex.MinCost = sum;
                            currVertex.SourceId = initialVertex.Id;
                        }
                    }

                    if (currVertex.MinCost < minCost)
                    {
                        minCost = currVertex.MinCost;
                        index = currVertex.Id;
                    }

                    pictureBoxGraph.Invalidate();
                    pictureBoxGraph.Paint += (sender, e) => Graph_Paint(sender, e, currVertex);
                }

                Graph[index].Permanent = true;
                initialVertex = Graph[index];
            }
        }

        private static void Graph_Paint(object sender, PaintEventArgs e, IVertex vertex)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Vertex Ellipse Reconstruction
            VertexDraw vertexDraw = new VertexDraw(vertex);
            vertexDraw.Draw(e, Color.Red);
        }
    }
}
