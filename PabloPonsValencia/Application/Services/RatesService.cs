using Application.DtoAdapters;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RatesService : IRatesService
    {
        private readonly IRepository<Rates> _ratesRepository;
        private readonly ILogger _logger;

        public RatesService(IRepository<Rates> ratesRepository, ILogger<RatesService> logger)
        {
            _ratesRepository = ratesRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<RatesDTO>> GetAsync()
        {
            var rates = await _ratesRepository.GetAsync().ConfigureAwait(false);

            return rates.ToDTO();
        }
    }
}
