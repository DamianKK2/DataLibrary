using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageLibrary.Storages.Factory
{
    public interface IStorageFactory<S,T> where S:ISimpleStorage<T>
    {
        S Create();
    }
}
