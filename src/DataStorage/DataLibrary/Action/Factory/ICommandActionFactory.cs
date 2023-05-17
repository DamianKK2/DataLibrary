using DataStorageLibrary.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Command.Factory
{
    public interface ICommandActionFactory<C,T> where C:IAction<T>
    {
        C Create(String commandText);
    }
}
