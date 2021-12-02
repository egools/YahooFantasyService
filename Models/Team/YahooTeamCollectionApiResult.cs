using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooTeamCollectionApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooTeamCollectionApiResult(JToken teams)
        {
            Teams = teams.SelectTokens("..team")
                .Select(l => YahooTeam.FromJTokens(l.Children()))
                .ToList();
        }

        public List<YahooTeam> Teams { get; set; }
    }
}
