using DataStorageLibrary.Action;
using DataStorageLibrary.Action.Impl;
using DataStorageLibrary.ConnectionProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataLibrary.Command.Impl
{
    public class NonQueryCommandAction : DbCommandAction<int>
    {
        public NonQueryCommandAction(IConnectionProvider connectionProvider, String commandText)
               : base(connectionProvider, commandText){ }
        public override int ExecuteCommand(IDbCommand command)
        {
            return command.ExecuteNonQuery();
        }
    }
}
