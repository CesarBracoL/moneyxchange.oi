using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.MoneyXChange.Entities;
using WebAPI.MoneyXChange.Models;
using WebAPI.MoneyXChange.Services.Contracts;

namespace WebAPI.MoneyXChange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, StoreDBContext dbcontext)
        {
            _authService = authService;
        }

        [HttpPost("token")]
        public IActionResult Token([FromBody]UserData data)
        {
            if(_authService.ValidateLogin(data.Username,data.Password))
            {
                var date = DateTime.UtcNow;
                var expireDate = TimeSpan.FromMinutes(15);
                var expireDateTime = date.Add(expireDate);

                var token = _authService.GenerateToken(date, data.Username, expireDate);

                return Ok(new
                {
                    name = data.Username,
                    email = data.Username,
                    accesstoken = token,
                    expireInt = expireDateTime  
                }
                );
            }
            else
            {
                return StatusCode(401);
            }
        }


    }
}