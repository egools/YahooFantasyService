using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasyService
{
    public static class JObjectExtensions
    {
        public static JToken AbsorbTokenProperties(this JToken baseToken, JToken targetToken)
        {
            var baseTeamProps = targetToken.SelectTokens("[*]").SelectMany(j => j);
            foreach (var baseTeamProp in baseTeamProps)
            {
                if (baseTeamProp is JProperty prop)
                    baseToken[prop.Name] = prop.Value;
            }
            return baseToken;
        }
    }
}