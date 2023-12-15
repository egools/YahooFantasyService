using Newtonsoft.Json;
using System.Net;

namespace YahooFantasyService
{
    public class YahooErrorApiResult
    {
        [JsonProperty(PropertyName = "xml:lang")]
        public string XmlLang { get; set; }

        [JsonProperty(PropertyName = "yahoo:uri")]
        public string YahooUri { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
