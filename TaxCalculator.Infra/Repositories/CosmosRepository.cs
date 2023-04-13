using Microsoft.Azure.Cosmos;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.City;
using TaxCalculator.Infra.Common.Helpers;

namespace TaxCalculator.Infra.Repositories
{
    public abstract class CosmosRepository<TItem> : IRepository<TItem>
         where TItem : IDocument
    {
        public abstract string DatabaseId { get; }

        public abstract string ContainerId { get; }

        private TryCatchWrapper _wrapper = new TryCatchWrapper();

        protected Container Container { get; set; }

        public CosmosRepository(CosmosClient cosmosClient)
        {
            CosmosClient = cosmosClient;
            Container = CosmosClient.GetContainer(DatabaseId, ContainerId);
        }

        public CosmosClient CosmosClient { get; }

        public async ValueTask<TItem> GetItem(string id, CancellationToken cancellationToken = default)
        => await GetItem(id, new PartitionKey(id), cancellationToken);

        public async ValueTask<TItem> GetItem(string id, PartitionKey partitionKey, CancellationToken cancellationToken = default)
        {
            return await _wrapper.TryCatch(
              async () =>
              {
                  if (partitionKey == default)
                  {
                      partitionKey = new PartitionKey(id);
                  }

                  ItemResponse<TItem> response =
                      await Container.ReadItemAsync<TItem>(id, partitionKey, cancellationToken: cancellationToken);

                  TItem item = response.Resource;
                  item.ETag = response.ETag;

                  return item;
              }, string.Format("Id:{0} and partitionKey:{1}", id, partitionKey));
        }

        public async ValueTask<TItem> Create(
           TItem value,
           CancellationToken cancellationToken = default)
        {
            return await _wrapper.TryCatch(async () =>
            {
                ItemResponse<TItem> response =
                 await Container.CreateItemAsync(value, new PartitionKey(value.PartitionKey), cancellationToken: cancellationToken);

                return response.Resource;
            });
        }

    }
}
