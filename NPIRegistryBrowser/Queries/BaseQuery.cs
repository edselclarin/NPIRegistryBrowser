using Flurl;
using NPIRegistryBrowser.Models;

namespace NPIRegistryBrowser.Queries
{
    public abstract class BaseQuery
    {
        private static string _baseurl = "https://npiregistry.cms.hhs.gov/api";

        public static Url BaseUrl => _baseurl;

        public abstract SearchResultsModel Search();
    }
}
