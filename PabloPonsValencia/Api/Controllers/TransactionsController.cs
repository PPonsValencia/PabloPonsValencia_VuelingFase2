using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ILogger _logger;

        public TransactionsController(ITransactionsService transactionsService, ILogger<TransactionsController> logger)
        {
            _transactionsService = transactionsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            IEnumerable<TransactionsDTO> transactions = null;

            try
            {
                transactions = await _transactionsService.GetAsync();

                return JsonConvert.SerializeObject(transactions);
            }
            catch (Exception err)
            {
                _logger?.LogError("Transactions controller exception: " + err.Message);

                return null;
            }
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult<string>> GetBySku(string sku)
        {
            TotalTransactionDTO totalTransaction = null;

            try
            {
                totalTransaction = await _transactionsService.GetTotalTransactionAsync(sku);

                return JsonConvert.SerializeObject(totalTransaction);
            }
            catch (Exception err)
            {
                _logger?.LogError("Transactions controller exception: " + err.Message);

                return null;
            }

        }

    }
}