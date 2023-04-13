using TaxCalculator.Core.Response.CongestionTaxCalculator;

namespace TaxCalculator.Core.Handlers.Interface
{
    public interface ICongestionTaxCalculatorHandler
    {
        Task<CongestionTaxResponse> CalculateTax(CongestionTaxCalculatorRequest taxCalculatorRequest);
    }
}