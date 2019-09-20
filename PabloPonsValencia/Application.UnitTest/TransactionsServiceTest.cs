using Application.Services;
using Domain.Algorithms.Services;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Domain.UnitTest;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest
{
    public class TransactionsServiceTest
    {
        [Fact]
        public async Task GetAsync()
        {
            //Arrange
            IEnumerable<Transactions> transactions = MockTransactions.GetTransactions();
            var mockTransactionsRepository = new Mock<IRepository<Transactions>>();
            mockTransactionsRepository.Setup(p => p.GetAsync()).Returns(Task.FromResult(transactions));

            IEnumerable<Rates> rates = MockRates.GetRates();
            var mockRatesRepository = new Mock<IRepository<Rates>>();
            mockRatesRepository.Setup(p => p.GetAsync()).Returns(Task.FromResult(rates));

            GraphSolver graphSolver = new GraphSolver();
            AmountService amountService = new AmountService();
            TransactionBusinessService transactionBusinessService = new TransactionBusinessService(graphSolver, amountService, null);
            TransactionFilterService transactionFilterService = new TransactionFilterService(null);

            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddInMemoryCollection(new Dictionary<string,string>{{ "Currency", "EUR" }});
            IConfiguration config = configBuilder.Build();

            TransactionsService transactionsService = new TransactionsService(mockTransactionsRepository.Object, mockRatesRepository.Object, transactionFilterService, transactionBusinessService, null, config);

            //Act
            var transactionsDTOs = await transactionsService.GetAsync().ConfigureAwait(false);

            //Assert
            Assert.NotNull(null);
        }

        [Fact]
        public async Task GetTotalTransactionAsync()
        {
            //Arrange
            IEnumerable<Transactions> transactions = MockTransactions.GetTransactions();
            var mockTransactionsRepository = new Mock<IRepository<Transactions>>();
            mockTransactionsRepository.Setup(p => p.GetAsync()).Returns(Task.FromResult(transactions));

            IEnumerable<Rates> rates = MockRates.GetRates();
            var mockRatesRepository = new Mock<IRepository<Rates>>();
            mockRatesRepository.Setup(p => p.GetAsync()).Returns(Task.FromResult(rates));

            GraphSolver graphSolver = new GraphSolver();
            AmountService amountService = new AmountService();
            TransactionBusinessService transactionBusinessService = new TransactionBusinessService(graphSolver, amountService, null);
            TransactionFilterService transactionFilterService = new TransactionFilterService(null);

            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddInMemoryCollection(new Dictionary<string, string> { { "Currency", "EUR" } });
            IConfiguration config = configBuilder.Build();

            TransactionsService transactionsService = new TransactionsService(mockTransactionsRepository.Object, mockRatesRepository.Object, transactionFilterService, transactionBusinessService, null, config);

            //Act
            var totalTransactionDTO = await transactionsService.GetTotalTransactionAsync("A0000").ConfigureAwait(false);

            //Assert
            Assert.NotNull(null);
        }
    }
}
