using Flurl;
using Flurl.Http;
using NPIRegistryBrowserUnitTest.Models;

namespace NPIRegistryBrowserUnitTest.Query
{
    internal class DoctorQuery : BaseQuery
    {
        private NPISearchParams _params;

        public DoctorQuery(string firstName, string lastName, string npiNumber)
        {
            _params = new NPISearchParams()
            {
                first_name = firstName,
                last_name = lastName,
                number = npiNumber
            };
        }

        public override SearchResults Search()
        {
            return new Url(BaseUrl)
                .SetQueryParams(new
                {
                    _params.version,
                    _params.first_name,
                    _params.last_name,
                    _params.number
                })
                .GetJsonAsync<SearchResults>()
                .Result;
        }
    }
}
