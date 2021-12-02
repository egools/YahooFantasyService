using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class StandingOutcomeTotals
    {
        [JsonProperty(PropertyName = "wins")]
        public string Wins { get; set; }

        [JsonProperty(PropertyName = "losses")]
        public string Losses { get; set; }

        [JsonProperty(PropertyName = "ties")]
        public int Ties { get; set; }

        [JsonProperty(PropertyName = "percentage")]
        public string Percentage { get; set; }
    }
}
