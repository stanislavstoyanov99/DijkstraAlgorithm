namespace DijkstraAlgorithm.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using DijkstraAlgorithm.Models;
    using DijkstraAlgorithm.App.Visualization;
    using DijkstraAlgorithm.App.Utilities.Messages;

    using static Models.Utilities.ConstantDelimeters;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddTab_Click(object sender, EventArgs e)
        {
            var graph = new Graph();
            var graphPage = new GraphPage(graph, "New Tab");

            if (this.TabControl.TabCount < GraphConstants.GRAPH_LIMIT)
            {
                this.TabControl.TabPages.Add(graphPage);

                this.TabControl.SelectedIndex = graphPage.TabControl.TabCount - 1;
            }
            else
            {
                MessageBox.Show(string.Format(OutputMessages.TabLimitWarning, GraphConstants.GRAPH_LIMIT), "Warning");
            }
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

        // TODO
        private void buttonRun_Click(object sender, EventArgs e)
        {

        }
    }
}

