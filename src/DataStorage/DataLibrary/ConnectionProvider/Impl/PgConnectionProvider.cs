using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageLibrary.ConnectionProvider.Impl
{
    public class PgConnectionProvider:BaseConnectionProvider
    {
        public PgConnectionProvider(String connectionString):base(connectionString){}

        public override IDbConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
