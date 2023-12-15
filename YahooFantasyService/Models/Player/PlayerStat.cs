using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class PlayerStat
    {

        [JsonConstructor]
        public PlayerStat(JToken stat_id, JToken value)
        {
            StatId = stat_id.ToObject<int>();
            Value = value.ToObject<double>();
        }
        public int StatId { get; set; }
        public double Value { get; set; }
    }
}
