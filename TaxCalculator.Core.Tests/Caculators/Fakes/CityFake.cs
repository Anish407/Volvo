
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Tests.Caculators.Fakes
{
    public class CityFake
    {
        public City ReturnSingleFakeCity()
        {
            return new City
            {
                Id = "Gothenburg",
                TaxRates = new List<TaxRates>
                {
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 06,
                            Minutes = 00,
                        },
                        TimeTo = new Time
                        {
                            Hour = 06,
                            Minutes = 29,
                        },
                        Amount = 8,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 06,
                            Minutes = 30,
                        },
                        TimeTo = new Time
                        {
                            Hour = 06,
                            Minutes = 59,
                        },
                        Amount = 13,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 07,
                            Minutes = 00,
                        },
                        TimeTo = new Time
                        {
                            Hour = 07,
                            Minutes = 59,
                        },
                        Amount = 18,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 08,
                            Minutes = 00,
                        },
                        TimeTo = new Time
                        {
                            Hour = 08,
                            Minutes = 29,
                        },
                        Amount = 13,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 08,
                            Minutes = 30,
                        },
                        TimeTo = new Time
                        {
                            Hour = 14,
                            Minutes = 59,
                        },
                        Amount = 8,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 15,
                            Minutes = 00,
                        },
                        TimeTo = new Time
                        {
                            Hour = 15,
                            Minutes = 29,
                        },
                        Amount = 13,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 15,
                            Minutes = 30,
                        },
                        TimeTo = new Time
                        {
                            Hour = 16,
                            Minutes = 59,
                        },
                        Amount = 18,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 17,
                            Minutes = 00,
                        },
                        TimeTo = new Time
                        {
                            Hour = 17,
                            Minutes = 59,
                        },
                        Amount = 13,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 18,
                            Minutes = 00,
                        },
                        TimeTo = new Time
                        {
                            Hour = 18,
                            Minutes = 29,
                        },
                        Amount = 8,
                    },
                    new TaxRates
                    {
                        TimeFrom = new Time
                        {
                            Hour = 18,
                            Minutes = 30,
                        },
                        TimeTo = new Time
                        {
                            Hour = 5,
                            Minutes = 59,
                        },
                        Amount = 0,
                    }

                },
                TollFreeDates = new List<Holidays>
                {
                    new Holidays
                    {
                        Month = 1,
                        Days = new int[] { 1 }
                    },
                    new Holidays
                    {
                        Month = 3,
                        Days = new int[] { 28,29 }
                    },
                    new Holidays
                    {
                        Month = 4,
                        Days = new int[] { 1,30 }
                    },
                    new Holidays
                    {
                        Month = 5,
                        Days = new int[] { 1,8,9 }
                    },
                    new Holidays
                    {
                        Month = 6,
                        Days = new int[] { 5,6,21 }
                    },
                    new Holidays
                    {
                        Month = 7,
                    },
                    new Holidays
                    {
                        Month = 11,
                        Days = new int[] { 1 }
                    },
                    new Holidays
                    {
                        Month = 12,
                        Days = new int[] { 24,25,26,31 }
                    }

                },
                TollFreeVehicles = new List<string>
                {
                    "Motorcycle",
                    "Tractor",
                    "Emergency",
                    "Diplomat",
                    "Foreign",
                    "Military",
                }
            };
        }
    }
}
