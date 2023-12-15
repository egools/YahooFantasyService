using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class YahooManager
    {
        [JsonConstructor]
        public YahooManager(JToken manager)
        {
            ManagerId = manager["manager_id"].ToString();
            Nickname = manager["nickname"].ToString();
            Guid = manager["guid"].ToString();
            IsCommisioner = manager["is_commissioner"]?.ToString() == "1";
            FeloScore = manager["felo_score"].ToObject<int>();
            FeloTier = manager["felo_tier"].ToString();
        }

        public string ManagerId { get; set; }

        public string Nickname { get; set; }

        public string Guid { get; set; }

        public bool? IsCommisioner { get; set; }

        public int FeloScore { get; set; }

        public string FeloTier { get; set; }
    }




}
