using GEM.PowerPlant.Api.Models;
using Xunit;

namespace GEM.PowerPlant.Api.Tests
{
    public class WindTurbineTests
    {
        [Fact]
        public void ComputeThePowerCapacity_WhenNew_ShouldReturnZero()
        {
            // Arrange
            var expectedValue = 0;

            // Act
            var sut = new WindTurbine();

            // Assert
            Assert.Equal(expectedValue, sut.Power);
        }

        [Theory]
        [InlineData(25, 4, 1)]
        [InlineData(60, 150, 90)]
        [InlineData(60, 36, 21.6f)]
        public void ComputeThePowerCapacity_WhenLoading_ShouldReturnTheApropriateValue(int windAverage, int pMax, float expectedValue)
        {
            // Arrange - Act
            var sut = new WindTurbine()
            {
                Pmax = pMax,
                WindAverage = windAverage
            };

            // Assert
            Assert.Equal(expectedValue, sut.Power);
        }
    }
}
