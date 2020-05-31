using GEM.PowerPlant.Api.Models;
using Xunit;

namespace GEM.PowerPlant.Api.Tests
{
    public class TurboJetTests
    {
        [Fact]
        public void ComputeTheMegaWattCostPerHour_WhenNew_ShouldReturnZero()
        {
            // Arrange
            var expectedValue = 0;

            // Act
            var sut = new TurboJet();

            // Assert
            Assert.Equal(expectedValue, sut.MegaWattCostPerHour);
        }

        [Theory]
        [InlineData(6, 0.5f, 12)]
        [InlineData(6, 0.53f, 11.320755f)]
        [InlineData(6, 0.37f, 16.216216f)]
        public void ComputeTheMegaWattCostPerHour_WhenLoading_ShouldReturnTheApropriateValue(float euroMWh, float efficiency, float expectedValue)
        {
            // Arrange - Act
            var sut = new TurboJet()
            {
                Efficiency = efficiency,
                Fuel = new EnergySource()
                {
                    EuroPerMHh = euroMWh,
                }
            };

            // Assert
            Assert.Equal(expectedValue, sut.MegaWattCostPerHour);
        }
    }
}
