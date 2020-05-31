using System;

namespace GEM.PowerPlant.Api.Models
{
    public class Multitude
    {
        public Multitude()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Efficiency { get; set; }
        public int Pmin { get; set; }
        public int Pmax { get; set; }
        public virtual float Power { get; set; }
        public float MegaWattCostPerHour
        {
            get { return ComputeTheMegaWattCostPerHour(); }
        }

        protected virtual float ComputeTheMegaWattCostPerHour()
        {
            return default;
        }
    }
}
