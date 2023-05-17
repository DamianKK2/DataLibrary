using System;
using System.Collections.Generic;
using System.Text;
using DataStorageLibrary.ResultMapper;
using DataStorageLibrary.Action;
using DataStorageLibrary.Action.Impl;
using DataStorageLibrary.ConnectionProvider;

namespace DataLibrary.Command.Factory.Impl
{
    public class GetMultipleCommandActionFactory<C, T> : QueryCommandActionFactory<GetMultipleCommandAction<T>,IEnumerable<T>,T>
    {
        public GetMultipleCommandActionFactory(IConnectionProvider connectionProvider, IResultMapper<T> resultMapper)
            : base(connectionProvider, resultMapper)
        {}
        public override GetMultipleCommandAction<T> Create(string commandText)
        {
            return new GetMultipleCommandAction<T>(ConnectionProvider, commandText, ResultMapper);
        }
    }
}
