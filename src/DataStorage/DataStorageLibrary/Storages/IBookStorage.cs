using DataStorageLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageLibrary.Storages
{
    public interface IBookStorage: ISimpleStorage<Book>
    {
        List<ContentIndex> GetTableOfContent(int id);
    }
}
