using Financology.APIFactory;
using Financology.BusinessLogic;
using Financology.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;

namespace Financology.Watchlist
{
    internal class DataManager
    {
        internal static DataManager instance = new DataManager();
        private Dictionary<string, LiveFeedData> dataDict = new Dictionary<string, LiveFeedData>();
        internal Dictionary<int, LiveFeedData> colors = new Dictionary<int, LiveFeedData>();
        internal ObservableCollection<LiveFeedData> liveFeeds = new ObservableCollection<LiveFeedData>();
        private IAPIManager aPIManager = APIProvider.GetAPIManager("Yahoo");
        private int _liveFeedInterval = Convert.ToInt32(ConfigurationManager.AppSettings["LiveFeedInterval"]);
        private Timer timer;
        private List<string> symbols = new List<string>();
        private readonly object _locker = new object();
        private DataManager()
        {
            if(File.Exists(@"symbols.json"))
                using (StreamReader file = File.OpenText(@"symbols.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    symbols = (List<string>)serializer.Deserialize(file, typeof(List<string>));
                }
            
            timer = new Timer(new TimerCallback(TickTimer), null, 0, _liveFeedInterval * 1000);
        }

        private void TickTimer(object state)
        {
            lock (_locker)
            {
                dataDict = aPIManager.GetLiveFeedDictionary(symbols);
            }
            foreach (LiveFeedData data in dataDict.Values)
            {
                int index = liveFeeds.IndexOf(data);
                if (index >= 0)
                    liveFeeds[index] = data;
                else
                {
                    liveFeeds.Add(data);
                    index = liveFeeds.IndexOf(data);
                }
                colors[index] = data;
            }
        }

        internal void AddSymbol(string symbol)
        {
            lock (_locker)
            {
                if(!symbols.Contains(symbol))
                    symbols.Add(symbol);

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(@"symbols.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, symbols);
                }
            }
        }
    }
}
