using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataStorageLibrary.ResultMapper
{
    public interface IResultMapper<T>
    {
        T MapResult(IDataRecord dataRecord);
    }
}
