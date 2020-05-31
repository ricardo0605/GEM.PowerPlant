using AutoMapper;
using GEM.PowerPlant.Api.Dtos;
using GEM.PowerPlant.Api.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace GEM.PowerPlant.Api.Services
{
    public class MultitudeService : IMultitudeService
    {
        private readonly ILogger<MultitudeService> logger;
        private readonly IMapper mapper;

        public MultitudeService(ILogger<MultitudeService> logger,
            IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }

        public IEnumerable<ResponseDetail> SolveUnitCommitment(RequestPayload payload)
        {
            float loadNeeded = payload.Load;
            var multitudes = new List<Multitude>();

            foreach (var item in payload.PowerPlants)
            {
                switch (item.Type)
                {
                    case "gasfired":
                        AddGasFired(payload.Fuels, multitudes, item);
                        break;
                    case "turbojet":
                        AddTurboJet(payload.Fuels, multitudes, item);
                        break;
                    case "windturbine":
                        AddWindTurbine(payload.Fuels, multitudes, item);
                        break;
                    default:
                        logger.LogError($"Power plant { item.Type } not identified.");
                        break;
                }
            }

            multitudes = multitudes.OrderBy(m => m.MegaWattCostPerHour).ThenByDescending(m => m.Pmax).ToList();

            var arr = multitudes.ToArray();
            var nextPmin = 0.0f;

            for (int i = 0; i < arr.Length; i++)
            {
                if (loadNeeded > 0)
                {
                    if (loadNeeded >= arr[i].Power)
                    {
                        if (arr[i + 1].Pmin > (loadNeeded - arr[i].Power))
                            nextPmin = loadNeeded - arr[i + 1].Pmin;
                        else
                            nextPmin = arr[i].Power;

                        loadNeeded -= nextPmin;
                        arr[i].Power = nextPmin;
                    }
                    else
                    {
                        if (loadNeeded >= arr[i].Pmin && loadNeeded <= arr[i].Power)
                        {
                            arr[i].Power = loadNeeded;
                            loadNeeded -= loadNeeded;
                        }
                    }
                }
                else
                {
                    arr[i].Power = default;
                }
            }

            return mapper.Map<IEnumerable<ResponseDetail>>(multitudes);
        }

        private static void AddGasFired(Fuels fuels, List<Multitude> multitudes, Dtos.PowerPlant item)
        {
            multitudes.Add(new GasFired()
            {
                CO2 = fuels.CO2EuroTon,
                Efficiency = item.Efficiency,
                Fuel = new EnergySource()
                {
                    EuroPerMHh = fuels.GasEuroMWh,
                    Name = "gas"
                },
                Name = item.Name,
                Pmax = item.Pmax,
                Pmin = item.Pmin,
                Power = item.Pmax,
                Type = item.Type
            });
        }

        private static void AddTurboJet(Fuels fuels, List<Multitude> multitudes, Dtos.PowerPlant item)
        {
            multitudes.Add(new TurboJet()
            {
                Efficiency = item.Efficiency,
                Fuel = new EnergySource()
                {
                    EuroPerMHh = fuels.GasEuroMWh,
                    Name = "kerosine"
                },
                Name = item.Name,
                Pmax = item.Pmax,
                Pmin = item.Pmin,
                Power = item.Pmax,
                Type = item.Type
            });
        }

        private static void AddWindTurbine(Fuels fuels, List<Multitude> multitudes, Dtos.PowerPlant item)
        {
            multitudes.Add(new WindTurbine()
            {
                Efficiency = item.Efficiency,
                Name = item.Name,
                Pmax = item.Pmax,
                Pmin = item.Pmin,
                Power = item.Pmax,
                Type = item.Type,
                WindAverage = fuels.Wind
            });
        }
    }
}
