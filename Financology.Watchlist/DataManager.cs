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
using System.Threading.Tasks;

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
        public GridTab _currentUI = null;

        private DataManager()
        {
            if (File.Exists(@"symbols.json"))
                using (StreamReader file = File.OpenText(@"symbols.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    symbols = (List<string>)serializer.Deserialize(file, typeof(List<string>));
                }

            timer = new Timer(new TimerCallback(TickTimer), null, System.Threading.Timeout.Infinite, _liveFeedInterval * 1000);
        }

        private void TickTimer(object state)
        {
            lock (_locker)
            {
                dataDict = aPIManager.GetLiveFeedDictionary(symbols);

                int gridIndex = _currentUI._grid.SelectedIndex;
                foreach (LiveFeedData data in dataDict.Values)
                {
                    if (data.Change > 0)
                        data.isChangePositive = true;
                    else if (data.Change < 0)
                        data.isChangePositive = false;
                    int index = liveFeeds.IndexOf(data);
                    if (index >= 0)
                    {
                        LiveFeedData result = liveFeeds[index];
                        if (result.Ask > data.Ask)
                            data.isAskGreater = true;
                        else if (result.Ask < data.Ask)
                            data.isAskGreater = false;
                        if (result.Last > data.Last)
                            data.isLastGreater = true;
                        else if (result.Last < data.Last)
                            data.isLastGreater = false;
                        if (result.Bid > data.Bid)
                            data.isBidGreater = true;
                        else if (result.Bid < data.Bid)
                            data.isBidGreater = false;
                        liveFeeds[index] = data;
                    }
                    else
                    {
                        liveFeeds.Add(data);
                        index = liveFeeds.IndexOf(data);
                    }
                    _currentUI._grid.SelectedIndex = gridIndex;
                    colors[index + 1] = data;
                }
                if (_currentUI != null)
                    _currentUI._grid.TableControl.Invalidate();
            }
        }

        internal async void AddSymbol(string symbol)
        {
            symbol = symbol.ToUpper();
            await Task.Run(() =>
            {
                timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                lock (_locker)
                {
                    if (!symbols.Contains(symbol))
                        symbols.Add(symbol);

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText(@"symbols.json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, symbols);
                    }
                }
                timer.Change(0, _liveFeedInterval * 1000);
            });
        }


        internal async void DeleteRow(int index)
        {
            await Task.Run(() =>
            {
                timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                lock (_locker)
                {
                    LiveFeedData result = liveFeeds[index];
                    symbols.Remove(result.Symbol);
                    liveFeeds.RemoveAt(index);
                    dataDict.Remove(result.Symbol);
                    //colors.re

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText(@"symbols.json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, symbols);
                    }
                }
                timer.Change(0, _liveFeedInterval * 1000);
            });
        }
    }
}
