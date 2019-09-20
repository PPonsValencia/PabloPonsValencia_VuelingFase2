using Domain.Algorithms.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.UnitTest
{
    public class AlgorithmsAmountServiceTest
    {
        [Fact]
        public void CalculateTotalRateRounding()
        {
            //Arrange
            IEnumerable<decimal> decimalRates = MockRates.GetDecimalRates();
            AmountService amountService = new AmountService();

            //Act
            var amount = amountService.CalculateTotalRateRounding((decimal) 13.25, decimalRates, 2, MidpointRounding.ToEven);

            //Assert
            Assert.Equal(expected: (decimal)8.02, actual: amount);
        }
    }
}
