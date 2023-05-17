using DataStorageLibrary.ResultMapper;
using DataStorageLibrary.Action;
using DataStorageLibrary.Action.Impl;
using DataStorageLibrary.ConnectionProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Command.Factory.Impl
{
    public class GetSingleCommandActionFactory<T> : QueryCommandActionFactory<GetSingleCommandAction<T>, T, T> where T:class
    {
        public GetSingleCommandActionFactory(IConnectionProvider connectionProvider, IResultMapper<T> resultMapper)
            : base(connectionProvider, resultMapper)
        { }
        public override GetSingleCommandAction<T> Create(string commandText)
        {
            return new GetSingleCommandAction<T>(ConnectionProvider, commandText, ResultMapper);
        }
    }
}
