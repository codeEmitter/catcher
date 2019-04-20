using System;
using System.Collections.Generic;

namespace Catcher.Stores
{
    public interface IStore
    {
        string Save(string data);
        IDictionary<DateTime, string> Read();
        int Clear();
    }

    public interface IStoreInMemory : IStore {}

}