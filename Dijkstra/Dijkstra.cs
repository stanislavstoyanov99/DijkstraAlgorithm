namespace Dijkstra
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using global::Dijkstra.Utilities;
    using DijkstraAlgorithm.Models.Interfaces;

    public class Dijkstra
    {
        private readonly IGraph graph;
        private static IVertex initialVertex;
        private static IVertex currVertex;

        private int index;
        private int minCost;

        public Dijkstra(IGraph graph, int startId)
        {
            this.graph = graph;
            initialVertex = this.graph[startId];
        }

        /// <summary>
        /// Original version, calculates the shortest distance directly
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

        public void FirstStep(PictureBox pictureBoxGraph)
        {
            initialVertex.MinCost = 0;
            initialVertex.Permanent = true;
            initialVertex.SourceId = initialVertex.Id;

            pictureBoxGraph.Invalidate();
            initialVertex.Color = Color.LightGreen;

            minCost = int.MaxValue;
            index = 0;

            MessageBox.Show(OutputMessages.Initialization,
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void SecondStep(PictureBox pictureBoxGraph, int startId, RichTextBox richTextBox)
        {
            currVertex = this.graph.GetNonPermanentVertex();
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

                if (currVertex.MinCost < minCost)
                {
                    minCost = currVertex.MinCost;
                    index = currVertex.Id;
                }
            }

            currVertex.Permanent = true;
            pictureBoxGraph.Invalidate();
            currVertex.Color = Color.Red;

            if (currVertex.MinCost == int.MaxValue || currVertex.MinCost == int.MaxValue * -1)
            {
                richTextBox.Text +=
                    String.Format(string.Format(OutputMessages.InfinityMessage,
                    startId,
                    currVertex.Id + 1)) +
                    Environment.NewLine;
            }
            else
            {
                richTextBox.Text +=
                    String.Format(string.Format(OutputMessages.DistanceMessage,
                    startId,
                    currVertex.Id + 1,
                    currVertex.MinCost)) +
                    Environment.NewLine;
            }

            currVertex.MinCost = int.MaxValue;
        }

        public bool IsFinished(PictureBox pictureBoxGraph)
        {
            if (this.graph.NonPermanent().Count == 0)
            {
                MessageBox.Show(OutputMessages.FinishedExecution,
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return true;
            }
            else
            {
                pictureBoxGraph.Invalidate();
                currVertex.Color = Color.LightYellow; // Change color again to indicate that algorithm has not finished
                return false;
            }
        }
    }
}
