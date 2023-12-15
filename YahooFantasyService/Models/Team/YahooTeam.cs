using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooTeam : YahooTeamBase
    {
        public YahooRoster Roster { get; set; }

        public List<YahooMatchup> Matchups { get; set; }

        public SeasonTeamPoints SeasonPoints { get; set; }

        public WeeklyTeamPoints ActualWeeklyTeamPoints { get; set; }

        public WeeklyTeamPoints ProjectedWeeklyTeamPoints { get; set; }

        public static YahooTeam FromJTokens(IEnumerable<JToken> teamTokens)
        {
            var baseTeamToken = teamTokens.Count() < 2
            ? new JObject()
            : teamTokens.LastOrDefault()
            ?? new JObject();
            var team = baseTeamToken.AbsorbTokenProperties(teamTokens.FirstOrDefault()).ToObject<YahooTeam>();
            team.Matchups = teamTokens.SelectMany(j => j.SelectTokens("..matchups..matchup"))
                ?.Select(j => j.ToObject<YahooMatchup>())
                ?.ToList();
            team.SeasonPoints = teamTokens
                .Select(j => j.SelectToken("team_points"))
                .FirstOrDefault(j => j?.SelectToken("coverage_type")?.ToString() == "season")
                ?.ToObject<SeasonTeamPoints>();
            team.ActualWeeklyTeamPoints = teamTokens
                .Select(j => j.SelectToken("team_points"))
                .FirstOrDefault(j => j?.SelectToken("coverage_type")?.ToString() == "week")
                ?.ToObject<WeeklyTeamPoints>();
            team.ProjectedWeeklyTeamPoints = teamTokens
                .Select(j => j.SelectToken("team_projected_points"))
                .FirstOrDefault(j => j?.SelectToken("coverage_type")?.ToString() == "week")
                ?.ToObject<WeeklyTeamPoints>();
            return team;
        }
    }
}
