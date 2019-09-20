using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Transactions
    {
        public int? Id { get; set; }
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
