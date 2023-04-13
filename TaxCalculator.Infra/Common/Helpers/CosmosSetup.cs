using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace TaxCalculator.Infra.Common.Helpers
{
    public class CosmosSetup 
    {
        public CosmosSetup(
            IConfiguration configuration
            )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

     
        public  CosmosClient SetupCosmosClient()
        {
            // move to constants
            //List<(string, string)>? cotainersList = new List<(string, string)>
            //       {
            //             ("taxdb", "City"),
            //       };
            // using managed Identities        
            //return await CosmosClient.CreateAndInitializeAsync(Configuration["CosmosEndPointUrl"], new DefaultAzureCredential(), cotainersList);
            return new CosmosClient(Configuration.GetConnectionString("taxdb"));

        }
    }
}
