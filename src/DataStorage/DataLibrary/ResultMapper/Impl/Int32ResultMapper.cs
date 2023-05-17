using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataStorageLibrary.ResultMapper.Impl
{
    public class IntResultMapper : IResultMapper<int>
    {
        public int MapResult(IDataRecord dataRecord)
        {
            return dataRecord.GetInt32(0);
        }
    }
}
