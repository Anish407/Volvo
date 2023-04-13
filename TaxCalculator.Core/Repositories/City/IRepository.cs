using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories.City
{
    public interface IRepository<TItem>
          where TItem : IDocument
    {
        ValueTask<TItem> GetItem(string id, CancellationToken cancellationToken = default);
        ValueTask<TItem> Create(TItem value, CancellationToken cancellationToken = default);
    }
}
