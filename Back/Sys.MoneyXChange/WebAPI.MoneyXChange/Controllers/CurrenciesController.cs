using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.MoneyXChange.Models;
using WebAPI.MoneyXChange.Services.Contracts;

namespace WebAPI.MoneyXChange.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly StoreDBContext _context;
        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService currencyService,StoreDBContext context)
        {
            _context = context;
            _currencyService = currencyService;
        }

        // GET: api/Currencies
        [HttpGet]
        public IEnumerable<Currency> GetCurrency()
        {
            return _currencyService.GetCurrencies(); //_context.Currency;
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currency = await _currencyService.FindCurrency(id);
                //_context.Currency.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // GET: api/Currencies/5
        [HttpGet("local")]
        public async Task<IActionResult> GetLocalCurrency()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currency = await _currencyService.GetLocalCurrency();

            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

    }
}