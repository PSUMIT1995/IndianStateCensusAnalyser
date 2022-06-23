using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CensusData
    {
        public string SrNo;
        public string State;
        public string TIN;
        public string StateCode;
        public string Population;
        public string AreaInSqKm;
        public string DensityPerSqKm;
        public double totalArea;
        public double waterLevel;

        public CensusData(StateCodeDataDAO stateCodeData)
        {
            this.SrNo = stateCodeData.SrNo;
            this.State = stateCodeData.State;
            this.TIN = stateCodeData.TIN;
            this.StateCode = stateCodeData.StateCode;
        }

        public CensusData(CensusDataDAO censusDataDAO)
        {
            this.State = censusDataDAO.State;
            this.Population = censusDataDAO.Population;
            this.AreaInSqKm = censusDataDAO.AreaInSqKm;
            this.DensityPerSqKm = censusDataDAO.DensityPerSqKm;
        }

    }
}
