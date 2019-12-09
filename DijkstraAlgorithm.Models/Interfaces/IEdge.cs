namespace DijkstraAlgorithm.Models.Interfaces
{
    public interface IEdge
    {
        IVertex FirstVertex { get; }

        IVertex SecondVertex { get; }

        IVertex this[int index] { get; }

        int Weight { get; set; }
    }
}
