using System;
using System.Collections.Generic;
using System.Text;
using DataStorageLibrary.ResultMapper;
using DataStorageLibrary.Action;
using DataStorageLibrary.ConnectionProvider;

namespace DataLibrary.Command.Factory.Impl
{
    public abstract class QueryCommandActionFactory<C, T, R> : ICommandActionFactory<C, T> where C:IAction<T>
    {
        protected IConnectionProvider ConnectionProvider { get; }
        protected IResultMapper<R> ResultMapper { get; }
        public QueryCommandActionFactory(IConnectionProvider connectionProvider, IResultMapper<R> resultMapper)
        {
            ConnectionProvider = connectionProvider;
            ResultMapper = resultMapper;
        }

        public abstract C Create(string commandText);
    }
}
