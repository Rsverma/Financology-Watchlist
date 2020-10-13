using Financology.APIFactory;
using Financology.BusinessLogic;
using Financology.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Financology.Watchlist
{
    internal class DataManager
    {
        internal Dictionary<string, LiveFeedData> dataDict = new Dictionary<string, LiveFeedData>();
        internal ObservableCollection<LiveFeedData> liveFeeds = new ObservableCollection<LiveFeedData>();
        private IAPIManager aPIManager = APIProvider.GetAPIManager("Yahoo");

        public DataManager()
        {
            dataDict = aPIManager.GetLiveFeedDictionary(new List<string>() { "AAPL" });
            foreach (LiveFeedData data in dataDict.Values)
            {
                liveFeeds.Add(data);
            }
            //dataDict.Add("AAPL", new LiveFeedData());
        }
    }
}
