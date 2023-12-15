using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooLeagueCollectionApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooLeagueCollectionApiResult(JToken leagues)
        {
            Leagues = leagues.SelectTokens("..league")
                .Select(l => YahooLeague.FromJTokens(l.Children()))
                .ToList();
        }

        public List<YahooLeague> Leagues { get; set; }

        public object[] LeaguesObjectCollection { get; set; }
    }
}
