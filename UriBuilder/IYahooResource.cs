using System;
using static YahooFantasyService.YahooEnums;

namespace YahooFantasyService
{
    public interface IYahooResource
    {
        public IYahooResource WithResource(string resource);
        public IYahooResource WithSubResources(Enum subresources);
        public IYahooResource WithCoverageType(CoverageType coverageType, int value);
        public IYahooResource WithFilter(string field, string value);
        public string Build();
    }

}
