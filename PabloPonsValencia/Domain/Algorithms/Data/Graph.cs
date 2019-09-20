using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Algorithms.Data
{
    public class Graph
    {
        public Dictionary<string, Node> Nodes { get; } = new Dictionary<string, Node>();
    }
}
