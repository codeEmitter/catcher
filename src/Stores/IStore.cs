using System.Collections.Generic;

namespace Catcher.Stores
{
    public interface IStore
    {
        string Save(string data);
        IEnumerable<string> Read();
    }
}