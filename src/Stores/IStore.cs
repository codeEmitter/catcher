using System.Collections.Generic;

namespace src.Stores
{
    public interface IStore
    {
        string Save(string data);
        IEnumerable<string> Read();
    }
}