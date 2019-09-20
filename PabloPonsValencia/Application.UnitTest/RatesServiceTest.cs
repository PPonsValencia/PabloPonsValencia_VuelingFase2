using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Domain.UnitTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest
{
    public class RatesServiceTest
    {
        [Fact]
        public async Task GetAsync()
        {
            //Arrange
            IEnumerable<Rates> rates = MockRates.GetRates();
            var mockRatesRepository = new Mock<IRepository<Rates>>();
            mockRatesRepository.Setup(p => p.GetAsync()).Returns(Task.FromResult(rates));

            RatesService ratesService = new RatesService(mockRatesRepository.Object, null);

            //Act
            var ratesDTOs = await ratesService.GetAsync().ConfigureAwait(false);

            //Assert
            Assert.Equal(expected: rates.Count(), actual: ratesDTOs.Count());
            for (int i = 0; i < rates.Count(); i++)
            {
                Assert.Equal(expected: rates.ElementAt(i).From, actual: ratesDTOs.ElementAt(i).From);
                Assert.Equal(expected: rates.ElementAt(i).To, actual: ratesDTOs.ElementAt(i).To);
                Assert.Equal(expected: rates.ElementAt(i).Rate, actual: ratesDTOs.ElementAt(i).Rate);
            }
        }
    }
}
