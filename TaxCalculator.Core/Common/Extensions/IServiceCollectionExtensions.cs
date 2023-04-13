using TaxCalculator.Core.Calculators.Implementation.TaxCalculator;
using TaxCalculator.Core.Calculators.Interface.TaxCalculator;
using TaxCalculator.Core.Handlers.Implementation;
using TaxCalculator.Core.Handlers.Interface;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCore(this IServiceCollection services)
        {
            services
                .AddScoped<ICongestionTaxCalculatorHandler, CongestionTaxCalculatorHandler>()
                .AddScoped<GothenburgCongestionTaxCalculator>()
                ;

            services.AddScoped<Func<string, ICongestionTaxCalculator>>(svc => city =>
            {
                return city switch
                {
                    "Gothenburg" => svc.GetRequiredService<GothenburgCongestionTaxCalculator>(),
                    //"Stockholm" => svc.GetRequiredService<StockholmCongestionTaxCalculator>(),
                    _=> throw new Exception("Unknown City") 
                };
            });

            return services;
        }
    }
}
