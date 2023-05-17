using DataStorageLibrary.Action;
using DataStorageLibrary.Action.Impl;
using DataStorageLibrary.ConnectionProvider;
using DataStorageLibrary.Data;
using DataStorageLibrary.ResultMapper.Impl;
using DataStorageLibrary.ResultMappers;
using DataStorageLibrary.Storages.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageLibrary.Storages.Factory.Impl
{
    public class BookStorageFactory : SimpleStorageFactory<IBookStorage, Book>
    {
        private static String TABLE_NAME = "Books";
        private static String DATA_PARAMETERS = "name,author,isbn,year";
        protected static string GET_CONTENT_INDEX_COMMAND = "select * from Books b inner join content_index c on b.id=c.book_id where id=@id order by seq";
        public BookStorageFactory(IConnectionProvider connectionProvider)
            : base(connectionProvider, new IntResultMapper(), new BookMetadataRM(), TABLE_NAME, DATA_PARAMETERS)
        { }
        public override IBookStorage Create()
        {
            return new BookStorage(CreateAllIdAction(), CreateByIdAction(), CreateGetContentIndexAction());
        }
        private IAction<IEnumerable<ContentIndex>> CreateGetContentIndexAction()
        {
            return new GetMultipleCommandAction<ContentIndex>(ConnectionProvider, GET_CONTENT_INDEX_COMMAND, new ContentIndexRM());
        }

    }
}
