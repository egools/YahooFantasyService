using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class YahooPlayerApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooPlayerApiResult(JToken[] player)
        {
            Player = YahooPlayerBase.FromJTokens(player);
        }

        public YahooPlayerBase Player { get; set; }
    }
}
