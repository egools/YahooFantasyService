using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class SettingsStatModifier
    {
        [JsonProperty(PropertyName = "stat_id")]
        public int StatId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "bonuses")]
        public List<SettingsStatBonus> Bonuses { get; set; }
    }

    public class SettingsStatBonus
    {
        [JsonConstructor]
        public SettingsStatBonus(JToken bonus)
        {
            Target = bonus["target"].ToObject<int>();
            Points = bonus["points"].ToObject<double>();
        }

        public int Target { get; set; }

        public double Points { get; set; }
    }
}
