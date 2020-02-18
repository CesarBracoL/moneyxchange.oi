using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.MoneyXChange.Models;
using WebAPI.MoneyXChange.Services.Contracts;

namespace WebAPI.MoneyXChange.Services
{
    public class CurrencyService : ICurrencyService
    {
        private StoreDBContext _context;

        public CurrencyService(StoreDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            return _context.Currency;
        }

        public Task<Currency> GetLocalCurrency()
        {
            var result = _context.Currency.Where(x => x.CurIslocal == true)
                                        .FirstOrDefaultAsync();
            return result;
        }

        public Task<Currency> FindCurrency(int id)
        {
            return _context.Currency.FindAsync(id);
        }
    }
}
