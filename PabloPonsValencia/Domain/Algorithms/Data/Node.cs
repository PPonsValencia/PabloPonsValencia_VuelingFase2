using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Algorithms.Data
{
    public class Node
    {
        public string Id { get; }
        public List<Node> ToNodes = new List<Node>();
        public List<decimal> Weights = new List<decimal>();

        public Node(string id)
        {
            Id = id;
        }

        public void AddEdge(Node node, decimal weight)
        {
            ToNodes.Add(node);
            Weights.Add(weight);
        }

        public decimal GetWeight(string nodeId)
        {
            int pos = ToNodes.IndexOf(ToNodes.Where(x => x.Id == nodeId).FirstOrDefault()) ;

            return Weights.ElementAt(pos);
        }
    }
}
