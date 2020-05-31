using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GEM.PowerPlant.Api.Dtos
{
    public class RequestPayload
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, int.MaxValue)]
        public int Load { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public Fuels Fuels { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public IList<PowerPlant> PowerPlants { get; set; }
    }

    public class Fuels
    {
        [JsonProperty("gas(euro/MWh)")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(0.00001f, float.MaxValue)]
        public float GasEuroMWh { get; set; }

        [JsonProperty("kerosine(euro/MWh)")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(0.00001f, float.MaxValue)]
        public float KerosineEuroMWh { get; set; }

        [JsonProperty("co2(euro/ton)")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, int.MaxValue)]
        public int CO2EuroTon { get; set; }

        [JsonProperty("wind(%)")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(0, int.MaxValue)]
        public int Wind { get; set; }
    }

    public class PowerPlant
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(0.00001f, float.MaxValue)]
        public float Efficiency { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(0, int.MaxValue)]
        public int Pmin { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, int.MaxValue)]
        public int Pmax { get; set; }
    }
}
