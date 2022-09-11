using Flurl;
using Flurl.Http;
using NPIRegistryBrowserUnitTest.Models;

namespace NPIRegistryBrowserUnitTest.Query
{
    internal class CityQuery : BaseQuery
    {
        private NPISearchParams _params;

        public CityQuery(string city, string state)
        {
            _params = new NPISearchParams()
            {
                city = city,
                state = state
            };
        }

        public override SearchResults Search()
        {
            return new Url(BaseUrl)
                .SetQueryParams(new
                {
                    _params.version,
                    _params.city,
                    _params.state
                })
                .GetJsonAsync<SearchResults>()
                .Result;
        }
    }
}
