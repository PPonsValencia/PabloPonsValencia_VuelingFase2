using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Domain.Interfaces
{
    public interface ITransactionFilterService
    {
        IEnumerable<Transactions> FilterBySku(IEnumerable<Transactions> transactions, string sku);
    }
}
