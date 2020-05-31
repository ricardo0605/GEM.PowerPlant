using GEM.PowerPlant.Api.Models;
using Xunit;

namespace GEM.PowerPlant.Api.Tests
{
    public class GasFiredTests
    {
        [Fact]
        public void ComputeTheMegaWattCostPerHour_WhenNew_ShouldReturnZero()
        {
            // Arrange
            var expectedValue = 0;

            // Act
            var sut = new GasFired();

            // Assert
            Assert.Equal(expectedValue, sut.MegaWattCostPerHour);
        }

        [Theory]
        [InlineData(13.4f, 1f, 17.42f)]
        [InlineData(13.4f, 0.5f, 30.82f)]
        [InlineData(13.4f, 0.3f, 48.686665f)]
        public void ComputeTheMegaWattCostPerHour_WhenLoading_ShouldReturnTheApropriateValue(float euroMWh, float efficiency, float expectedValue)
        {
            // Arrange - Act
            var sut = new GasFired()
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
