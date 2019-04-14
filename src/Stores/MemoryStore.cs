using System.Collections.Generic;
using System.Linq;

namespace src.Stores
{
    
    public interface IStoreInMemory : IStore {}
    
    public class MemoryStore : IStoreInMemory
    {
        private readonly IList<string> _store = new List<string>();

        public string Save(string data)
        {
            _store.Add(data);
            return data;
        }

        public IEnumerable<string> Read()
        {
            return _store;
        }
    }
}