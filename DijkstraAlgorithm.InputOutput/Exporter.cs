namespace DijkstraAlgorithm.InputOutput
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using DijkstraAlgorithm.InputOutput.Dtos;
    using DijkstraAlgorithm.Models.Interfaces;
    using DijkstraAlgorithm.InputOutput.Interfaces;

    public class Exporter : IExporter
    {
        private IGraph graph;

        public void Export(IGraph graph, string path)
        {
            this.graph = graph;

            GraphDto graphDto = GetDto();

            Export(graphDto, path);
        }

        // Using a JSON.NET library to export the GraphDto object to a json file at a specified path
        private void Export(GraphDto graphDto, string path)
        {
            string jsonExport = JsonConvert.SerializeObject(graphDto, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            File.WriteAllText(path, jsonExport);
        }

        private GraphDto GetDto()
        {
            return new GraphDto
            {
                Vertices = this.graph.Vertices
                    .Select(v => new VertexDto
                    {
                        Id = v.Id,
                        X = v.X,
                        Y = v.Y,
                        Center = v.Center,
                        SourceId = v.SourceId,
                        MinCost = v.MinCost
                    })
                    .ToList(),
                Edges = this.graph.Edges
                    .Select(e => new EdgeDto
                    {
                        Weight = e.Weight,
                        FirstVertexId = e.FirstVertex.Id + 1,
                        SecondVertexId = e.SecondVertex.Id + 1
                    })
                    .ToList()
            };
        }
    }
}
