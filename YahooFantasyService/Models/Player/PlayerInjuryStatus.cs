using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class PlayerInjuryStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_full")]
        public string StatusFull { get; set; }

        [JsonProperty("injury_note")]
        public string InjuryNote { get; set; }
    }
}
