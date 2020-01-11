namespace Dijkstra
{
    using System.Drawing;
    using System.Windows.Forms;

    using DijkstraAlgorithm.Models.Interfaces;

    public class Dijkstra
    {
        private const int DEFAULT_CURRENT_STEP = 0;
        private const bool DEFAULT_IS_FINISHED = false;

        private readonly int currentStep;
        private readonly bool isFinished;

        private readonly IGraph graph;

        public Dijkstra(IGraph graph)
        {
            this.graph = graph;
            this.currentStep = DEFAULT_CURRENT_STEP;
            this.isFinished = DEFAULT_IS_FINISHED;
        }

        /// <summary>
        /// Calculates the shortest distance between vertices using Dijkstra's algorithm.
        /// </summary>
        public void GetShortestPath(int startId, PictureBox pictureBoxGraph)
        {
            IVertex initialVertex = graph[startId];

            initialVertex.MinCost = 0;
            initialVertex.Permanent = true;
            initialVertex.SourceId = initialVertex.Id;

            foreach (var vertex in graph.Vertices)
            {
                int minCost = int.MaxValue;
                int index = 0;

                foreach (IVertex currVertex in graph.NonPermanent())
                {
                    IEdge edge = graph.GetEdge(initialVertex, currVertex);

                    if (edge != null)
                    {
                        int sum = initialVertex.MinCost + edge.Weight;

                        if (sum < currVertex.MinCost)
                        {
                            currVertex.MinCost = sum;

                            // set the source id of the current vertex to be the same as the initial vertex
                            currVertex.SourceId = initialVertex.Id;
                        }
                    }

                    if (currVertex.MinCost < minCost)
                    {
                        minCost = currVertex.MinCost;
                        index = currVertex.Id;
                    }

                    pictureBoxGraph.Invalidate();
                    currVertex.Color = Color.Red;
                }

                graph[index].Permanent = true;
                initialVertex = graph[index];
            }
        }
    }
}
