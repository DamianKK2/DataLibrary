using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageLibrary.ConnectionProvider.Impl
{
    public abstract class BaseConnectionProvider : IConnectionProvider
    {
        public String ConnectionString { get; }
        public BaseConnectionProvider(String connectionString)
        {
            ConnectionString = connectionString;
        }
        public abstract IDbConnection GetConnection();
    }
}
