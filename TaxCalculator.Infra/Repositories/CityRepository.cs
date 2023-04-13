using Microsoft.Azure.Cosmos;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.City;

namespace TaxCalculator.Infra.Repositories
{
    public class CityRepository : CosmosRepository<City>, ICityRepository
    {
        public CityRepository(CosmosClient cosmosClient) : base(cosmosClient)
        {
        }

        public override string DatabaseId => "taxdb";

        public override string ContainerId => "City";
    }
}
