using GEM.PowerPlant.Api.Models;
using System;
using Xunit;

namespace GEM.PowerPlant.Api.Tests
{
    public class GasFiredTests
    {
        [Fact]
        public void ComputeTheMegaWattCostPerHour_WhenNew_ShouldReturnZero()
        {
            // Arrange - Act
            var sut = new GasFired();

            // Assert
            Assert.True(float.IsNaN(sut.MegaWattCostPerHour));
        }

        [Theory]
        [InlineData(13.4f, 20f, 1f, 19.40f)]
        [InlineData(13.4f, 20f, 0.5f, 32.80f)]
        [InlineData(13.4f, 20f, 0.3f, 50.67f)]
        public void ComputeTheMegaWattCostPerHour_WhenLoading_ShouldReturnTheApropriateValue(float euroMWh, float co2, float efficiency, float expectedValue)
        {
            // Arrange - Act
            var sut = new GasFired()
            {
                CO2 = co2,
                Efficiency = efficiency,
                Fuel = new EnergySource()
                {
                    EuroPerMHh = euroMWh,
                }
            };

            // Assert
            Assert.Equal(Math.Round(expectedValue, 2), Math.Round(sut.MegaWattCostPerHour, 2));
        }
    }
}
