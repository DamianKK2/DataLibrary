using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Formatter;
using DataStorageLibrary.Storages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace DataStorageWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class SimpleStorageController<S,T> : ControllerBase where S:ISimpleStorage<T>
    {
        public S DataStorage { get; }
        public IFormatter<T> Formatter { get; }

        public SimpleStorageController(S dataStorage, IFormatter<T> formatter)
        {
            DataStorage = dataStorage;
            Formatter = formatter;
        }
        
        [HttpGet]
        public IEnumerable<int> GetAllIds()
        {
            return DataStorage.GetAllIds();
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(String))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            T item = DataStorage.GetById(id);
            if (item == null)
                return NotFound(String.Format("Obiekt o identyfikatorze {0} nie został znaleziony w bazie.",id));
            return Ok(Formatter.Format(item));
        }
    }
}
