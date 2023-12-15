using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class YahooPlayerName
    {
        [JsonProperty("full")]
        public string FullName { get; set; }

        [JsonProperty("first")]
        public string FirstName { get; set; }

        [JsonProperty("last")]
        public string LastName { get; set; }

        [JsonProperty("ascii_first")]
        public string AsciiFirst { get; set; }

        [JsonProperty("ascii_last")]
        public string AsciiLast { get; set; }
    }
}
