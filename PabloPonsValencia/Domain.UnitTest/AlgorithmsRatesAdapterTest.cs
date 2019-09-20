using Domain.Algorithms.Adapters;
using Domain.Algorithms.Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.UnitTest
{
    public class AlgorithmsRatesAdapterTest
    {
        [Fact]
        public void ToGraph()
        {
            //Arrange
            IEnumerable<Rates> rates = MockRates.GetRates();

            //Act
            Graph ratesGraph = rates.ToGraph();

            //Assert
            Assert.Equal(expected: (decimal)1.89, actual: ratesGraph.Nodes["EUR"].GetWeight("USD"));
            Assert.Equal(expected: (decimal)0.53, actual: ratesGraph.Nodes["USD"].GetWeight("EUR"));
            Assert.Equal(expected: (decimal)0.81, actual: ratesGraph.Nodes["AUD"].GetWeight("USD"));
            Assert.Equal(expected: (decimal)1.23, actual: ratesGraph.Nodes["USD"].GetWeight("AUD"));
            Assert.Equal(expected: (decimal)0.71, actual: ratesGraph.Nodes["AUD"].GetWeight("CAD"));
            Assert.Equal(expected: (decimal)1.41, actual: ratesGraph.Nodes["CAD"].GetWeight("AUD"));
        }
    }
}
