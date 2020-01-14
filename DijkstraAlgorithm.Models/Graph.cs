﻿namespace DijkstraAlgorithm.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using DijkstraAlgorithm.Models.Interfaces;
    using DijkstraAlgorithm.Models.Utilities.Messages;

    using static Utilities.ConstantDelimeters;

    public class Graph : IGraph
    {
        private readonly List<IVertex> vertices;

        private readonly List<IEdge> edges;

        public Graph()
        {
            this.vertices = new List<IVertex>();
            this.edges = new List<IEdge>();
        }

        public IReadOnlyCollection<IVertex> Vertices => this.vertices.AsReadOnly();

        public IReadOnlyCollection<IEdge> Edges => this.edges.AsReadOnly();

        public IVertex this[int index]
        {
            get
            {
                if (index >= 0 && this.vertices.Count != 0)
                {
                    if (index > this.vertices.Count)
                    {
                        throw new IndexOutOfRangeException(ExceptionMessages.MissingVertexId);
                    }

                    return this.vertices[index];
                }
                else
                {
                    if (this.vertices.Count == 0)
                    {
                        throw new IndexOutOfRangeException(ExceptionMessages.MissingGraph);
                    }

                    throw new IndexOutOfRangeException(ExceptionMessages.InvalidStartVertexId);
                }
            }
        }

        public int VertexCount => this.Vertices.Count;

        public bool AddVertex(IVertex vertex)
        {
            if (this.VertexCount < GraphConstants.VERTEX_LIMIT)
            {
                this.vertices.Add(vertex);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes vertex from graph, then recalculates Ids
        /// </summary>
        public bool RemoveVertex(IVertex vertex)
        {
            if (vertex == null)
            {
                return false;
            }

            bool isRemoved = true;

            var vertexToDelete = this.vertices
                .FirstOrDefault(v => v.Id == vertex.Id);

            if (vertexToDelete == null)
            {
                isRemoved = false;
            }

            this.vertices.Remove(vertexToDelete);

            for (int i = 0; i < this.VertexCount; i++)
            {
                this.vertices[i].Id = i;
            }

            // Removes the connections of the already deleted vertex
            this.Disconnect(vertexToDelete);

            return isRemoved;
        }

        /// <summary>
        /// Removes edge from graph
        /// </summary>
        public bool RemoveEdge(IEdge edge)
        {
            if (edge == null)
            {
                return false;
            }

            bool isRemoved = true;

            var edgeToDelete = this.edges
                .FirstOrDefault(e => e.FirstVertex.Id == edge.FirstVertex.Id &&
                e.SecondVertex.Id == edge.SecondVertex.Id);

            if (edgeToDelete == null)
            {
                isRemoved = false;
            }

            this.edges.Remove(edgeToDelete);

            return isRemoved;
        }

        /// <summary>
        /// Connects two vertices (Creates an Edge (If already exists - increases cost by INITIAL_COST))
        /// </summary>
        public void Connect(IVertex firstVertex, IVertex secondVertex)
        {
            foreach (var edge in this.edges)
            {
                if ((edge[0] == firstVertex && edge[1] == secondVertex) ||
                    edge[0] == secondVertex && edge[1] == firstVertex)
                {
                    edge.Weight += EdgeConstants.INITIAL_WEIGHT;

                    return;
                }
            }

            var edgeToAdd = new Edge(firstVertex, secondVertex);

            this.edges.Add(edgeToAdd);
        }

        /// <summary>
        /// Connects two vertices with their weight, which is taken from outside
        /// </summary>
        public void Connect(IVertex firstVertex, IVertex secondVertex, int weight)
        {
            var edgeToAdd = new Edge(firstVertex, secondVertex, weight);

            if (!this.edges.Contains(edgeToAdd) && edgeToAdd != null)
            {
                this.edges.Add(edgeToAdd);
            }
        }

        /// <summary>
        /// Returns an Edge of two vertices
        /// </summary>
        public IEdge GetEdge(IVertex firstVertex, IVertex secondVertex)
        {
            var edge = this.edges
                .Where(e => e[0] == firstVertex && e[1] == secondVertex ||
                e[0] == secondVertex && e[1] == firstVertex)
                .FirstOrDefault();

            return edge;
        }

        /// <summary>
        /// Returns vertex of whose x and y coordinates match with entered
        /// </summary>
        public IVertex GetVertex(int x, int y)
        {
            var vertex = this.vertices
                .Where(v => v.X == x && v.Y == y)
                .FirstOrDefault();

            return vertex;
        }

        /// <summary>
        /// Returns all vertices whose 'permanent variable' is false
        /// </summary>
        public ICollection<IVertex> NonPermanent()
        {
            var nonPermanentVertices = this.vertices
                .Where(v => v.Permanent == false)
                .ToList();

            return nonPermanentVertices;
        }

        public IVertex GetNonPermanentVertex()
        {
            var nonPernamentVertex = this.vertices
                .FirstOrDefault(v => v.Permanent == false);

            return nonPernamentVertex;
        }

        /// <summary>
        /// Returns all unvisited vertices in a graph
        /// </summary>
        public ICollection<IVertex> NonVisited()
        {
            var nonVisitedVertices = this.vertices
                .Where(v => v.Visited == false)
                .ToList();

            return nonVisitedVertices;
        }

        /// <summary>
        /// Removes all connections from a Vertex
        /// </summary>
        private void Disconnect(IVertex vertex)
        {
            Stack<IEdge> garbage = new Stack<IEdge>();

            foreach (var edge in this.edges)
            {
                if (edge[0] == vertex || edge[1] == vertex)
                {
                    garbage.Push(edge);
                }
            }

            while (garbage.Count != 0)
            {
                this.edges.Remove(garbage.Pop());
            }
        }
    }
}
