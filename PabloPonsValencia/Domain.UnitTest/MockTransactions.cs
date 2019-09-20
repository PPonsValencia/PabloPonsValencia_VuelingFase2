using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTest
{
    public static class MockTransactions
    {
        public static Transactions GetTransaction()
        {
            Transactions transaction = new Transactions();
            transaction.Amount = (decimal)13.25;
            transaction.Currency = "CAD";
            transaction.Sku = "A0000";

            return transaction;
        }

        public static IEnumerable<Transactions> GetTransactions()
        {
            List<Transactions> transactionsList = new List<Transactions>();
            Transactions transaction;

            transaction = new Transactions();
            transaction.Amount = (decimal)13.25;
            transaction.Currency = "CAD";
            transaction.Sku = "A0000";
            transactionsList.Add(transaction);

            transaction = new Transactions();
            transaction.Amount = (decimal)12.25;
            transaction.Currency = "AUD";
            transaction.Sku = "A0000";
            transactionsList.Add(transaction);

            transaction = new Transactions();
            transaction.Amount = (decimal)11.25;
            transaction.Currency = "USD";
            transaction.Sku = "B0001";
            transactionsList.Add(transaction);

            transaction = new Transactions();
            transaction.Amount = (decimal)10.25;
            transaction.Currency = "EUR";
            transaction.Sku = "C0002";
            transactionsList.Add(transaction);

            return transactionsList;
        }
    }
}
