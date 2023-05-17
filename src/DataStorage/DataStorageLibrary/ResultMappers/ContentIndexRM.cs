using DataStorageLibrary.Data;
using DataStorageLibrary.ResultMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataStorageLibrary.ResultMappers
{
    public class ContentIndexRM:IResultMapper<ContentIndex>
    {
        public ContentIndex MapResult(IDataRecord dataRecord)
        {
            return new ContentIndex(dataRecord.GetInt32(dataRecord.GetOrdinal("seq")),
                dataRecord.GetInt32(dataRecord.GetOrdinal("book_id")),
                dataRecord.GetString(dataRecord.GetOrdinal("cname")),
                dataRecord.GetInt32(dataRecord.GetOrdinal("page")));
        }
    }
}
