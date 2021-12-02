using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooMatchupTeam : YahooTeamBase
    {
        [JsonProperty(PropertyName = "win_probability")]
        public double WinProbability { get; set; }

        [JsonProperty(PropertyName = "team_points")]
        public WeeklyTeamPoints TeamPoints { get; set; }

        [JsonProperty(PropertyName = "team_projected_points")]
        public WeeklyTeamPoints TeamProjectedPoints { get; set; }

        public static YahooMatchupTeam FromJTokens(List<JToken> team)
        {
            var matchupTeam = team[1].AbsorbTokenProperties(team[0]);
            return matchupTeam.ToObject<YahooMatchupTeam>();
        }
    }
}