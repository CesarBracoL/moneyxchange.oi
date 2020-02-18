using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.MoneyXChange.Entities;
using WebAPI.MoneyXChange.Models;
using WebAPI.MoneyXChange.Services.Contracts;

namespace WebAPI.MoneyXChange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly StoreDBContext _context;
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService, StoreDBContext context)
        {
            _context = context;
            _operationService = operationService;
        }

        // GET api/values
        [HttpPost("exchange")]
        public IActionResult Exchange([FromBody] ExchangeData exchangeData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = _operationService.ExchangeCurrency(
                                        exchangeData.date,
                                        exchangeData.currencyFrom,
                                        exchangeData.currencyTo,
                                        exchangeData.currencyValue);



                return Ok(new 
                {
                    date = exchangeData.date,
                    currencyFrom = exchangeData.currencyFrom,
                    currencyTo = exchangeData.currencyTo,
                    currencyValue = exchangeData.currencyValue,
                    currencyValueTo = result
                }           
                );
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        private bool CurrencyRateExists(DateTime id)
        {
            return _context.CurrencyRate.Any(e => e.CrrDateRate == id);
        }
    }
}