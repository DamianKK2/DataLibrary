using DataLibrary.Param;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageLibrary.Action
{
    public interface IAction<T>
    {
        T Execute(params IParam[] parameters);
    }
}
