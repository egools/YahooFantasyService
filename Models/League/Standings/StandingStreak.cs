using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class StandingStreak
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
