namespace GEM.PowerPlant.Api.Models
{
    public class GasFired : Multitude
    {
        public GasFired()
        {
            Fuel = new EnergySource();
        }

        public EnergySource Fuel { get; set; }
        public float CO2 { get; set; }

        /// <summary>
        /// Taken into account that a gas-fired powerplant also emits CO2, 
        /// the cost of running the powerplant should also take into account the cost of the emission allowances. 
        /// For this challenge, you may take into account that each MWh generated creates 0.3 ton of CO2.
        /// </summary>
        /// <returns>How much does it cost to produce a MHh</returns>
        protected override float ComputeTheMegaWattCostPerHour()
        {
            if (Fuel.EuroPerMHh == default)
                return base.ComputeTheMegaWattCostPerHour();

            return Fuel.EuroPerMHh * 1 / Efficiency;
            //return ((Fuel.EuroPerMHh * 1 / Efficiency) + (Fuel.EuroPerMHh * 0.3f));

        }
    }
}
