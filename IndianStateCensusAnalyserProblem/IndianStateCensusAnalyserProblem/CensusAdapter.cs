using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndianStateCensusAnalyser
{
    public class CensusAdapter
    {
        public string[] GetCensusData(string csvFilePath, string dataHeader)
        {
            string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeader)
            {
                throw new CensusAnalyserException("Data header in not matched", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }

            return censusData;
        }
    }
}
