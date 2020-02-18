using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.MoneyXChange.Models;

namespace WebAPI.MoneyXChange.Services.Contracts
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetCurrencies();
        Task<Currency> GetLocalCurrency();
        Task<Currency> FindCurrency(int id);
    }
}
