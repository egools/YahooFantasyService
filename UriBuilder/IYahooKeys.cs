using System;

namespace YahooFantasyService
{
    public interface IYahooKeys
    {
        public IYahooResource WithSubResources(Enum subresources);
        public string Build();
    }

}
