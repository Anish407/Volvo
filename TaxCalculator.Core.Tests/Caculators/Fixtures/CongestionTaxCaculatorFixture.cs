using Moq;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.City;
using TaxCalculator.Core.Tests.Caculators.Fakes;

namespace TaxCalculator.Core.Tests.Caculators.Fixtures
{
    public class CongestionTaxCaculatorFixture
    {
        public City City { get; set; }
        public Mock<ICityRepository> CityRepository { get; set; }

        public CongestionTaxCaculatorFixture()
        {
           City= new CityFake().ReturnSingleFakeCity();
           CityRepository = new Mock<ICityRepository>();
        }
    }
}
