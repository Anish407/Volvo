using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Calculators.Implementation.TaxCalculator
{
    // choose composition over inheritance
    public abstract class CongestionTaxCalculatorBase
    {
        protected bool IsTollFreeVehicle(string vehicleType, ICollection<string> tollFreeVehicles)
        {
            if (string.IsNullOrWhiteSpace(vehicleType)) return false;

            return tollFreeVehicles.Contains(vehicleType);
        }

        protected bool IsTollFreeDate(DateTime date, ICollection<Holidays> tollFreeDates)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            foreach (var tollFreeDate in tollFreeDates)
            {
                if (tollFreeDate.Month == month && tollFreeDate.Days.Contains(day)) return true;
            }
            return false;
        }

        protected int GetTollFee(DateTime date,
                                string vehicle,
                                ICollection<string> tollFreeVehicles,
                                ICollection<Holidays> tollFreeDates,
                                ICollection<TaxRates> taxRates)
        {
            if (IsTollFreeDate(date, tollFreeDates) || IsTollFreeVehicle(vehicle, tollFreeVehicles)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;

            return GetTaxRate(taxRates, hour, minute);
        }

        private static int GetTaxRate(ICollection<TaxRates> taxRates, int hour, int minute)
        {
            foreach (var taxRate in taxRates)
            {
                if (taxRate.TimeFrom.Hour >= hour && taxRate.TimeFrom.Minutes <= minute 
                    && taxRate.TimeTo.Hour >= hour && minute <= taxRate.TimeTo.Minutes)
                {
                    return taxRate.Amount;
                }
            }

            return 0;
        }
    }
}
