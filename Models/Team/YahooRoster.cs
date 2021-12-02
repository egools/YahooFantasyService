using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace YahooFantasyService
{
    public class YahooRoster
    {
        [JsonProperty("week")]
        public string Week { get; set; }

        [JsonProperty("is_editable")]
        public bool IsEditable { get; set; }

        [JsonProperty("coverage_type")]
        public string CoverageType { get; set; }

        public List<YahooRosterPlayer> RosteredPlayers { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _teamRosterData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext streamingContext)
        {
            if (_teamRosterData.TryGetValue("0", out JToken matchup))
            {
                RosteredPlayers = matchup
                    .SelectTokens("..player")
                    .Select(j => YahooRosterPlayer.FromJTokens(j.Children().ToList()))
                    .ToList();
            }
        }
    }
}
