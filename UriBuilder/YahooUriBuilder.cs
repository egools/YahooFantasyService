using System;
using System.Collections.Generic;
using static YahooFantasyService.YahooEnums;

namespace YahooFantasyService
{
    public class YahooUriBuilder : IYahooBaseUri, IYahooBaseResource, IYahooKey, IYahooKeys, IYahooResource
    {
        private string _uri;
        private string _baseResource;

        private YahooUriBuilder(string baseUrl)
        {
            _uri = baseUrl;
        }

        public static IYahooBaseUri WithBaseUrl(string baseUrl) => new YahooUriBuilder(baseUrl);

        public IYahooBaseResource WithBaseResource(BaseResource baseResource)
        {
            _uri += $"/{baseResource.ToString().ToLower()}";
            _baseResource = baseResource.ToString().ToLower();
            return this;
        }


        public IYahooKey WithKey(string key)
        {
            _uri += $"/{key}";
            return this;
        }
        public IYahooKeys WithKeys(List<string> keys)
        {
            _uri += $"s;{_baseResource}_keys={string.Join(',', keys)}";
            return this;
        }

        public IYahooResource WithResource(string resource)
        {
            _uri += $"/{resource}";
            return this;
        }

        public IYahooResource WithCoverageType(CoverageType coverageType, int value)
        {
            var coverage = coverageType.ToString().ToLower();
            _uri += $";type={coverage};{coverage}={value}";
            return this;
        }
        public IYahooResource WithFilter(string field, string value)
        {
            _uri += $";{field}={value}";
            return this;
        }

        public IYahooResource WithSubResources(Enum subresources)
        {
            _uri += Convert.ToInt32(subresources) != 0
                ? ";out=" + subresources.ToString().ToLower().Replace(" ", "")
                : string.Empty;
            return this;
        }

        public string Build()
        {
            return _uri + "?format=json";
        }
    }
}
