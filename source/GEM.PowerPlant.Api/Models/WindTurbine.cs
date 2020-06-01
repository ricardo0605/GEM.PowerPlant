namespace GEM.PowerPlant.Api.Models
{
    public class WindTurbine : Multitude
    {
        public int WindAverage { get; set; }
        public override float Power
        {
            get { return ComputeHowMuchEnergyItWillGerenateInOneHour(); }
        }

        //public float Capacity { get { return ComputeHowMuchEnergyItWillGerenateInOneHour(); } }

        /// <summary>
        /// Compute how much energy will be generated.
        /// Example: if there is on average 25% wind during an hour, 
        /// a wind-turbine with a Pmax of 4 MW will generate 1MWh of energy.
        /// </summary>
        /// <returns>How much energy it will generate in one hour.</returns>
        private float ComputeHowMuchEnergyItWillGerenateInOneHour()
        {
            return Pmax * WindAverage / 100f;
        }
    }
}
