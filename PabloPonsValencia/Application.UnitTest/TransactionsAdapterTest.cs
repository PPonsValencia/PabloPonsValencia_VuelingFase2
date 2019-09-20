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
    public class TransactionsAdapterTest
    {
        [Fact]
        public void ToDTO()
        {
            //Arrange
            Transactions transaction = MockTransactions.GetTransaction();

            //Act
            var transactionDto = transaction.ToDTO();

            //Assert
            Assert.Equal(expected: transaction.Amount, actual: transactionDto.Amount);
            Assert.Equal(expected: transaction.Currency, actual: transactionDto.Currency);
            Assert.Equal(expected: transaction.Sku, actual: transactionDto.Sku);
        }

        [Fact]
        public void EnumerableToDTO()
        {
            //Arrange
            IEnumerable<Transactions> transactions = MockTransactions.GetTransactions();

            //Act
            var transactionsDto = transactions.ToDTO();

            //Assert
            Assert.Equal(expected: transactions.Count(), actual: transactionsDto.Count());
        }

        [Fact]
        public void ToAmounts()
        {
            //Arrange
            IEnumerable<Transactions> transactions = MockTransactions.GetTransactions();

            //Act
            var amounts = transactions.ToAmounts();

            //Assert
            Assert.Equal(expected: transactions.Count(), actual: amounts.Length);
            for (int i = 0; i < transactions.Count(); i++)
            {
                Assert.Equal(expected: transactions.ElementAt(i).Amount, actual: amounts[i]);
            }
        }
    }
}
