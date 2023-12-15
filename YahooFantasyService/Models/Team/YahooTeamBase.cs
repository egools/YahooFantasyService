using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooTeamBase
    {
        [JsonProperty(PropertyName = "team_key")]
        public string TeamKey { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public string TeamId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "division_id")]
        public string DivisionId { get; set; }

        [JsonProperty(PropertyName = "waiver_priority")]
        public int WaiverPriority { get; set; }

        [JsonProperty(PropertyName = "faab_balance")]
        public string FaabBalance { get; set; }

        [JsonProperty(PropertyName = "number_of_moves")]
        public string NumberOfMoves { get; set; }

        [JsonProperty(PropertyName = "number_of_trades")]
        public int NumberOfTrades { get; set; }

        [JsonProperty(PropertyName = "roster_adds")]
        public StandingRosterAdds RosterAdds { get; set; }

        [JsonProperty(PropertyName = "clinched_playoffs")]
        public int ClinchedPlayoffs { get; set; }

        [JsonProperty(PropertyName = "league_scoring_type")]
        public string LeagueScoringType { get; set; }

        [JsonProperty(PropertyName = "has_draft_grade")]
        public bool HasDraftGrade { get; set; }

        [JsonProperty(PropertyName = "auction_budget_total")]
        public string AuctionBudgetTotal { get; set; }

        [JsonProperty(PropertyName = "auction_budget_spent")]
        public int AuctionBudgetSpent { get; set; }

        [JsonProperty(PropertyName = "managers")]
        public List<YahooManager> Managers { get; set; }
    }
}
