using Flurl;
using NPIRegistryBrowserUnitTest.Models;

namespace NPIRegistryBrowserUnitTest.Query
{
    public abstract class BaseQuery
    {
        private static string _baseurl = "https://npiregistry.cms.hhs.gov/api";

        public static Url BaseUrl => _baseurl;

        public abstract SearchResults Search();
    }
}
