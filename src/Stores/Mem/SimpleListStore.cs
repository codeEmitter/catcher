using System.Collections.Generic;

namespace Catcher.Stores.Mem
{
    
    public class SimpleListStore : IStoreInMemory
    {
        private readonly IList<string> _store = new List<string>();

        public string Save(string data)
        {
            if (!_store.Contains(data)) _store.Add(data);
            return data;
        }

        public IEnumerable<string> Read() => _store;
        public int Clear()
        {
            var cnt = _store.Count;
            _store.Clear();
            return cnt;
        }
    }
}