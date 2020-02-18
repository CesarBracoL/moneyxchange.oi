using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.MoneyXChange.Models;
using WebAPI.MoneyXChange.Services.Contracts;

namespace WebAPI.MoneyXChange.Services
{
    public class OperationService : IOperationService
    {
        private StoreDBContext _context;

        public OperationService(StoreDBContext context)
        {
            _context = context;
        }

        public Task<CurrencyRate> FindCurrencyRate(DateTime date, int currencyFrom, int currencyTo)
        {
            var result = _context.CurrencyRate.Where(x => x.CrrDateRate<= date && x.CrrCurrencyFrom == currencyFrom && x.CrrCurrencyTo == currencyTo)
                                        .OrderByDescending(x => x.CrrDateRate)
                                        .FirstOrDefaultAsync();
            return result;
        }


        public double ExchangeCurrency(DateTime date, int currencyFrom, int currencyTo, double currencyValue)
        {
            double resultExchange=0.0;
            var currencyRate = FindCurrencyRate(date, currencyFrom, currencyTo);
            resultExchange = Math.Round(currencyRate.Result.CrrExchangeRate * currencyValue,4);
            return resultExchange;
        }
    }
}
