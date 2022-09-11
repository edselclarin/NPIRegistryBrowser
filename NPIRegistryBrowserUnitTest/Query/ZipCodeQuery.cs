using Flurl;
using Flurl.Http;
using NPIRegistryBrowserUnitTest.Models;

namespace NPIRegistryBrowserUnitTest.Query
{
    internal class ZipCodeQuery : BaseQuery
    {
        private NPISearchParams _params;

        public ZipCodeQuery(string postalCode)
        {
            _params = new NPISearchParams()
            {
                postal_code = postalCode
            };
        }

        public override SearchResults Search()
        {
            return new Url(BaseUrl)
                .SetQueryParams(new
                {
                    _params.version,
                    _params.postal_code
                })
                .GetJsonAsync<SearchResults>()
                .Result;
        }
    }
}
