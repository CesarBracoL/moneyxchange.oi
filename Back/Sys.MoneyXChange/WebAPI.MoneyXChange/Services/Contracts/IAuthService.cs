﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.MoneyXChange.Services.Contracts
{
    public interface IAuthService
    {
        bool ValidateLogin(string user, string pass);
        string GenerateToken(DateTime date, string user, TimeSpan time);
    }
}
