using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class TotalTransactionDTO
    {
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }
        [JsonProperty(PropertyName = "totalAmount")]
        public decimal TotalAmount { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "transactionsAmount")]
        public decimal[] TransactionsAmount { get; set; }
    }
}
