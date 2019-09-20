using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Domain.UnitTest
{
    public class TransactionFilterServiceTest
    {
        [Fact]
        public void FilterBySku()
        {
            //Arrange
            TransactionFilterService transactionFilterService = new TransactionFilterService(null);

            IEnumerable<Transactions> transactions = MockTransactions.GetTransactions();

            //Act
            var transactions_A0000 = transactionFilterService.FilterBySku(transactions, "A0000");
            var transactions_B0001 = transactionFilterService.FilterBySku(transactions, "B0001");
            var transactions_D0003 = transactionFilterService.FilterBySku(transactions, "D0003");

            //Assert
            Assert.Equal(expected: 2, actual: transactions_A0000.Count());
            Assert.Single(transactions_B0001);
            Assert.Empty(transactions_D0003);
        }
    }
}
