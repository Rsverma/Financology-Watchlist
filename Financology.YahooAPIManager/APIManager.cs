using Financology.BusinessLogic;
using Financology.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Financology.YahooAPIManager
{
    public class APIManager : IAPIManager
    {
        private string url = "https://query1.finance.yahoo.com/v7/finance/quote?symbols=";
        public Dictionary<string, LiveFeedData> GetLiveFeedDictionary(List<string> symbols)
        {
            Dictionary<string, LiveFeedData> result = new Dictionary<string, LiveFeedData>();
            foreach (string symbol in symbols)
            {
                try
                {
                    string myJsonResponse = new WebClient().DownloadString(url + symbol);
                    Root root = JsonConvert.DeserializeObject<Root>(myJsonResponse);
                    if (root.quoteResponse.result != null)
                    {
                        LiveFeedData data = GetLiveFeedFromResponse(root.quoteResponse.result[0]);
                        result.Add(symbol, data);
                    }
                }
                catch { }

            }
            return result;
        }

        private LiveFeedData GetLiveFeedFromResponse(Result result)
        {
            LiveFeedData data = new LiveFeedData();

            data.language = result.language;
            data.region = result.region;
            data.Asset = result.quoteType;
            data.quoteSourceName = result.quoteSourceName;
            data.triggerable = result.triggerable;
            data.currency = result.currency;
            data.firstTradeDateMilliseconds = result.firstTradeDateMilliseconds;
            data.priceHint = result.priceHint;
            data.postMarketChangePercent = result.postMarketChangePercent;
            data.postMarketTime = result.postMarketTime;
            data.postMarketPrice = result.postMarketPrice;
            data.postMarketChange = result.postMarketChange;
            data.Change = result.regularMarketChange;
            data.ChangePercent = result.regularMarketChangePercent;
            data.regularMarketTime = result.regularMarketTime;
            data.Last = result.regularMarketPrice;
            data.High = result.regularMarketDayHigh;
            data.regularMarketDayRange = result.regularMarketDayRange;
            data.Low = result.regularMarketDayLow;
            data.regularMarketVolume = result.regularMarketVolume;
            data.Close = result.regularMarketPreviousClose;
            data.Bid = result.bid;
            data.Ask = result.ask;
            data.bidSize = result.bidSize;
            data.askSize = result.askSize;
            data.fullExchangeName = result.fullExchangeName;
            data.financialCurrency = result.financialCurrency;
            data.Open = result.regularMarketOpen;
            data.averageDailyVolume3Month = result.averageDailyVolume3Month;
            data.averageDailyVolume10Day = result.averageDailyVolume10Day;
            data.fiftyTwoWeekLowChange = result.fiftyTwoWeekLowChange;
            data.fiftyTwoWeekLowChangePercent = result.fiftyTwoWeekLowChangePercent;
            data.fiftyTwoWeekRange = result.fiftyTwoWeekRange;
            data.fiftyTwoWeekHighChange = result.fiftyTwoWeekHighChange;
            data.fiftyTwoWeekHighChangePercent = result.fiftyTwoWeekHighChangePercent;
            data.fiftyTwoWeekLow = result.fiftyTwoWeekLow;
            data.fiftyTwoWeekHigh = result.fiftyTwoWeekHigh;
            data.dividendDate = result.dividendDate;
            data.earningsTimestamp = result.earningsTimestamp;
            data.earningsTimestampStart = result.earningsTimestampStart;
            data.earningsTimestampEnd = result.earningsTimestampEnd;
            data.trailingAnnualDividendRate = result.trailingAnnualDividendRate;
            data.trailingPE = result.trailingPE;
            data.trailingAnnualDividendYield = result.trailingAnnualDividendYield;
            data.epsTrailingTwelveMonths = result.epsTrailingTwelveMonths;
            data.epsForward = result.epsForward;
            data.epsCurrentYear = result.epsCurrentYear;
            data.priceEpsCurrentYear = result.priceEpsCurrentYear;
            data.sharesOutstanding = result.sharesOutstanding;
            data.bookValue = result.bookValue;
            data.fiftyDayAverage = result.fiftyDayAverage;
            data.fiftyDayAverageChange = result.fiftyDayAverageChange;
            data.fiftyDayAverageChangePercent = result.fiftyDayAverageChangePercent;
            data.twoHundredDayAverage = result.twoHundredDayAverage;
            data.twoHundredDayAverageChange = result.twoHundredDayAverageChange;
            data.twoHundredDayAverageChangePercent = result.twoHundredDayAverageChangePercent;
            data.marketCap = result.marketCap;
            data.forwardPE = result.forwardPE;
            data.priceToBook = result.priceToBook;
            data.sourceInterval = result.sourceInterval;
            data.exchangeDataDelayedBy = result.exchangeDataDelayedBy;
            data.tradeable = result.tradeable;
            data.marketState = result.marketState;
            data.exchange = result.exchange;
            data.shortName = result.shortName;
            data.longName = result.longName;
            data.messageBoardId = result.messageBoardId;
            data.exchangeTimezoneName = result.exchangeTimezoneName;
            data.exchangeTimezoneShortName = result.exchangeTimezoneShortName;
            data.gmtOffSetMilliseconds = result.gmtOffSetMilliseconds;
            data.market = result.market;
            data.esgPopulated = result.esgPopulated;
            data.displayName = result.displayName;
            data.Symbol = result.symbol;
            return data;
        }
    }
}
