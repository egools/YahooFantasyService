using Newtonsoft.Json;
using System;

namespace YahooFantasyService
{
    internal class YahooAuthToken
    {
        public string AccessToken { get; set; }
        public DateTime TokenExpiration { get; set; }
    }

    internal class YahooTokenResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
    }
}
