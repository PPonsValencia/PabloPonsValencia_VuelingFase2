using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Algorithms.Interfaces
{
    public interface IAmountService
    {
        decimal CalculateTotalRateRounding(decimal amount, IEnumerable<decimal> rates, int decimals, MidpointRounding midpointRounding);
    }
}
