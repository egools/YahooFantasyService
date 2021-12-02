using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooLeague
    {
        [JsonProperty(PropertyName = "league_key")]
        public string LeagueKey { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public string LeagueId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty(PropertyName = "draft_status")]
        public string DraftStatus { get; set; }

        [JsonProperty(PropertyName = "num_teams")]
        public int NumTeams { get; set; }

        [JsonProperty(PropertyName = "edit_key")]
        public string EditKey { get; set; }

        [JsonProperty(PropertyName = "weekly_deadline")]
        public string WeeklyDeadline { get; set; }

        [JsonProperty(PropertyName = "league_update_timestamp")]
        public string LeagueUpdateTimestamp { get; set; }

        [JsonProperty(PropertyName = "scoring_type")]
        public string ScoringType { get; set; }

        [JsonProperty(PropertyName = "league_type")]
        public string LeagueType { get; set; }

        [JsonProperty(PropertyName = "renew")]
        public string Renew { get; set; }

        [JsonProperty(PropertyName = "renewed")]
        public string Renewed { get; set; }

        [JsonProperty(PropertyName = "iris_group_chat_id")]
        public string IrisGroupChatId { get; set; }

        [JsonProperty(PropertyName = "allow_add_to_dl_extra_pos")]
        public int AllowAddToDlExtraPos { get; set; }

        [JsonProperty(PropertyName = "is_pro_league")]
        public string IsProLeague { get; set; }

        [JsonProperty(PropertyName = "is_cash_league")]
        public string IsCashLeague { get; set; }

        [JsonProperty(PropertyName = "current_week")]
        public string CurrentWeek { get; set; }

        [JsonProperty(PropertyName = "start_week")]
        public string StartWeek { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; set; }

        [JsonProperty(PropertyName = "end_week")]
        public string EndWeek { get; set; }

        [JsonProperty(PropertyName = "end_date")]
        public string EndDate { get; set; }

        [JsonProperty(PropertyName = "is_finished")]
        public bool IsFinished { get; set; }

        [JsonProperty(PropertyName = "game_code")]
        public string GameCode { get; set; }

        [JsonProperty(PropertyName = "season")]
        public string Season { get; set; }


        public List<DraftPick> DraftPicks { get; set; }

        public LeagueScoreboard Scoreboard { get; set; }

        public LeagueSettings Settings { get; set; }

        public List<YahooTeamStanding> Standings { get; set; }

        public static YahooLeague FromJTokens(IEnumerable<JToken> leagueTokens)
        {

            var league = leagueTokens
                .FirstOrDefault()
                ?.ToObject<YahooLeague>();
            league.Settings = leagueTokens
                .Select(j => j.SelectToken("settings[0]"))
                .FirstOrDefault(j => j is not null)
                ?.ToObject<LeagueSettings>();
            league.DraftPicks = leagueTokens
                .SelectMany(j =>
                    j.SelectTokens("draft_results..draft_result"))
                .Select(j => j.ToObject<DraftPick>())
                .ToList();
            league.Scoreboard = leagueTokens
                .FirstOrDefault(j => j.SelectToken("scoreboard") is not null)
                ?.ToObject<LeagueScoreboard>();
            league.Standings = leagueTokens
                .SelectMany(j => j.SelectTokens("standings[*].teams..team"))
                .Select(j => YahooTeamStanding.FromJTokens(j.Children().ToList()))
                .ToList();
            return league;
        }
    }
}
