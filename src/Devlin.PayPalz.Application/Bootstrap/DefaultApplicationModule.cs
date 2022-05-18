using Devlin.PayPalz.Application.TaxCalculations.Commands;
using Devlin.PayPalz.Application.TaxCalculationTypeMappings.Queries;
using Devlin.PayPalz.Core.TaxCalculation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Devlin.PayPalz.Application.Bootstrap
{
    public static class DefaultApplicationModule
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITaxCalculationService, TaxCalculationService>();
            services.AddScoped<ITaxCalculationCommand, TaxCalculationCommand>();
            services.AddScoped<ITaxCalculationTypeMappingByIdQuery, TaxCalculationTypeMappingByIdQuery>();
        }
    }
}
