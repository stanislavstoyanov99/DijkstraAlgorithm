namespace DijkstraAlgorithm.App
{
    using System;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;

    using Dijkstra;
    using DijkstraAlgorithm.Models;
    using DijkstraAlgorithm.Models.Interfaces;

    using static DijkstraAlgorithm.Models.Utilities.ConstantDelimeters;

    using DijkstraAlgorithm.App.Visualization;

    using static App.Utilities.ConstantDelimeters;

    using DijkstraAlgorithm.App.Utilities.Messages;
    using DijkstraAlgorithm.InputOutput.Interfaces;

    public partial class MainForm : Form
    {
        private int currentStep;
        private bool isFinished;

        private RichTextBox invokeRTB;
        private IGraph invokeGraph;

        private IImporter importer;
        private IExporter exporter;

        public MainForm(IImporter importer, IExporter exporter)
        {
            InitializeComponent();

            this.currentStep = MainFormConstants.DEFAULT_CURRENT_STEP;
            this.isFinished = MainFormConstants.DEFAULT_IS_FINISHED;

            this.importer = importer;
            this.exporter = exporter;
        }

        private void ButtonAddTab_Click(object sender, EventArgs e)
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

        private void ButtonCloseTab_Click(object sender, EventArgs e)
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

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (!(this.TabControl.TabCount > 1))
            {
                MessageBox.Show(OutputMessages.TabPageNotFound, "Warning");
                textBoxInitial.ResetText();
                rbDijkstra.Checked = false;

                return;
            }

            this.invokeGraph = (this.TabControl.TabPages[this.TabControl.SelectedIndex] as GraphPage).InvokeGraph;
            this.invokeRTB = (this.TabControl.TabPages[this.TabControl.SelectedIndex] as GraphPage).RichTextBoxLogs;

            try
            {
                if (!rbDijkstra.Checked)
                {
                    MessageBox.Show(OutputMessages.AlgorithmDefinedMessage, "Warning");
                    return;
                }

                if (int.TryParse(textBoxInitial.Text, out int startId))
                {
                    if (rbDijkstra.Checked)
                    {
                        var currentGraphPage = this.TabControl.TabPages[this.TabControl.SelectedIndex] as GraphPage;
                        var dijkstra = new Dijkstra(invokeGraph, startId - 1);

                        if (!this.isFinished)
                        {
                            this.currentStep++;

                            if (this.currentStep == 1)
                            {
                                dijkstra.FirstStep(currentGraphPage.PictureBoxGraph);
                            }
                            else if (this.currentStep == 2)
                            {
                                dijkstra.SecondStep(currentGraphPage.PictureBoxGraph, startId, invokeRTB);
                            }
                            else if (this.currentStep == 3)
                            {
                                bool result = dijkstra.IsFinished(currentGraphPage.PictureBoxGraph);

                                if (result == true)
                                {
                                    this.isFinished = true;
                                }
                                else
                                {
                                    this.currentStep = 1;
                                }
                            }
                        }

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

        // Open a file dialog window and then import the graph from the specified path using importer.
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = $"{Environment.CurrentDirectory}",
                Filter = "Json files (*.json)|*.json"
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                this.invokeGraph = this.importer.Import(path);

                var graphPage = new GraphPage(this.invokeGraph);

                this.PictureBoxGraph.Invalidate();
                this.TapPageMatrix.Invalidate();
            }

            openFileDialog.Dispose();
        }

        // Open a save file dialog window and then export the graph using the exporter to the specified path. 
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = $"{Environment.CurrentDirectory}",
                Filter = "Json files (*.json)|*.json"
            };

            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                this.exporter.Export(this.invokeGraph, path);
            }

            saveFileDialog.Dispose();
            MessageBox.Show(OutputMessages.SuccessfullySavedGraph,
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}

