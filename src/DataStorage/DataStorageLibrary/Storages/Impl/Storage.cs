using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Param.Impl;
using DataLibrary.ParamMapper;
using DataStorageLibrary.Action;
using DataStorageLibrary.ConnectionProvider;

namespace DataStorageLibrary.Storages.Impl
{
    public class Storage<T> : SimpleStorage<T>, IStorage<T>
    {
        public IAction<int> RemoveByIdAction { get; }
        public IAction<int> AddAction { get; }
        public IParamMapper<T> ParamMapper { get; }
        public Storage(IAction<IEnumerable<int>> getAllIdAction, IAction<T> getByIdAction,
            IAction<int> removeByIdAction, IAction<int> addAction, IParamMapper<T> paramMapper) :base(getAllIdAction,getByIdAction)
        {
            RemoveByIdAction = removeByIdAction;
            AddAction = addAction;
            ParamMapper = paramMapper;
        }
        
        public void RemoveById(int id)
        {
            RemoveByIdAction.Execute(new Param("@id", id));
        }

        public void Add(T item)
        {
            AddAction.Execute(ParamMapper.MapToParams(item));
        }
    }
}
