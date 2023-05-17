using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageLibrary.Data
{
    public class ContentIndex
    {
        public int Seq { get; }
        public int BookId { get; }
        public String Name { get; }
        public int Page { get; }
        public ContentIndex(int seq, int bookId, String name, int page)
        {
            Seq = seq;
            BookId = bookId;
            Name = name;
            Page = page;
        }
    }
}
