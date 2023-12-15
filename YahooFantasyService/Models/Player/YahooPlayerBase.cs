using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace YahooFantasyService
{
    public class YahooPlayerBase
    {
        [JsonProperty("player_key")]
        public string PlayerKey { get; set; }

        [JsonProperty("player_id")]
        public string PlayerId { get; set; }

        [JsonProperty("name")]
        public YahooPlayerName PlayerName { get; set; }

        [JsonProperty("editorial_player_key")]
        public string EditorialPlayerKey { get; set; }

        [JsonProperty("editorial_team_key")]
        public string EditorialTeamKey { get; set; }

        [JsonProperty("editorial_team_full_name")]
        public string EditorialTeamFullName { get; set; }

        [JsonProperty("editorial_team_abbr")]
        public string EditorialTeamAbbr { get; set; }

        [JsonProperty("uniform_number")]
        public string UniformNumber { get; set; }

        [JsonProperty("display_position")]
        public string DisplayPosition { get; set; }

        [JsonProperty("is_undroppable")]
        private string _isUndroppable
        {
            get => IsUndroppable ? "1" : "0";
            set => IsUndroppable = value == "1";
        }

        public bool IsUndroppable { get; set; }

        [JsonProperty("position_type")]
        public string PositionType { get; set; }

        [JsonProperty("primary_position")]
        public string PrimaryPosition { get; set; }


        public PlayerInjuryStatus InjuryStatus { get; set; }
        public List<string> EligibilePositions { get; set; }
        public List<string> ByeWeeks { get; set; }
        public PlayerStatType StatsType { get; set; }
        public List<PlayerStat> Stats { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _playerData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext streamingContext)
        {
            if (_playerData.TryGetValue("eligible_positions", out JToken eligiblePositions))
            {
                EligibilePositions = eligiblePositions.SelectTokens("..position").Select(j => j.ToString()).ToList();
            }

            if (_playerData.TryGetValue("player_stats", out JToken stats))
            {
                StatsType = new PlayerStatType();
                StatsType.CoverageType = stats.SelectToken("..coverage_type").ToString();
                StatsType.Value = stats.SelectToken(".." + StatsType.CoverageType.ToLower()).ToString();
                Stats = stats.SelectTokens("..stat").Select(j => j.ToObject<PlayerStat>()).ToList();
            }

            if (_playerData.TryGetValue("bye_weeks", out JToken byes))
            {
                ByeWeeks = byes.SelectTokens("..week").Select(j => j.ToString()).ToList();
            }

            _playerData.TryGetValue("status", out JToken status);
            _playerData.TryGetValue("status_full", out JToken statusFull);
            _playerData.TryGetValue("injury_note", out JToken injuryNote);
            InjuryStatus = new PlayerInjuryStatus
            {
                Status = status?.ToString(),
                StatusFull = statusFull?.ToString(),
                InjuryNote = injuryNote?.ToString()
            };
        }

        public static YahooPlayerBase FromJTokens(IEnumerable<JToken> player)
        {
            var basePlayer = new JObject();
            basePlayer.AbsorbTokenProperties(player.First());
            foreach (var j in player.Skip(1))
            {
                if (j.First is JProperty prop)
                    basePlayer[prop.Name] = prop.Value;
            }
            return basePlayer.ToObject<YahooPlayerBase>();
        }
    }
}
