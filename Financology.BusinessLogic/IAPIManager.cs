using Financology.BusinessObjects;
using System;
using System.Collections.Generic;

namespace Financology.BusinessLogic
{
    public interface IAPIManager
    {
        public Dictionary<string, LiveFeedData> GetLiveFeedDictionary(List<string> symbols);
    }
}
