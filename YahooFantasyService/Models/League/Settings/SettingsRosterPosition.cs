using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class SettingsRosterPosition
    {
        [JsonConstructor]
        public SettingsRosterPosition(JToken roster_position)
        {
            Position = roster_position["position"].ToString();
            PositionType = roster_position["position_type"]?.ToString();
            Count = roster_position["count"].ToObject<int>();
        }

        public string Position { get; set; }

        public string PositionType { get; set; }

        public int Count { get; set; }
    }
}
