using Domain.Algorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Algorithms.Services
{
    public class AmountService : IAmountService
    {
        public decimal CalculateTotalRateRounding(decimal amount, IEnumerable<decimal> rates, int decimals, MidpointRounding midpointRounding)
        {
            var ratesList = rates.ToList();

            foreach(var rate in ratesList)
            {
                amount = Math.Round(amount*rate, decimals, midpointRounding);
            }

            return amount;
        }
    }
}
