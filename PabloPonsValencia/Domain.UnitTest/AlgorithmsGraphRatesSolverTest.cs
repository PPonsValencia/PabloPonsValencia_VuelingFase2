using Domain.Algorithms.Adapters;
using Domain.Algorithms.Data;
using Domain.Algorithms.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Domain.UnitTest
{
    public class AlgorithmsGraphRatesSolverTest
    {
        [Fact]
        public void GetWeightsToNodeOnBreadthFirstSearch()
        {
            //Arrange
            IEnumerable<Rates> rates = MockRates.GetRates();
            Graph ratesGraph = rates.ToGraph();
            GraphSolver graphSolver = new GraphSolver();

            //Act
            var ratesDict = graphSolver.GetWeightsToNodeOnBreadthFirstSearch(ratesGraph, "EUR");

            //Assert
            Assert.Empty(ratesDict["EUR"]);

            Assert.Single(ratesDict["USD"]);
            Assert.Equal(expected: (decimal)0.53, actual: ratesDict["USD"].ElementAt(0));

            Assert.Equal(expected: 2, actual: ratesDict["AUD"].Count());
            Assert.Equal(expected: (decimal)0.81, actual: ratesDict["AUD"].ElementAt(0));
            Assert.Equal(expected: (decimal)0.53, actual: ratesDict["AUD"].ElementAt(1));

            Assert.Equal(expected: 3, actual: ratesDict["CAD"].Count());
            Assert.Equal(expected: (decimal)1.41, actual: ratesDict["CAD"].ElementAt(0));
            Assert.Equal(expected: (decimal)0.81, actual: ratesDict["CAD"].ElementAt(1));
            Assert.Equal(expected: (decimal)0.53, actual: ratesDict["CAD"].ElementAt(2));

        }
    }
}
