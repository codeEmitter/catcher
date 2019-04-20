using System;
using System.Collections.Generic;

namespace Catcher.Stores.Mem
{
    
    public class SimpleListStore : IStoreInMemory
    {
        private readonly IDictionary<DateTime, string> _store = new Dictionary<DateTime, string>();

        public string Save(string data)
        {
            if (!_store.Values.Contains(data)) _store.Add(DateTime.Now, data);
            return data;
        }

        public IDictionary<DateTime, string> Read() => _store;

        public int Clear()
        {
            var cnt = _store.Count;
            _store.Clear();
            return cnt;
        }
    }
}