using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class LeagueSettings
    {

        [JsonConstructor]
        public LeagueSettings(JToken stat_categories, JToken stat_modifiers)
        {
            StatCategories = stat_categories
                .SelectToken("stats")
                .Select(s => 
                    JsonConvert.DeserializeObject<SettingsStatCategory>(s.SelectToken("stat").ToString()))
                .ToList();

            StatModifiers = stat_modifiers
                .SelectToken("stats")
                .Select(s =>
                    JsonConvert.DeserializeObject<SettingsStatModifier>(s.SelectToken("stat").ToString()))
                .ToList();
        }

        [JsonProperty(PropertyName = "draft_type")]
        public string DraftType { get; set; }

        [JsonProperty(PropertyName = "is_auction_draft")]
        private string _isAuctionDraft
        {
            get => IsAuctionDraft ? "1" : "0";
            set => IsAuctionDraft = value == "1";
        }
        public bool IsAuctionDraft { get; set; }

        [JsonProperty(PropertyName = "scoring_type")]
        public string ScoringType { get; set; }

        [JsonProperty(PropertyName = "persistent_url")]
        public string PersistentUrl { get; set; }

        [JsonProperty(PropertyName = "uses_playoff")]
        public string UsesPlayoff { get; set; }

        [JsonProperty(PropertyName = "has_playoff_consolation_games")]
        public bool HasPlayoffConsolationGames { get; set; }

        [JsonProperty(PropertyName = "playoff_start_week")]
        public string PlayoffStartWeek { get; set; }

        [JsonProperty(PropertyName = "uses_playoff_reseeding")]
        public int UsesPlayoffReseeding { get; set; }

        [JsonProperty(PropertyName = "uses_lock_eliminated_teams")]
        public int UsesLockEliminatedTeams { get; set; }

        [JsonProperty(PropertyName = "num_playoff_teams")]
        public string NumPlayoffTeams { get; set; }

        [JsonProperty(PropertyName = "num_playoff_consolation_teams")]
        public int NumPlayoffConsolationTeams { get; set; }

        [JsonProperty(PropertyName = "has_multiweek_championship")]
        public bool HasMultiweekChampionship { get; set; }

        [JsonProperty(PropertyName = "waiver_type")]
        public string WaiverType { get; set; }

        [JsonProperty(PropertyName = "waiver_rule")]
        public string WaiverRule { get; set; }

        [JsonProperty(PropertyName = "uses_faab")]
        public string UsesFaab { get; set; }

        [JsonProperty(PropertyName = "draft_time")]
        public string DraftTime { get; set; }

        [JsonProperty(PropertyName = "draft_pick_time")]
        public string DraftPickTime { get; set; }

        [JsonProperty(PropertyName = "post_draft_players")]
        public string PostDraftPlayers { get; set; }

        [JsonProperty(PropertyName = "max_teams")]
        public string MaxTeams { get; set; }

        [JsonProperty(PropertyName = "waiver_time")]
        public string WaiverTime { get; set; }

        [JsonProperty(PropertyName = "trade_end_date")]
        public string TradeEndDate { get; set; }

        [JsonProperty(PropertyName = "trade_ratify_type")]
        public string TradeRatifyType { get; set; }

        [JsonProperty(PropertyName = "trade_reject_time")]
        public string TradeRejectTime { get; set; }

        [JsonProperty(PropertyName = "player_pool")]
        public string PlayerPool { get; set; }

        [JsonProperty(PropertyName = "cant_cut_list")]
        public string CantCutList { get; set; }

        [JsonProperty(PropertyName = "sendbird_channel_url")]
        public string SendbirdChannelUrl { get; set; }

        [JsonProperty(PropertyName = "pickem_enabled")]
        public string PickemEnabled { get; set; }

        [JsonProperty(PropertyName = "uses_fractional_points")]
        public string UsesFractionalPoints { get; set; }

        [JsonProperty(PropertyName = "uses_negative_points")]
        public string UsesNegativePoints { get; set; }

        [JsonProperty(PropertyName = "divisions")]
        public List<SettingsDivision> Divisions { get; set; }

        [JsonProperty(PropertyName = "roster_positions")]
        public List<SettingsRosterPosition> RosterPositions { get; set; }

        public List<SettingsStatCategory> StatCategories { get; set; }
        public List<SettingsStatModifier> StatModifiers { get; set; }
    }
}
