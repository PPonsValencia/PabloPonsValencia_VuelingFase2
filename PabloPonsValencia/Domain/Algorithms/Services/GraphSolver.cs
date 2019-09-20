using Domain.Algorithms.Data;
using Domain.Algorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Algorithms.Services
{
    public class GraphSolver : IGraphSolver
    {
        public Dictionary<string, IEnumerable<decimal>> GetWeightsToNodeOnBreadthFirstSearch(Graph graph, string id)
        {
            Dictionary<string, IEnumerable<decimal>> ratesToDestinyDict = new Dictionary<string, IEnumerable<decimal>>();

            LinkedList<decimal> weightsList;

            weightsList = new LinkedList<decimal>();
            ratesToDestinyDict.Add(id, weightsList);

            Node node = graph.Nodes[id];
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(node);
            while (nodes.Count > 0)
            {
                Node expandNode = nodes.Dequeue();

                foreach(var toNode in expandNode.ToNodes)
                {
                    if (!ratesToDestinyDict.ContainsKey(toNode.Id))
                    {
                        weightsList = new LinkedList<decimal>(ratesToDestinyDict[expandNode.Id]);
                        weightsList.AddFirst(toNode.GetWeight(expandNode.Id));
                        ratesToDestinyDict.Add(toNode.Id, weightsList);
                        nodes.Enqueue(toNode);
                    }
                }

            }

            return ratesToDestinyDict;
        }
    }
}
