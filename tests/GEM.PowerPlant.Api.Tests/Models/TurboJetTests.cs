﻿using GEM.PowerPlant.Api.Models;
using System;
using Xunit;

namespace GEM.PowerPlant.Api.Tests
{
    public class TurboJetTests
    {
        [Fact]
        public void ComputeTheMegaWattCostPerHour_WhenNew_ShouldReturnZero()
        {
            // Arrange - Act
            var sut = new TurboJet();

            // Assert
            Assert.True(float.IsNaN(sut.MegaWattCostPerHour));
        }

        [Theory]
        [InlineData(6, 0.5f, 12.00f)]
        [InlineData(6, 0.53f, 11.32f)]
        [InlineData(6, 0.37f, 16.22f)]
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
            Assert.Equal(Math.Round(expectedValue, 2), Math.Round(sut.MegaWattCostPerHour, 2));
        }
    }
}
