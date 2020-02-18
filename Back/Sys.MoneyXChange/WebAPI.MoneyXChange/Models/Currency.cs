using System;
using System.Collections.Generic;

namespace WebAPI.MoneyXChange.Models
{
    public partial class Currency
    {
        public Currency()
        {
            CurrencyRateCrrCurrencyFromNavigation = new HashSet<CurrencyRate>();
            CurrencyRateCrrCurrencyToNavigation = new HashSet<CurrencyRate>();
        }

        public int CurId { get; set; }
        public string CurSimbol { get; set; }
        public string CurDescription { get; set; }
        public bool CurIslocal { get; set; }
        public double CurRelation { get; set; }
        public bool CurStatus { get; set; }

        public ICollection<CurrencyRate> CurrencyRateCrrCurrencyFromNavigation { get; set; }
        public ICollection<CurrencyRate> CurrencyRateCrrCurrencyToNavigation { get; set; }
    }
}
