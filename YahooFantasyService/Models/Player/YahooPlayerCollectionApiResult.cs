using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooPlayerCollectionApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooPlayerCollectionApiResult(JToken players)
        {
            Players = players.SelectTokens("..player")
                .Select(l => YahooPlayerBase.FromJTokens(l.Children()))
                .ToList();
        }

        public List<YahooPlayerBase> Players { get; set; }
    }
}
