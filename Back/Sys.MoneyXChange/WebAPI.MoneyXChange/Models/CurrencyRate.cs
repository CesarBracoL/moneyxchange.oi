using System;
using System.Collections.Generic;

namespace WebAPI.MoneyXChange.Models
{
    public partial class CurrencyRate
    {
        public DateTime CrrDateRate { get; set; }
        public int CrrCurrencyFrom { get; set; }
        public int CrrCurrencyTo { get; set; }
        public double CrrExchangeRate { get; set; }

        public Currency CrrCurrencyFromNavigation { get; set; }
        public Currency CrrCurrencyToNavigation { get; set; }
    }
}
