using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class RatesDTO
    {
        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }
        [JsonProperty(PropertyName = "rate")]
        public decimal Rate { get; set; }
    }
}
