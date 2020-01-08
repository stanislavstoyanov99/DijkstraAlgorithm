namespace DijkstraAlgorithm.App
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;

    using Dijkstra;
    using DijkstraAlgorithm.Models;
    using DijkstraAlgorithm.App.Visualization;
    using DijkstraAlgorithm.App.Utilities.Messages;

    using DijkstraAlgorithm.Models.Interfaces;
    using static Models.Utilities.ConstantDelimeters;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        struct DataParameter
        {
            public int Process;
            public int Delay;
        }

        private DataParameter inputParameter;

        private void buttonAddTab_Click(object sender, EventArgs e)
        {
            var graph = new Graph();
            var graphPage = new GraphPage(graph);

            string tabName = pageNameTextbox.Text;

            // Validation of tab name - cannot consist only numbers, letters and special symbols are allowed
            if (Regex.IsMatch(tabName, "^[0-9]+$"))
            {
                MessageBox.Show(OutputMessages.InvalidTabName, "Warning");
                pageNameTextbox.ResetText();
                return;
            }

            if (!string.IsNullOrEmpty(tabName))
            {
                graphPage.Text = tabName;
            }

            if (this.TabControl.TabCount < GraphConstants.GRAPH_LIMIT)
            {
                this.TabControl.TabPages.Add(graphPage);

                this.TabControl.SelectedIndex = graphPage.TabControl.TabCount - 1;
            }
            else
            {
                MessageBox.Show(string.Format(OutputMessages.TabLimitWarning, GraphConstants.GRAPH_LIMIT), "Warning");
            }

            pageNameTextbox.ResetText();
            textBoxInitial.ResetText();
            rbDijkstra.Checked = false;
        }

        private void buttonCloseTab_Click(object sender, EventArgs e)
        {
            if (this.TabControl.TabCount != 1)
            {
                this.TabControl.TabPages.RemoveAt(this.TabControl.SelectedIndex);
                this.TabControl.SelectedIndex = this.TabControl.TabCount - 1;
            }
            else
            {
                MessageBox.Show(OutputMessages.TabConstraintWarning, "Warning");
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (!(this.TabControl.TabCount > 1))
            {
                MessageBox.Show(OutputMessages.TabPageNotFound, "Warning");
                textBoxInitial.ResetText();
                rbDijkstra.Checked = false;
                return;
            }

            IGraph invokeGraph = (this.TabControl.TabPages[this.TabControl.SelectedIndex] as GraphPage).InvokeGraph;
            RichTextBox invokeRTB = (this.TabControl.TabPages[this.TabControl.SelectedIndex] as GraphPage).RichTextBoxLogs;

            int startId;

            try
            {
                if (!rbDijkstra.Checked)
                {
                    MessageBox.Show(OutputMessages.AlgorithmDefinedMessage, "Warning");
                    return;
                }

                if (int.TryParse(textBoxInitial.Text, out startId))
                {
                    if (rbDijkstra.Checked)
                    {
                        invokeRTB.Text = string.Empty;
                        var currentGraphPage = this.TabControl.TabPages[this.TabControl.SelectedIndex] as GraphPage;

                        if (!backgroundWorker1.IsBusy)
                        {
                            inputParameter.Delay = 100;
                            inputParameter.Process = 1200;
                            backgroundWorker1.RunWorkerAsync(inputParameter);
                        }

                        Dijkstra.GetShortestPath(invokeGraph, startId - 1, currentGraphPage.PictureBoxGraph);

                        WriteMessages(startId, invokeGraph, invokeRTB);

                        currentGraphPage.TabControl.SelectedIndex = 1;
                    }
                }
                else
                {
                    MessageBox.Show(OutputMessages.InvalidStartVertexId, "Warning");
                    textBoxInitial.ResetText();
                }
            }
            catch (IndexOutOfRangeException iore)
            {
                MessageBox.Show(iore.Message, "Warning");
                textBoxInitial.ResetText();
            }
        }

        private static void WriteMessages(int startId, IGraph invokeGraph, RichTextBox invokeRTB)
        {
            foreach (IVertex vertex in invokeGraph.Vertices)
            {
                if (vertex.Id != startId - 1)
                {
                    if (vertex.MinCost == int.MaxValue || vertex.MinCost == int.MaxValue * -1)
                    {
                        invokeRTB.Text +=
                            String.Format(OutputMessages.InfinityMessage,
                            startId,
                            vertex.Id + 1) +
                            Environment.NewLine;
                    }
                    else
                    {
                        invokeRTB.Text +=
                            String.Format(OutputMessages.DistanceMessage,
                            startId,
                            vertex.Id + 1,
                            vertex.MinCost) +
                            Environment.NewLine;
                    }
                }

                vertex.MinCost = int.MaxValue;
                vertex.Permanent = false;
            }
        }

        // TODO
        private void loadButton_Click(object sender, EventArgs e)
        {

        }

        // TODO
        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int process = ((DataParameter)e.Argument).Process;
            int delay = ((DataParameter)e.Argument).Delay;
            //int index = 1;

            try
            {
                for (int i = 0; i < process; i++)
                {
                    if (!backgroundWorker1.CancellationPending)
                    {
                        //backgroundWorker1.ReportProgress(index++ * 100 / process, string.Format("Process data {0}", i));
                        Thread.Sleep(delay);

                        // TODO                   
                    }
                }
            }
            catch (Exception ex)
            {
                backgroundWorker1.CancelAsync();
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Algorithm has finished execution.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

