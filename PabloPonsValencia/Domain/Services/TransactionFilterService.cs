using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Domain.Services
{
    public class TransactionFilterService : ITransactionFilterService
    {
        private readonly ILogger _logger;

        public TransactionFilterService(ILogger<TransactionFilterService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Transactions> FilterBySku(IEnumerable<Transactions> transactions, string sku)
        {
            return transactions.Where(x => x.Sku == sku).ToList();
        }
    }
}
