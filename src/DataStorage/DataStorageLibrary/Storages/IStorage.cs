using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageLibrary.Storages
{
    public interface IStorage<T>:ISimpleStorage<T>
    {
        void RemoveById(int id);
        void Add(T item);
    }
}
