using System;
using TaxCalculator.Core.Calculators.Interface.TaxCalculator;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Handlers.Interface;
using TaxCalculator.Core.Repositories.City;
using TaxCalculator.Core.Response.CongestionTaxCalculator;

namespace TaxCalculator.Core.Handlers.Implementation
{
    public class CongestionTaxCalculatorHandler : ICongestionTaxCalculatorHandler
    {

        public CongestionTaxCalculatorHandler(Func<string, ICongestionTaxCalculator> calculatorFactory)
        {
            TaxCalculatorFactory = calculatorFactory;
        }

        private Func<string, ICongestionTaxCalculator> TaxCalculatorFactory { get; }

        public async Task<CongestionTaxResponse> CalculateTax(CongestionTaxCalculatorRequest congestionTaxCalculatorRequest)
        {
            // Add: fluent validation
            var taxAmountByDates = await TaxCalculatorFactory(congestionTaxCalculatorRequest.City)
                                        .GetCongestionTax(congestionTaxCalculatorRequest);

            return new CongestionTaxResponse
            {
                City = congestionTaxCalculatorRequest.City,
                Vehicle = congestionTaxCalculatorRequest.Vehicle,
                TotalTaxPayable = taxAmountByDates.Values.Sum(),
                TaxDetails = taxAmountByDates.Select(i => new TaxData { Day = i.Key, TaxPayable = i.Value })
            };
        }
    }
}
