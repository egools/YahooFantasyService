using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class WeeklyTeamPoints : YahooPointsBase
    {
        [JsonProperty(PropertyName = "week")]
        public string Week { get; set; }
    }

}