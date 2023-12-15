using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooLeagueApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooLeagueApiResult(JToken [] league)
        {
            League = YahooLeague.FromJTokens(league);
        }

        public YahooLeague League { get; set; }
    }
}
