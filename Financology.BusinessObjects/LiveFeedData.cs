using System;

namespace Financology.BusinessObjects
{
    public class LiveFeedData
    {
        public string Symbol { get; set; }
        public double Ask { get; set; }
        public double Bid { get; set; }
        public double Last { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Change { get; set; }
        public string Asset { get; set; }
        public string language { get; set; }
        public string region { get; set; }
        public string quoteSourceName { get; set; }
        public bool triggerable { get; set; }
        public string currency { get; set; }
        public long firstTradeDateMilliseconds { get; set; }
        public int priceHint { get; set; }
        public double postMarketChangePercent { get; set; }
        public int postMarketTime { get; set; }
        public double postMarketPrice { get; set; }
        public double postMarketChange { get; set; }
        public double regularMarketChangePercent { get; set; }
        public int regularMarketTime { get; set; }
        public string regularMarketDayRange { get; set; }
        public int regularMarketVolume { get; set; }
        public double regularMarketPreviousClose { get; set; }
        public int bidSize { get; set; }
        public int askSize { get; set; }
        public string fullExchangeName { get; set; }
        public string financialCurrency { get; set; }
        public int averageDailyVolume3Month { get; set; }
        public int averageDailyVolume10Day { get; set; }
        public double fiftyTwoWeekLowChange { get; set; }
        public double fiftyTwoWeekLowChangePercent { get; set; }
        public string fiftyTwoWeekRange { get; set; }
        public double fiftyTwoWeekHighChange { get; set; }
        public double fiftyTwoWeekHighChangePercent { get; set; }
        public double fiftyTwoWeekLow { get; set; }
        public double fiftyTwoWeekHigh { get; set; }
        public int dividendDate { get; set; }
        public int earningsTimestamp { get; set; }
        public int earningsTimestampStart { get; set; }
        public int earningsTimestampEnd { get; set; }
        public double trailingAnnualDividendRate { get; set; }
        public double trailingPE { get; set; }
        public double trailingAnnualDividendYield { get; set; }
        public double epsTrailingTwelveMonths { get; set; }
        public double epsForward { get; set; }
        public double epsCurrentYear { get; set; }
        public double priceEpsCurrentYear { get; set; }
        public long sharesOutstanding { get; set; }
        public double bookValue { get; set; }
        public double fiftyDayAverage { get; set; }
        public double fiftyDayAverageChange { get; set; }
        public double fiftyDayAverageChangePercent { get; set; }
        public double twoHundredDayAverage { get; set; }
        public double twoHundredDayAverageChange { get; set; }
        public double twoHundredDayAverageChangePercent { get; set; }
        public long marketCap { get; set; }
        public double forwardPE { get; set; }
        public double priceToBook { get; set; }
        public int sourceInterval { get; set; }
        public int exchangeDataDelayedBy { get; set; }
        public bool tradeable { get; set; }
        public string marketState { get; set; }
        public string exchange { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public string messageBoardId { get; set; }
        public string exchangeTimezoneName { get; set; }
        public string exchangeTimezoneShortName { get; set; }
        public int gmtOffSetMilliseconds { get; set; }
        public string market { get; set; }
        public bool esgPopulated { get; set; }
        public string displayName { get; set; }
    }
}
