using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateCensusAnalyser;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        string stateCensusPath = @"C:\Users\psumi\Batch460\IndianStateCensusAnalyser\IndianStateCensusAnalyserProblem\IndianStateCensusAnalyserProblem\IndianStateCensusData.csv.csv";
        string wrongPath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensus.csv";
        string wrongFileType = @"C:\Users\psumi\Batch460\IndianStateCensusAnalyser\IndianStateCensusAnalyserProblem\IndianStateCensusAnalyserProblem\TextFile1.txt.txt";
        string invalidDelimeter = @"C:\Users\psumi\Batch460\IndianStateCensusAnalyser\IndianStateCensusAnalyserProblem\IndianStateCensusAnalyserProblem\WrongeDelimeter.csv.csv";
        string stateCodePath = @"C:\Users\psumi\Batch460\IndianStateCensusAnalyser\IndianStateCensusAnalyserProblem\IndianStateCensusAnalyserProblem\IndianStateCode.csv.csv";
        string stateCodeInvalidDelimeter = @"C:\Users\psumi\Batch460\IndianStateCensusAnalyser\IndianStateCensusAnalyserProblem\IndianStateCensusAnalyserProblem\StateCodeWrongeDelimeter.csv";

        IndianStateCensusAnalyser.CensusAdapterFactory csv = null;
        CensusAdapter adapter;
        Dictionary<string, CensusData> totalRecord;
        Dictionary<string, CensusData> stateRecord;

        [TestInitialize]
        public void testSetup()
        {
            csv = new CensusAdapterFactory();
            adapter = new CensusAdapter();
            totalRecord = new Dictionary<string, CensusData>();
            stateRecord = new Dictionary<string, CensusData>();
        }

        //TC.1
        //Giving correct path it should return total count of the census list
        [TestCategory("StateCensusAnalyser")]
        [TestMethod]
        public void GivenStateCensusReturnTotalRecord()
        {
            stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            int actual = stateRecord.Count;
            int expected = 36;
            //assertion
            Assert.AreEqual(actual, expected);
        }
        //TC 1.2
        //Given the incorrect path return file not exist
        [TestMethod]
        public void GivenIncorrectPath()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(wrongPath, "State,Population,AreaInSqKm,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("File Not Found", ce.Message);
            }
        }
        //TC 1.3
        //Given the invalid file it returns invalid file type exception
        [TestMethod]
        public void GivenInvalidFile()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(wrongFileType, "State,Population,AreaInSqKm,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Invalid File Type", ce.Message);
            }
        }
        //TC 1.4
        //Given the file with in valid delimeter
        [TestMethod]
        public void GivenInvalidDelimeter()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(invalidDelimeter, "State,Population,AreaInSqKm,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("File contains invalid Delimiter", ce.Message);
            }
        }
        //TC 1.5
        //when passing the incorrect header
        [TestMethod]
        public void GivenIncorrectHeader()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(invalidDelimeter, "State,Population,Area,DensityPerSqKm");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Data header in not matched", ce.Message);
            }
        }
    }
}