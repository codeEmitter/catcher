using System.Collections.Generic;

namespace Catcher.Stores
{
    
    public interface IStoreInMemory : IStore {}
    
    public class MemoryStore : IStoreInMemory
    {
        private readonly IList<string> _store = new List<string>();

        public string Save(string data)
        {
            if (!_store.Contains(data)) _store.Add(data);
            return data;
        }

        public IEnumerable<string> Read() => _store;
    }
}