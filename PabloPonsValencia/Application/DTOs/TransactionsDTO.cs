using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class TransactionsDTO
    {
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    }
}
