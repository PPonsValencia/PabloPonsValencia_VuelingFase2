using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ITransactionBusinessService
    {
        IEnumerable<Transactions> ExchangeToCurrency(IEnumerable<Transactions> transactions, IEnumerable<Rates> rates, string currency);
        decimal GetTotalAmount(IEnumerable<Transactions> transactions);
    }
}
