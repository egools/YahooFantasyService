using System.Collections.Generic;
using System.Threading.Tasks;

namespace YahooFantasyService
{
    public interface IYahooService
    {
        Task<YahooApiResultBase> CallYahooFantasyApi<T>(string uri);
        Task<YahooLeagueApiResult> GetLeague(string leagueKey, YahooEnums.LeagueSubresource resources = YahooEnums.LeagueSubresource.None);
        Task<YahooLeagueCollectionApiResult> GetLeagues(List<string> leagueKeys, YahooEnums.LeagueSubresource resources = YahooEnums.LeagueSubresource.None);
        Task<LeagueSettings> GetLeagueSettings(int year, int seasonId);
        Task<YahooPlayerApiResult> GetPlayer(string playerKey, YahooEnums.PlayerSubresource resources = YahooEnums.PlayerSubresource.None);
        Task<YahooPlayerCollectionApiResult> GetPlayers(List<string> playerKeys, YahooEnums.PlayerSubresource resources = YahooEnums.PlayerSubresource.None);
        Task<YahooTeamApiResult> GetTeam(string teamKey, YahooEnums.TeamSubresource resources = YahooEnums.TeamSubresource.None);
        Task<YahooTeamApiResult> GetTeamRosterWithStats(string teamKey, int week);
        Task<YahooTeamCollectionApiResult> GetTeams(List<string> teamKeys, YahooEnums.TeamSubresource resources = YahooEnums.TeamSubresource.None);
        Task<YahooTeamApiResult> GetTeamStats(string teamKey, YahooEnums.CoverageType coverageType, int filter);
    }
}