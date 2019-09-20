using Domain.Algorithms.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Algorithms.Interfaces
{
    public interface IGraphSolver
    {
        Dictionary<string, IEnumerable<decimal>> GetWeightsToNodeOnBreadthFirstSearch(Graph graph, string currency);
    }
}
