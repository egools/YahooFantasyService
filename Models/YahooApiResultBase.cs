using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class YahooApiResultBase
    {
        [JsonProperty(PropertyName = "xml:lang")]
        public string XmlLang { get; set; }

        [JsonProperty(PropertyName = "yahoo:uri")]
        public string YahooUri { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "refresh_rate")]
        public string RefreshRate { get; set; }
    }
}
