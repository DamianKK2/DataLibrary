using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataStorageLibrary.ResultMapper;
using DataStorageLibrary.ConnectionProvider;

namespace DataStorageLibrary.Action.Impl
{
    public class GetMultipleCommandAction<T> : DbCommandAction<IEnumerable<T>>
    {
        public IResultMapper<T> ResultMapper { get; }
        public GetMultipleCommandAction(IConnectionProvider connectionProvider, String commandText,
            IResultMapper<T> resultMapper) :base(connectionProvider, commandText)
        {
            ResultMapper = resultMapper;
        }

        public override IEnumerable<T> ExecuteCommand(IDbCommand command)
        {
            List<T> idList = new List<T>();
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    idList.Add(ResultMapper.MapResult(reader));
                }
            }
            return idList;
        }
    }
}
