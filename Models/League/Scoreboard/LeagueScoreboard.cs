using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class LeagueScoreboard
    {
        [JsonConstructor]
        public LeagueScoreboard(JToken scoreboard)
        {
            Week = scoreboard["week"].ToString();
            Matchups = scoreboard.SelectTokens("..matchups..matchup")
                .Select(j => j.ToObject<YahooMatchup>())
                .ToList();
        }

        public string Week { get; set; } //contains comma separated list of weeks in list of matchups

        public List<YahooMatchup> Matchups { get; set; }
    }
}
