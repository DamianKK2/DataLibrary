using DataStorageLibrary.Data;
using DataStorageLibrary.ResultMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataStorageLibrary.ResultMappers
{
    public class BookMetadataRM : IResultMapper<Book>
    {
        public Book MapResult(IDataRecord dataRecord)
        {
            return new Book(dataRecord.GetString(dataRecord.GetOrdinal("name")),
                dataRecord.GetString(dataRecord.GetOrdinal("author")),
                dataRecord.GetString(dataRecord.GetOrdinal("isbn")),
                dataRecord.GetString(dataRecord.GetOrdinal("year")));
        }
    }
}
