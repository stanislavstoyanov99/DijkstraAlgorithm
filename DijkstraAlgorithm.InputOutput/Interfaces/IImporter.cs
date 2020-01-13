namespace DijkstraAlgorithm.InputOutput.Interfaces
{
    using DijkstraAlgorithm.Models.Interfaces;

    public interface IImporter
    {
        IGraph Import(string path);
    }
}
