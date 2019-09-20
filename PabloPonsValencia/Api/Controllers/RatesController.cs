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
    public class RatesController : ControllerBase
    {
        private readonly IRatesService _ratesService;
        private readonly ILogger _logger;

        public RatesController(IRatesService ratesService, ILogger<RatesController> logger)
        {
            _ratesService = ratesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            IEnumerable<RatesDTO> rates = null;

            try
            {
                rates = await _ratesService.GetAsync();

                return JsonConvert.SerializeObject(rates);
            }
            catch (Exception err)
            {
                _logger?.LogError("Rates controller exception: " + err.Message);

                return null;
            }
        }
    }
}