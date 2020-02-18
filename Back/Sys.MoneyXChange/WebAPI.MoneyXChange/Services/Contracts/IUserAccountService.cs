using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.MoneyXChange.Models;

namespace WebAPI.MoneyXChange.Services.Contracts
{
    public interface IUserAccountService
    {
        bool Authenticate(string username, string password);
    }
}
