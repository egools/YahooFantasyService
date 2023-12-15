using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooTeamStanding : YahooTeamBase
    {
        [JsonProperty(PropertyName = "team_points")]
        public SeasonTeamPoints TeamPoints { get; set; }

        [JsonProperty(PropertyName = "team_standings")]
        public StandingEntry StandingEntry { get; set; }

        public static YahooTeamStanding FromJTokens(List<JToken> team)
        {
            var standingsTeam = team[1].AbsorbTokenProperties(team[0]);
            standingsTeam["team_standings"] = team[2]["team_standings"];
            return standingsTeam.ToObject<YahooTeamStanding>();
        }
    }
}
