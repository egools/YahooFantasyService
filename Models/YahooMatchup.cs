using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class YahooMatchup
    {
        [JsonProperty(PropertyName = "week")]
        public string Week { get; set; }

        [JsonProperty(PropertyName = "week_start")]
        public string WeekStart { get; set; }

        [JsonProperty(PropertyName = "week_end")]
        public string WeekEnd { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "is_playoffs")]
        private string _isPlayoffs
        {
            get => IsPlayoffs ? "1" : "0";
            set => IsPlayoffs = value == "1";
        }
        public bool IsPlayoffs { get; set; }


        [JsonProperty(PropertyName = "is_consolation")]
        private string _isConsolation
        {
            get => IsConsolation ? "1" : "0";
            set => IsConsolation = value == "1";
        }
        public bool IsConsolation { get; set; }

        [JsonProperty(PropertyName = "is_matchup_recap_available")]
        public bool IsMatchupRecapAvailable { get; set; }

        [JsonProperty(PropertyName = "matchup_recap_url")]
        public string MatchupRecapUrl { get; set; }

        [JsonProperty(PropertyName = "matchup_recap_title")]
        public string MatchupRecapTitle { get; set; }

        [JsonProperty(PropertyName = "is_tied")]
        public bool IsTied { get; set; }

        [JsonProperty(PropertyName = "winner_team_key")]
        public string WinnerTeamKey { get; set; }

        [JsonProperty(PropertyName = "matchup_grades")]
        public List<MatchupGrade> MatchupGrades { get; set; }

        public List<YahooMatchupTeam> MatchupTeams { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _matchupTeamData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext streamingContext)
        {
            if (_matchupTeamData.TryGetValue("0", out JToken matchup))
            {
                MatchupTeams = matchup
                    .SelectTokens("teams..team")
                    .Select(j => YahooMatchupTeam.FromJTokens(j.Children().ToList()))
                    .ToList();
            }
        }
    }

    public class MatchupGrade
    {
        [JsonConstructor]
        public MatchupGrade(JToken matchup_grade)
        {
            TeamKey = matchup_grade["team_key"].ToString();
            Grade = matchup_grade["grade"].ToString();
        }

        public string TeamKey { get; set; }

        public string Grade { get; set; }
    }

}