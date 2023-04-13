using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Core.Repositories.City;
using TaxCalculator.Infra.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterInfra(this IServiceCollection services)
        {
            return services
                .AddScoped<ICityRepository, CityRepository>();
        }
    }
}
