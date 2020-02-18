using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.MoneyXChange.Models;

namespace WebAPI.MoneyXChange.Services.Contracts
{
    public interface IOperationService
    {
        Task<CurrencyRate> FindCurrencyRate(DateTime date, int currencyFrom, int currencyTo);
        double ExchangeCurrency(DateTime date, int currencyFrom, int currencyTo, double currencyValue);

    }
}
