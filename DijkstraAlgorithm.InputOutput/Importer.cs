namespace DijkstraAlgorithm.InputOutput
{
    using System.IO;
    using System.Linq;

    using DijkstraAlgorithm.Models;
    using DijkstraAlgorithm.InputOutput.Dtos;
    using DijkstraAlgorithm.Models.Interfaces;
    using DijkstraAlgorithm.InputOutput.Interfaces;

    using Newtonsoft.Json;

    public class Importer : IImporter
    {
        // Import the GraphDto from a json file then get the new graph into the Graph Page
        public IGraph Import(string path)
        {
            GraphDto graphDto = ImportGraphDtoFromJson(path);

            IGraph graph = GetGraphFromDto(graphDto);

            return graph;
        }

        private IGraph GetGraphFromDto(GraphDto graphDto)
        {
            IGraph graph = new Graph();

            foreach (var vertexDto in graphDto.Vertices)
            {
                graph.AddVertex(new Vertex(graphDto.Vertices.Count)
                {
                    Id = vertexDto.Id,
                    X = vertexDto.X,
                    Y = vertexDto.Y,
                    SourceId = vertexDto.SourceId,
                    MinCost = vertexDto.MinCost
                });
            }

            foreach (var edgeDto in graphDto.Edges)
            {
                IVertex firstVertex = graph.Vertices
                    .First(v => v.Id + 1 == edgeDto.FirstVertexId);
                IVertex secondVertex = graph.Vertices
                    .First(v => v.Id + 1 == edgeDto.SecondVertexId);

                graph.Connect(firstVertex, secondVertex, edgeDto.Weight);
            }

            return graph;
        }

        // Using a JSON.NET import the data from a specified json file into a GraphDto object 
        private GraphDto ImportGraphDtoFromJson(string path)
        {
            string file = File.ReadAllText(path);

            GraphDto graphDto = JsonConvert.DeserializeObject<GraphDto>(file);

            return graphDto;
        }
    }
}
