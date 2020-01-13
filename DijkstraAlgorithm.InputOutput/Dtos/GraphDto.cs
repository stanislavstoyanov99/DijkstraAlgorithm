namespace DijkstraAlgorithm.InputOutput.Dtos
{
    using System.Collections.Generic;

    public class GraphDto
    {
        public List<VertexDto> Vertices { get; set; }

        public List<EdgeDto> Edges { get; set; }
    }
}
