using Domain.Algorithms.Adapters;
using Domain.Algorithms.Data;
using Domain.Algorithms.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TransactionBusinessService : ITransactionBusinessService
    {
        private readonly IGraphSolver _graphSolver;
        private readonly IAmountService _amountService;
        private readonly ILogger _logger;

        public TransactionBusinessService(IGraphSolver graphSolver, IAmountService amountService, ILogger<TransactionBusinessService> logger)
        {
            _graphSolver = graphSolver;
            _amountService = amountService;
            _logger = logger;
        }

        public IEnumerable<Transactions> ExchangeToCurrency(IEnumerable<Transactions> transactions, IEnumerable<Rates> rates, string currency)
        {
            var graph = rates.ToGraph();
            var ratesDict = _graphSolver.GetWeightsToNodeOnBreadthFirstSearch(graph, currency);

            var transactionsList = transactions.ToList();
            try
            {
                foreach (var transaction in transactionsList)
                {
                    transaction.Amount = _amountService.CalculateTotalRateRounding(transaction.Amount, ratesDict[transaction.Currency], 2, MidpointRounding.ToEven);
                    transaction.Currency = currency;
                }
            }
            catch (Exception err)
            {
                _logger?.LogError("No es posible realizar el cambio de moneda: " + err.Message);

                throw err.InnerException;
            }


            return transactionsList;
        }

        public decimal GetTotalAmount(IEnumerable<Transactions> transactions)
        {
            decimal totalAmount = 0;

            var transactionsList = transactions.ToList();
            foreach (var transaction in transactionsList)
            {
                totalAmount += transaction.Amount;
            }

            return totalAmount;
        }
    }
}
