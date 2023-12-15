using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class SettingsDivision
    {
        [JsonConstructor]
        public SettingsDivision(JToken division)
        {
            DivisionId = division["division_id"].ToObject<int>();
            Name = division["name"].ToString();
        }

        public int DivisionId { get; set; }

        public string Name { get; set; }
    }
}
