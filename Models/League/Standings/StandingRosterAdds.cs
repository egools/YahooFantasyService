using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class StandingRosterAdds
    {
        [JsonProperty(PropertyName = "coverage_type")]
        public string CoverageType { get; set; }

        [JsonProperty(PropertyName = "coverage_value")]
        public string CoverageValue { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
