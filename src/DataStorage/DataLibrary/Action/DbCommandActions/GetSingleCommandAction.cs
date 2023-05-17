using DataStorageLibrary.ResultMapper;
using DataStorageLibrary.ConnectionProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageLibrary.Action.Impl
{
    public class GetSingleCommandAction<T> : DbCommandAction<T> where T:class
    {
        public IResultMapper<T> ResultMapper { get; }
        public GetSingleCommandAction(IConnectionProvider connectionProvider, String commandText,
             IResultMapper<T> resultMapper)
               : base(connectionProvider, commandText)
        {
            ResultMapper = resultMapper;
        }
        public override T ExecuteCommand(IDbCommand command)
        {
            T result;
            using (IDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                    return result = ResultMapper.MapResult(reader);
                return null;
            }
        }
    }
}
