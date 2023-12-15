using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class StandingEntry
    {
        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }

        [JsonProperty(PropertyName = "playoff_seed")]
        public string PlayoffSeed { get; set; }

        [JsonProperty(PropertyName = "outcome_totals")]
        public StandingOutcomeTotals OutcomeTotals { get; set; }

        [JsonProperty(PropertyName = "divisional_outcome_totals")]
        public StandingOutcomeTotals DivisionalOutcomeTotals { get; set; }

        [JsonProperty(PropertyName = "streak")]
        public StandingStreak Streak { get; set; }

        [JsonProperty(PropertyName = "points_for")]
        public string PointsFor { get; set; }

        [JsonProperty(PropertyName = "points_against")]
        public double PointsAgainst { get; set; }
    }
}
