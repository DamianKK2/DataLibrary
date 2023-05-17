using DataLibrary.Formatter;
using DataStorageLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageLibrary.Formatters
{
    public class ContentIndexFormatter : IFormatter<ContentIndex>
    {
        private static String SEPARATOR = "     ";
        public string Format(ContentIndex contentIndex)
        {
            return new StringBuilder().Append(contentIndex.Seq).Append(SEPARATOR)
                .Append(contentIndex.Name).Append(SEPARATOR)
                .Append(contentIndex.Page).ToString();
        }
    }
}
