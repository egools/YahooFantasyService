using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooRosterPlayer : YahooPlayerBase
    {
        [JsonConstructor]
        public YahooRosterPlayer(JToken selected_position)
        {
            var selectedPosition = new JObject();
            selectedPosition.AbsorbTokenProperties(selected_position);
            SelectedPosition = selectedPosition.ToObject<SelectedPosition>();
        }

        public SelectedPosition SelectedPosition { get; set; }

        public static new YahooRosterPlayer FromJTokens(IEnumerable<JToken> player)
        {
            var rosterPlayer = new JObject();
            rosterPlayer.AbsorbTokenProperties(player.First());
            foreach(var j in player.Skip(1))
            {
                if (j.First is JProperty prop)
                    rosterPlayer[prop.Name] = prop.Value;
            }
            return rosterPlayer.ToObject<YahooRosterPlayer>();
        }
    }

    public class SelectedPosition
    {
        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("is_flex")]
        public bool IsFlex { get; set; }
    }
}
