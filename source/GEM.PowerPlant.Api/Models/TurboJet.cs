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
        /// Compute the price to produce energy.
        /// Note: kerosine(euro/Mwh): the price of kerosine per MWh
        /// </summary>
        /// <returns>How much does it cost to produce a MWh</returns>
        protected override float ComputeTheMegaWattCostPerHour()
        {
            return Fuel.EuroPerMHh * 1 / Efficiency;
        }
    }
}
