using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Param;
using DataStorageLibrary.ConnectionProvider;

namespace DataStorageLibrary.Action.Impl
{
    public abstract class DbCommandAction<T> : IAction<T>
    {
        public IConnectionProvider ConnectionProvider { get; }
        public String CommandText { get; }
        public DbCommandAction(IConnectionProvider connectionProvider, String commandText)
        {
            ConnectionProvider = connectionProvider;
            CommandText = commandText;
        }
        public T Execute(params IParam[] parameters)
        {
            T result;
            using (var connection = ConnectionProvider.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    PrepareCommand(command, parameters);
                    result = ExecuteCommand(command);
                }
            }
            return result;
        }
        public virtual void PrepareCommand(IDbCommand command, params IParam[] parameters)
        {
            command.CommandText = CommandText;
            foreach (var param in parameters)
            {
                AddParameter(command, param.Name, param.Value);
            }
        }
        protected void AddParameter(IDbCommand command, String name, object value)
        {
            IDbDataParameter dbParam = command.CreateParameter();
            dbParam.ParameterName = name;
            dbParam.Value = value;
            command.Parameters.Add(dbParam);
        }

        public abstract T ExecuteCommand(IDbCommand command);
    }
}
