using System;

namespace YahooFantasyService
{
    public class YahooServiceException : Exception
    {
        public YahooServiceException(YahooErrorApiResult errorResult)
        {
            ErrorResult = errorResult;
        }

        public YahooErrorApiResult ErrorResult { get; init; }
    }
}
