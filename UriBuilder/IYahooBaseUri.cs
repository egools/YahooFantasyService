using static YahooFantasyService.YahooEnums;

namespace YahooFantasyService
{
    public interface IYahooBaseUri
    {
        public IYahooBaseResource WithBaseResource(BaseResource baseResource);
    }

}
