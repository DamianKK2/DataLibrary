using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageLibrary.Storages
{
    public interface ISimpleStorage<T>
    {
        IEnumerable<int> GetAllIds();
        T GetById(int id);
    }
}
