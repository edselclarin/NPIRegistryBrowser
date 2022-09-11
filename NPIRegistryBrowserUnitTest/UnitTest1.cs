using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPIRegistryBrowserUnitTest.Models;
using NPIRegistryBrowserUnitTest.Query;

namespace NPIRegistryBrowserUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LookupCity()
        {
            var qry = new CityQuery("Irvine", "CA");
            var results = qry.Search();
            results.DumpToDebugOutput();
        }

        [TestMethod]
        public void LookupDoctor()
        {
            var qry = new DoctorQuery("diana", "albay", "1477751691");
            var results = qry.Search();
            results.DumpToDebugOutput();
        }

        [TestMethod]
        public void LookupZipCode()
        {
            var qry = new ZipCodeQuery("10001");
            var results = qry.Search();
            results.DumpToDebugOutput();
        }
    }
}
