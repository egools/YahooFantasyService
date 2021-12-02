using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class YahooPointsBase
    {
        [JsonProperty(PropertyName = "coverage_type")]
        public string CoverageType { get; set; }

        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }
    }
}