using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageLibrary.ConnectionProvider
{
    public interface IConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
