namespace DijkstraAlgorithm.App.Interfaces
{
    using System.Windows.Forms;

    using DijkstraAlgorithm.App.Visualization;
    using DijkstraAlgorithm.Models.Interfaces;

    public interface IGraphPage
    {
        CPictureBox PictureBoxGraph { get; }

        PictureBox PictureBoxMatrix { get; }

        TabControl TabControl { get; set; }

        TabPage TabPageMatrix { get; }

        TabPage TapPageLogs { get; }

        RichTextBox RichTextBoxLogs { get; set; }

        IGraph InvokeGraph { get; }
    }
}
