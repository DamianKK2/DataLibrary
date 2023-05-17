using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorageLibrary.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Year { get; set; }
        public Book(string name, string author, string isbn, string year)
        {
            Name = name;
            Author = author;
            Isbn = isbn;
            Year = year;
        }
    }
}
