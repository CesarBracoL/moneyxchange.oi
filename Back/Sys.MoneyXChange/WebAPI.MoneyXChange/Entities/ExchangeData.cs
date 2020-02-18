using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.MoneyXChange.Entities
{
    public class ExchangeData
    {
        public DateTime date { get; set; }
        public int currencyFrom { get; set; }
        public int currencyTo { get; set; }
        public double currencyValue { get; set; }
        public double currencyValueTo { get; set; }
    }
}
