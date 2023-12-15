using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class SettingsStatCategory
    {
        [JsonProperty(PropertyName = "stat_id")]
        public int StatId { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        public string Enabled { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "sort_order")]
        public string SortOrder { get; set; }

        [JsonProperty(PropertyName = "position_type")]
        public string PositionType { get; set; }

        [JsonProperty(PropertyName = "is_only_display_stat")]
        public string IsOnlyDisplayStat { get; set; }

        [JsonProperty(PropertyName = "is_excluded_from_display")]
        public string IsExcludedFromDisplay { get; set; }

        [JsonProperty(PropertyName = "stat_position_types")]
        public List<SettingsStatPositionType> StatPositionTypes { get; set; }
    }

    public class SettingsStatPositionType
    {
        [JsonConstructor]
        public SettingsStatPositionType(JToken stat_position_type)
        {
            PositionType = stat_position_type["position_type"].ToString();
            IsOnlyDisplayStat = stat_position_type["is_only_display_stat"]?.ToString();
        }

        public string PositionType { get; set; }

        public string IsOnlyDisplayStat { get; set; }
    }
}
