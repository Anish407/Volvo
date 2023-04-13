using TaxCalculator.Core.Calculators.Interface.TaxCalculator;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.City;
using TaxCalculator.Core.Response.CongestionTaxCalculator;

namespace TaxCalculator.Core.Calculators.Implementation.TaxCalculator;

public class GothenburgCongestionTaxCalculator : CongestionTaxCalculatorBase, ICongestionTaxCalculator
{
    private ICityRepository CityRepository { get; }

    public GothenburgCongestionTaxCalculator(ICityRepository cityRepository)
    {
        CityRepository = cityRepository;
    }


    public async Task<Dictionary<DateTime, int>> GetCongestionTax(CongestionTaxCalculatorRequest congestionTaxCalculatorRequest)
    {
        City city = await CityRepository.GetItem(congestionTaxCalculatorRequest.City);
        Dictionary<DateTime, int> calculatedTaxDetails = GetCongestionTaxByDates(
                                                            congestionTaxCalculatorRequest.Vehicle,
                                                            congestionTaxCalculatorRequest.TravelDates,
                                                            city.TollFreeVehicles,
                                                            city.TollFreeDates,
                                                            city.TaxRates);
        return calculatedTaxDetails;
    }

    /// <summary>
    ///  Calculate tax for all dates
    /// </summary>
    /// <param name="vehicle"> Type of vehicle</param>
    /// <param name="dates">List of travel dates</param>
    /// <param name="tollFreeVehicles">List of allowed toll free vehicles for the city</param>
    /// <param name="tollFreeDates">List of toll free dates for the city</param>
    /// <param name="taxRates">Tax rates configured for the city</param>
    /// <returns></returns>
    private Dictionary<DateTime, int> GetCongestionTaxByDates(string vehicle,
        ICollection<DateTime> dates,
        ICollection<string> tollFreeVehicles,
        ICollection<Holidays> tollFreeDates,
        ICollection<TaxRates> taxRates)
    {
        Dictionary<DateTime, int> taxByDates = new Dictionary<DateTime, int>();
        DateTime intervalStart = dates.First();
        int tempFee = 0;

        taxByDates.Add(intervalStart.Date, tempFee);

        int perDayTotalFee = 0;

        foreach (DateTime date in dates)
        {
            TimeSpan ts = date - intervalStart;

            // get time difference between last date and current item
            double minutes = ts.TotalMinutes;

            int nextFee = GetTollFee(date, vehicle, tollFreeVehicles, tollFreeDates, taxRates);

            CalculateTax(taxByDates, ref intervalStart, ref tempFee, ref perDayTotalFee, date, minutes, nextFee);
        }

        return taxByDates;
    }

    private void CalculateTax(Dictionary<DateTime, int> perDayTax, 
        ref DateTime intervalStart,
        ref int tempFee, 
        ref int perDayTotalFee,
        DateTime date, 
        double minutes,
        int nextFee)
    {
        if (minutes <= 60)
        {
            // if same day
            if (nextFee >= tempFee)
            {
                perDayTotalFee = perDayTotalFee - tempFee + nextFee;
                tempFee = nextFee;
                CalculatePerDayTax(date, perDayTotalFee, perDayTax);
            }
        }
        else
        {
            // check if different days
            perDayTotalFee = GetTaxIfDifferentDate(intervalStart, perDayTotalFee, date);

            tempFee = nextFee;
            perDayTotalFee = perDayTotalFee + nextFee;
            CalculatePerDayTax(date, perDayTotalFee, perDayTax);
            intervalStart = date;
        }
    }

    private int GetTaxIfDifferentDate(DateTime intervalStart, int perDayTotalFee, DateTime date)
    {
        TimeSpan totalTime = date - intervalStart;
        
        if (totalTime.Days >= 1) perDayTotalFee = 0;
       
        return perDayTotalFee;
    }

    private int CalculatePerDayTax(DateTime currentDate, 
        int total,
        Dictionary<DateTime, int> perDayTax)
    {
        // if per day tax amount is greater than 60
        if (total > 60) total = 60;

        // set total against date
        perDayTax[currentDate.Date] = total;

        return total;
    }
}