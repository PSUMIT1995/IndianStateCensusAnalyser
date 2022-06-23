using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusData> dataMap;
        public Dictionary<string, CensusData> LoadCensusData(string csvFilePath, string dataHeader)
        {
            dataMap = new Dictionary<string, CensusData>();
            censusData = GetCensusData(csvFilePath, dataHeader);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                    throw new CensusAnalyserException("File contains invalid Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                string[] column = data.Split(',');
                if (csvFilePath.Contains("IndianStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusData(new CensusDataDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndianStateCode.csv"))
                    dataMap.Add(column[1], new CensusData(new StateCodeDataDAO(column[0], column[1], column[2], column[3])));
            }

            return dataMap;
        }
    }
}
