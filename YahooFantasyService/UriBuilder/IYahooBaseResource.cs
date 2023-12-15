using System.Collections.Generic;

namespace YahooFantasyService
{
    public interface IYahooBaseResource
    {

        public IYahooKey WithKey(string key);
        public IYahooKeys WithKeys(List<string> keys);
    }

}
