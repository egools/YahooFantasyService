using Microsoft.Extensions.Options;
using YahooFantasyService;

namespace YahooServiceTest
{
    public class Tests
    {
        private YahooService _sut;

        [OneTimeSetUp]
        public void Setup()
        {
            _sut = new YahooService(Options.Create(new YahooServiceSettings
            {
                AuthHeader = "",
                BaseUrl = "https://fantasysports.yahooapis.com/fantasy/v2",
                RefreshToken = "",
                TokenUrl = "https://api.login.yahoo.com/oauth2/get_token"
            }));
        }

        [Test]
        public async Task Test1()
        {
            var result = await _sut.GetLeagueSettings(2022, 307223);
            Assert.Pass();
        }
    }
}