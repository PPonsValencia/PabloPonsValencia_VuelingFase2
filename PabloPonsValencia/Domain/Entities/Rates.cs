using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Rates
    {
        public int? Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Rate { get; set; }
    }
}
