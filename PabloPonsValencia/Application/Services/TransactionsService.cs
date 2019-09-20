using Application.DtoAdapters;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IRepository<Transactions> _transactionsRepository;
        private readonly IRepository<Rates> _ratesRepository;
        private readonly ITransactionFilterService _transactionFilterService;
        private readonly ITransactionBusinessService _transactionBusinessService;
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        public TransactionsService(IRepository<Transactions> transactionsRepository, IRepository<Rates> ratesRepository, ITransactionFilterService transactionFilterService, ITransactionBusinessService transactionBusinessService, ILogger<TransactionsService> logger, IConfiguration config)
        {
            _transactionsRepository = transactionsRepository;
            _ratesRepository = ratesRepository;
            _transactionFilterService = transactionFilterService;
            _transactionBusinessService = transactionBusinessService;
            _logger = logger;
            _config = config;
        }

        public async Task<IEnumerable<TransactionsDTO>> GetAsync()
        {
            var transactions = await _transactionsRepository.GetAsync().ConfigureAwait(false);

            return transactions.ToDTO();
        }

        public async Task<TotalTransactionDTO> GetTotalTransactionAsync(string sku)
        {
            string currency = _config.GetValue<string>("Currency");
            
            var transactions = await _transactionsRepository.GetAsync().ConfigureAwait(false);
            var rates = await _ratesRepository.GetAsync().ConfigureAwait(false);

            var transactionsBySku = _transactionFilterService.FilterBySku(transactions, sku);
            var transactionsBySkuToCurrency = _transactionBusinessService.ExchangeToCurrency(transactionsBySku, rates, currency);

            TotalTransactionDTO totalTransactionDTO = new TotalTransactionDTO();
            totalTransactionDTO.Sku = sku;
            totalTransactionDTO.Currency = currency;
            totalTransactionDTO.TotalAmount = _transactionBusinessService.GetTotalAmount(transactionsBySkuToCurrency);
            totalTransactionDTO.TransactionsAmount = transactionsBySku.ToAmounts();

            return totalTransactionDTO;
        }

        public static implicit operator TransactionsService(RatesService v)
        {
            throw new NotImplementedException();
        }
    }
}
