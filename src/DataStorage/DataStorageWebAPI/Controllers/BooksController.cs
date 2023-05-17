using DataLibrary.Formatter;
using DataStorageLibrary.Data;
using DataStorageLibrary.Storages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorageWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController:SimpleStorageController<IBookStorage,Book>
    {
        public IFormatter<ContentIndex> ContentIndexFormatter { get; }
        public BooksController(IBookStorage bookStorage, IFormatter<Book> formatter, 
            IFormatter<ContentIndex> contentIndexFormatter) : base(bookStorage, formatter)
        {
            ContentIndexFormatter = contentIndexFormatter;
        }
        [HttpGet("{id}/ContentIndex")]
        [ProducesResponseType(200, Type = typeof(String))]
        [ProducesResponseType(404)]
        public String GetContentIndex(int id)
        {
            var tableOfContentList = DataStorage.GetTableOfContent(id);
            StringBuilder printList = new StringBuilder();
            foreach(var contentIndex in tableOfContentList)
            {
                printList.AppendLine(ContentIndexFormatter.Format(contentIndex));
            }
            return printList.ToString();
        }
    }
}
