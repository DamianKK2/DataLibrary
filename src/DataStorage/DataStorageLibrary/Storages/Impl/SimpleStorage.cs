using DataLibrary.Param.Impl;
using DataStorageLibrary.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageLibrary.Storages.Impl
{
    public class SimpleStorage<T>:ISimpleStorage<T>
    {
        public IAction<IEnumerable<int>> GetAllIdAction { get; }
        public IAction<T> GetByIdAction { get; }
        public SimpleStorage(IAction<IEnumerable<int>> getAllIdAction, IAction<T> getByIdAction)
        {
            GetAllIdAction = getAllIdAction;
            GetByIdAction = getByIdAction;
        }
        public IEnumerable<int> GetAllIds()
        {
            return GetAllIdAction.Execute();
        }

        public T GetById(int id)
        {
            return GetByIdAction.Execute(new Param("@id", id));
        }
    }
}
