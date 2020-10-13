using Financology.BusinessLogic;
using System;

namespace Financology.APIFactory
{
    public class APIProvider
    {
        public static IAPIManager GetAPIManager(string APIType)
        {
            switch (APIType)
            {
                case "Yahoo":
                    return new YahooAPIManager.APIManager();
                default:
                    return new YahooAPIManager.APIManager();
            }
        }
    }
}
