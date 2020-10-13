using Financology.APIFactory;
using Financology.BusinessLogic;
using Financology.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Text;
using System.Threading;

namespace Financology.Watchlist
{
    internal class DataManager
    {
        internal Dictionary<string, LiveFeedData> dataDict = new Dictionary<string, LiveFeedData>();
        internal ObservableCollection<LiveFeedData> liveFeeds = new ObservableCollection<LiveFeedData>();
        private IAPIManager aPIManager = APIProvider.GetAPIManager("Yahoo");
        private int _liveFeedInterval = Convert.ToInt32(ConfigurationManager.AppSettings["LiveFeedInterval"]);
        private Timer timer;
        public DataManager()
        {
            timer = new Timer(new TimerCallback(TickTimer), null, 0, _liveFeedInterval * 1000);
            dataDict = aPIManager.GetLiveFeedDictionary(new List<string>() { "Idea.ns", "rain.ns", "infy.ns", "tcs.ns" });
            foreach (LiveFeedData data in dataDict.Values)
            {
                liveFeeds.Add(data);
            }
            //dataDict.Add("AAPL", new LiveFeedData());
        }

        private void TickTimer(object state)
        {
            dataDict = aPIManager.GetLiveFeedDictionary(new List<string>() { "AAPL", "MSFT", "GOOG", "tcs.ns" });
            
            foreach (LiveFeedData data in dataDict.Values)
            {
                liveFeeds.Add(data);
            }
        }
    }
}
