using System;

namespace YahooFantasyService
{
    public interface IYahooKey
    {
        public IYahooResource WithResource(string resource);
        public IYahooResource WithSubResources(Enum subresources);
        public string Build();
    }

}
