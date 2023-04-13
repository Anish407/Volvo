using Microsoft.Azure.Cosmos;
using TaxCalculator.Core.Common.Exceptions;

namespace TaxCalculator.Infra.Common.Helpers
{
    public class TryCatchWrapper
    {
        public T TryCatch<T>(Func<T> function, string details = "")
        {
            try
            {
                return function();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default(T);
            }
            catch (CosmosException ex)
            {
                throw new DatabaseException($"Database Cosmos Exception: {ex.Message}", details: ex.ToString());
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Database Exception: {ex.Message}", $"Stacktrace:{ex.StackTrace}, InnerException: {ex.InnerException}");
            }
        }
    }
}
