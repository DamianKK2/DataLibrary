using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataStorageLibrary.ResultMapper.Impl
{
    public abstract class SingleResultMapper<T> : IResultMapper<T>
    {
        public int ColumnIndex { get; }
        public SingleResultMapper(int columnIndex)
        {
            ColumnIndex = columnIndex;
        }
        public abstract T MapResult(IDataRecord dataRecord);
    }
}
