using Domain.Algorithms.Services;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.UnitTest
{
    public class TransactionBusinessServiceTest
    {
        [Fact]
        public void ExchangeToCurrency()
        {
            //Arrange
            GraphSolver graphSolver = new GraphSolver();
            AmountService amountService = new AmountService();
            TransactionBusinessService transactionBusinessService = new TransactionBusinessService(graphSolver, amountService, null);

            IEnumerable<Transactions> transactions = MockTransactions.GetTransactions();
            IEnumerable<Rates> rates = MockRates.GetRates();

            //Act
            var transactionsToCurrency = transactionBusinessService.ExchangeToCurrency(transactions, rates, "EUR");

            //Assert
            Assert.Equal(expected: (decimal)8.02, actual: transactionsToCurrency.ElementAt(0).Amount);
            Assert.Equal(expected: (decimal)5.26, actual: transactionsToCurrency.ElementAt(1).Amount);
            Assert.Equal(expected: (decimal)5.96, actual: transactionsToCurrency.ElementAt(2).Amount);
            Assert.Equal(expected: (decimal)10.25, actual: transactionsToCurrency.ElementAt(3).Amount);
        }

        [Fact]
        public void GetTotalAmount()
        {
            //Arrange
            GraphSolver graphSolver = new GraphSolver();
            AmountService amountService = new AmountService();
            TransactionBusinessService transactionBusinessService = new TransactionBusinessService(graphSolver, amountService, null);

            IEnumerable<Transactions> transactions = MockTransactions.GetTransactions();

            //Act
            var totalAmount = transactionBusinessService.GetTotalAmount(transactions);

            //Assert
            Assert.Equal(expected: (decimal)47.00, actual: totalAmount);
        }
    }
}
