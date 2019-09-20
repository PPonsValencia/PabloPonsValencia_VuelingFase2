using Domain.Algorithms.Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Algorithms.Adapters
{
    public static class RatesAdapter
    {
        public static Graph ToGraph(this IEnumerable<Rates> rates)
        {
            Graph graph = new Graph();

            List<Rates> ratesList = rates.ToList();

            foreach (var rate in ratesList)
            {
                if (!graph.Nodes.ContainsKey(rate.From))
                {
                    graph.Nodes.Add(rate.From, new Node(rate.From));
                }
                if (!graph.Nodes.ContainsKey(rate.To))
                {
                    graph.Nodes.Add(rate.To, new Node(rate.To));
                }
                graph.Nodes[rate.From].AddEdge(graph.Nodes[rate.To], rate.Rate);
            }

            return graph;
        }
    }
}
