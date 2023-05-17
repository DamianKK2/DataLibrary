using DataLibrary.Formatter;
using DataStorageLibrary.Storages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorageWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class StorageController<S, T> : SimpleStorageController<S, T> where S : IStorage<T>
    {
        public StorageController(S dataStorage, IFormatter<T> formatter) :base(dataStorage, formatter)
        {}
        
        [HttpPut("{id}")]
        public void Put([FromBody]T item)
        {
            DataStorage.Add(item);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DataStorage.RemoveById(id);
        }
    }
}
