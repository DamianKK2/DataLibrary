using DataLibrary.Formatter;
using DataStorageLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Formatters
{
    public class BookMetadataFormatter : IFormatter<Book>
    {
        private static String SEPARATOR = ", ";
        public string Format(Book book)
        {
            return new StringBuilder(book.Name).Append(SEPARATOR)
                .Append(book.Author).Append(SEPARATOR)
                .Append(book.Isbn).Append(SEPARATOR)
                .Append(book.Year).ToString();
        }
    }
}
