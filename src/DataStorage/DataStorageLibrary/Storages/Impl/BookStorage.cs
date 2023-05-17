using DataLibrary.Param.Impl;
using DataStorageLibrary.Action;
using DataStorageLibrary.ConnectionProvider;
using DataStorageLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageLibrary.Storages.Impl
{
    public class BookStorage:SimpleStorage<Book>,IBookStorage
    {
        public IAction<IEnumerable<ContentIndex>> GetContentIndexAction { get; }
        public BookStorage(IAction<IEnumerable<int>> getAllIdCommand, IAction<Book> getByIdCommand,
            IAction<IEnumerable<ContentIndex>> getContentIndexAction) : base(getAllIdCommand, getByIdCommand)
        {
            GetContentIndexAction = getContentIndexAction;
        }
        public List<ContentIndex> GetTableOfContent(int id)
        {
            return GetContentIndexAction.Execute(new Param("@id", id)).ToList();
        }
    }
}
