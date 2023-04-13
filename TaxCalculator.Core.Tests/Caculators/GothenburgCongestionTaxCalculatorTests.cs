using Moq;
using TaxCalculator.Core.Calculators.Implementation.TaxCalculator;
using TaxCalculator.Core.Response.CongestionTaxCalculator;
using TaxCalculator.Core.Tests.Caculators.Fixtures;

namespace TaxCalculator.Core.Tests.NewFolder
{
    public class GothenburgCongestionTaxCalculatorTests : IClassFixture<CongestionTaxCaculatorFixture>
    {
        public GothenburgCongestionTaxCalculatorTests(CongestionTaxCaculatorFixture congestionTaxCaculatorFixture)
        {
            CongestionTaxCaculatorFixture = congestionTaxCaculatorFixture;
        }

        private CongestionTaxCaculatorFixture CongestionTaxCaculatorFixture { get; }

        [Fact]
        public async Task GetCongestionTax_MultipleTravelDatesInSameHour_ReturnMaximumAmount()
        {
            // Arrange
            int expectedTax = 13;
            int expectedNumberOfTaxes = 1;
            CongestionTaxCalculatorRequest congestionTaxCalculatorRequest = new CongestionTaxCalculatorRequest
            {
                City = "Gothenburg",
                Vehicle = "Bike",
                TravelDates = new List<DateTime>
                 {
                     new DateTime(2013,01,14,06,00,00),
                     new DateTime(2013,01,14,06,30,00)
                 }

            };
            Mock<Repositories.City.ICityRepository> cityRepository = CongestionTaxCaculatorFixture.CityRepository;
            cityRepository.Setup(i => i.GetItem(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(CongestionTaxCaculatorFixture.City);
            GothenburgCongestionTaxCalculator sut = new GothenburgCongestionTaxCalculator(cityRepository.Object);

            //Act
            var result = await sut.GetCongestionTax(congestionTaxCalculatorRequest);

            //Assert
            cityRepository.Verify(i => i.GetItem(congestionTaxCalculatorRequest.City, default), Times.Once);
            Assert.NotNull(result);
            Assert.True(result.Keys.Count == expectedNumberOfTaxes);
            Assert.NotNull(result.FirstOrDefault());
            Assert.True(result.FirstOrDefault().Value == expectedTax);
        }

    }
}
