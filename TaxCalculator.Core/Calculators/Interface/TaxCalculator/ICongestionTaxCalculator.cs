using TaxCalculator.Core.Response.CongestionTaxCalculator;

namespace TaxCalculator.Core.Calculators.Interface.TaxCalculator
{
    public interface ICongestionTaxCalculator
    {
        Task<Dictionary<DateTime, int>> GetCongestionTax(CongestionTaxCalculatorRequest congestionTaxCalculatorRequest);
    }
}
