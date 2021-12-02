using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static YahooFantasyService.YahooEnums;

namespace YahooFantasyService
{
    public partial class YahooService : IYahooService
    {
        public YahooService(IOptions<YahooServiceSettings> options)
        {
            _settings = options.Value;
        }

        private YahooAuthToken _yahooToken;
        private readonly YahooServiceSettings _settings;
        private IYahooBaseUri _uriBuilder => YahooUriBuilder.WithBaseUrl(_settings.BaseUrl);

        public async Task<LeagueSettings> GetLeagueSettings(int year, int seasonId)
        {
            if (!NFLGameKeys.TryGetValue(year, out int gameKey))
            {
                throw new ArgumentException("NFL Game Key for given year does not exist.");
            }
            var leagueKey = $"{gameKey}.l.{seasonId}";
            var leagueResult = await GetLeague(leagueKey, LeagueSubresource.Settings);
            return leagueResult.League.Settings;
        }

        public async Task<YahooTeamApiResult> GetTeamRosterWithStats(string teamKey, int week)
        {
            var uri = _uriBuilder
                .WithBaseResource(BaseResource.Team)
                .WithKey(teamKey)
                .WithResource("roster")
                .WithCoverageType(CoverageType.Week, week)
                .WithResource("players")
                .WithSubResources(PlayerSubresource.Stats)
                .Build();

            var teamResult = await CallYahooFantasyApi<YahooTeamApiResult>(uri);
            return teamResult as YahooTeamApiResult;
        }

        public async Task<YahooTeamApiResult> GetTeam(string teamKey, TeamSubresource resources = TeamSubresource.None)
        {
            var uri = _uriBuilder
                .WithBaseResource(BaseResource.Team)
                .WithKey(teamKey)
                .WithSubResources(resources)
                .Build();
            var teamsResult = await CallYahooFantasyApi<YahooTeamApiResult>(uri);
            return teamsResult as YahooTeamApiResult;
        }

        public async Task<YahooTeamCollectionApiResult> GetTeams(List<string> teamKeys, TeamSubresource resources = TeamSubresource.None)
        {
            var uri = _uriBuilder
                .WithBaseResource(BaseResource.Team)
                .WithKeys(teamKeys)
                .WithSubResources(resources)
                .Build();
            var teamsResult = await CallYahooFantasyApi<YahooTeamCollectionApiResult>(uri);
            return teamsResult as YahooTeamCollectionApiResult;
        }

        public async Task<YahooTeamApiResult> GetTeamStats(string teamKey, CoverageType coverageType, int filter)
        {
            var uri = _uriBuilder
                .WithBaseResource(BaseResource.Team)
                .WithKey(teamKey)
                .WithResource("stats")
                .WithCoverageType(coverageType, filter)
                .Build();

            var teamResult = await CallYahooFantasyApi<YahooTeamApiResult>(uri);
            return teamResult as YahooTeamApiResult;
        }

        public async Task<YahooLeagueApiResult> GetLeague(string leagueKey, LeagueSubresource resources = LeagueSubresource.None)
        {
            var uri = _uriBuilder
                .WithBaseResource(BaseResource.League)
                .WithKey(leagueKey)
                .WithSubResources(resources)
                .Build();
            var leagueResult = await CallYahooFantasyApi<YahooLeagueApiResult>(uri);
            return leagueResult as YahooLeagueApiResult;
        }

        public async Task<YahooLeagueCollectionApiResult> GetLeagues(List<string> leagueKeys, LeagueSubresource resources = LeagueSubresource.None)
        {
            var uri = _uriBuilder
                .WithBaseResource(BaseResource.League)
                .WithKeys(leagueKeys)
                .WithSubResources(resources)
                .Build();
            var leaguesResult = await CallYahooFantasyApi<YahooLeagueCollectionApiResult>(uri);
            return leaguesResult as YahooLeagueCollectionApiResult;
        }

        public async Task<YahooPlayerApiResult> GetPlayer(string playerKey, PlayerSubresource resources = PlayerSubresource.None)
        {
            var uri = _uriBuilder
                .WithBaseResource(BaseResource.Player)
                .WithKey(playerKey)
                .WithSubResources(resources)
                .Build();
            var playersResult = await CallYahooFantasyApi<YahooPlayerApiResult>(uri);
            return playersResult as YahooPlayerApiResult;
        }

        public async Task<YahooPlayerCollectionApiResult> GetPlayers(List<string> playerKeys, PlayerSubresource resources = PlayerSubresource.None)
        {
            var uri = _uriBuilder
                .WithBaseResource(BaseResource.Player)
                .WithKeys(playerKeys)
                .WithSubResources(resources)
                .Build();
            var playersResult = await CallYahooFantasyApi<YahooPlayerCollectionApiResult>(uri);
            return playersResult as YahooPlayerCollectionApiResult;
        }

        public async Task<YahooApiResultBase> CallYahooFantasyApi<T>(string uri)
        {
            await RefreshAuthToken();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _yahooToken.AccessToken);
            var response = await client.GetAsync(uri);
            client.Dispose();
            var jsonResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                JObject o = JObject.Parse(jsonResult);
                var fantasyContent = o.SelectToken("fantasy_content").ToString();
                var resultBase = JsonConvert.DeserializeObject<T>(fantasyContent) as YahooApiResultBase;
                Console.WriteLine($"Deserialization: {stopwatch.ElapsedMilliseconds}");
                return resultBase;
            }
            else
            {
                JObject o = JObject.Parse(jsonResult);
                var errorResult = o.SelectToken("error").ToObject<YahooErrorApiResult>();
                errorResult.StatusCode = response.StatusCode;
                throw new YahooServiceException(errorResult);
            }
        }

        private async Task RefreshAuthToken(bool retry = true)
        {
            if (_yahooToken is null || _yahooToken.TokenExpiration < DateTime.UtcNow)
            {
                var client = new HttpClient();
                var body = new Dictionary<string, string>
                {
                    { "grant_type", "refresh_token" },
                    { "redirect_uri", "oob" },
                    { "refresh_token", _settings.RefreshToken }
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _settings.AuthHeader);
                var response = await client.PostAsync(_settings.TokenUrl, new FormUrlEncodedContent(body));
                client.Dispose();

                if (response.IsSuccessStatusCode)
                {
                    var token = JsonConvert.DeserializeObject<YahooTokenResponse>(await response.Content.ReadAsStringAsync());
                    _yahooToken = new YahooAuthToken
                    {
                        AccessToken = token.AccessToken,
                        TokenExpiration = DateTime.UtcNow.AddSeconds(token.ExpiresIn)
                    };
                }
                else
                {
                    if (retry)
                    {
                        await RefreshAuthToken(false);
                    }
                    else
                    {
                        var error = JObject.Parse(await response.Content.ReadAsStringAsync());
                        throw new HttpRequestException(error.Value<string>("error_description"), null, response.StatusCode);
                    }
                }
            }
        }

        public static IReadOnlyDictionary<int, int> NFLGameKeys => new Dictionary<int, int>
        {
            { 2004, 101 },
            { 2005, 124 },
            { 2006, 153 },
            { 2007, 175 },
            { 2008, 199 },
            { 2009, 222 },
            { 2010, 242 },
            { 2011, 257 },
            { 2012, 273 },
            { 2013, 314 },
            { 2014, 331 },
            { 2015, 348 },
            { 2016, 359 },
            { 2017, 371 },
            { 2018, 380 },
            { 2019, 390 },
            { 2020, 399 }
        };
    }
}