using Application.DtoAdapters;
using Domain.Entities;
using Domain.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Application.UnitTest
{
    public class RatesAdapterTest
    {
        [Fact]
        public void ToDTO()
        {
            //Arrange
            Rates rate = MockRates.GetRate();

            //Act
            var rateDto = rate.ToDTO();

            //Assert
            Assert.Equal(expected: rate.From, actual: rateDto.From);
            Assert.Equal(expected: rate.To, actual: rateDto.To);
            Assert.Equal(expected: rate.Rate, actual: rateDto.Rate);
        }

        [Fact]
        public void EnumerableToDTO()
        {
            //Arrange
            IEnumerable<Rates> rates = MockRates.GetRates();

            //Act
            var ratesDto = rates.ToDTO();

            //Assert
            Assert.Equal(expected: rates.Count(), actual: ratesDto.Count());
        }
    }
}
