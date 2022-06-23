using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CensusDataDAO
    {
        //class takes the object for the Indian State census data
        public string State;
        public string Population;
        public string AreaInSqKm;
        public string DensityPerSqKm;

        public CensusDataDAO(string State, string Population, string AreaInSqKm, string DensityPerSqKm)
        {
            this.State = State;
            this.Population = Population;
            this.AreaInSqKm = AreaInSqKm;
            this.DensityPerSqKm = DensityPerSqKm;
        }
    }
}
