namespace DijkstraAlgorithm.InputOutput.Interfaces
{
    using DijkstraAlgorithm.Models.Interfaces;

    public interface IExporter
    {
        void Export(IGraph graph, string path);
    }
}
