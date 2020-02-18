using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.MoneyXChange.Services;
using WebAPI.MoneyXChange.Services.Contracts;

namespace WebAPI.MoneyXChange.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IOperationService, OperationService>();

            return services;
        }
    }
}
