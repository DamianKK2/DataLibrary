using DataStorageLibrary.Action;
using DataStorageLibrary.Action.Impl;
using DataStorageLibrary.ConnectionProvider;
using DataStorageLibrary.ResultMapper;
using DataStorageLibrary.Storages.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageLibrary.Storages.Factory.Impl
{
    public abstract class SimpleStorageFactory<S, T> : IStorageFactory<S, T> where S : ISimpleStorage<T> where T : class
    {
        protected static string GET_ALL_IDS_COMMAND = "select id from @tableName";
        protected static string GET_BY_ID_COMMAND = "select @dataParameters from @tableName where id=@id";
        protected IConnectionProvider ConnectionProvider { get; }
        protected IResultMapper<int> IntResultMapper { get; }
        protected IResultMapper<T> StorableResultMapper { get; }
        protected String TableName { get; }
        protected String DataParameters { get; }
        public SimpleStorageFactory(IConnectionProvider connectionProvider, IResultMapper<int> intResultMapper, IResultMapper<T> storableResultMapper, String tableName, String dataParameters)
        {
            ConnectionProvider = connectionProvider;
            IntResultMapper = intResultMapper;
            StorableResultMapper = storableResultMapper;
            TableName = tableName;
            DataParameters = dataParameters;
        }

        protected IAction<IEnumerable<int>> CreateAllIdAction()
        {
            return new GetMultipleCommandAction<int>(ConnectionProvider, GET_ALL_IDS_COMMAND.Replace("@tableName",TableName), IntResultMapper);
        }

        protected IAction<T> CreateByIdAction()
        {
            return new GetSingleCommandAction<T>(ConnectionProvider, GET_BY_ID_COMMAND.Replace("@dataParameters", DataParameters).Replace("@tableName", TableName), StorableResultMapper);
        }

        public abstract S Create();
    }
}
