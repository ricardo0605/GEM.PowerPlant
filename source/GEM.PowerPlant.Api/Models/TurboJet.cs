namespace GEM.PowerPlant.Api.Models
{
    public class TurboJet : Multitude
    {
        public TurboJet()
        {
            Fuel = new EnergySource();
        }

        public EnergySource Fuel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override float ComputeTheMegaWattCostPerHour()
        {
            if (Fuel.EuroPerMHh == default)
                return base.ComputeTheMegaWattCostPerHour();

            return Fuel.EuroPerMHh * 1 / Efficiency;
        }
    }
}
