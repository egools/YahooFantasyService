using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class DraftPick
    {
        [JsonProperty(PropertyName = "pick")]
        public int Pick { get; set; }

        [JsonProperty(PropertyName = "round")]
        public int Round { get; set; }

        [JsonProperty(PropertyName = "cost")]
        public double Cost { get; set; }

        [JsonProperty(PropertyName = "team_key")]
        public string TeamKey { get; set; }

        [JsonProperty(PropertyName = "player_key")]
        public string PlayerKey { get; set; }

    }
}
