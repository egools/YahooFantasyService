using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooTeamApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooTeamApiResult(JToken[] team)
        {
            Team = YahooTeam.FromJTokens(team);
        }

        public YahooTeam Team { get; set; }
    }
}
