using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class SeasonTeamPoints : YahooPointsBase
    {
        [JsonProperty(PropertyName = "season")]
        public string Season { get; set; }
    }
}
