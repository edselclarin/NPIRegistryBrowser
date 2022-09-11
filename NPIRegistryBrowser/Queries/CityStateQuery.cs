using Flurl;
using Flurl.Http;
using NPIRegistryBrowser.Models;
using System;

namespace NPIRegistryBrowser.Queries
{
    public class CityStateQuery : BaseQuery
    {
        private SearchParamsModel _params;

        public CityStateQuery(string city, string state)
        {
            _params = new SearchParamsModel()
            {
                city = city,
                state = state
            };
        }

        public override SearchResultsModel Search()
        {
            return new Url(BaseUrl)
                .SetQueryParams(new
                {
                    _params.version,
                    _params.limit,
                    _params.city,
                    _params.state
                })
                .GetJsonAsync<SearchResultsModel>()
                .Result;
        }
    }
}
