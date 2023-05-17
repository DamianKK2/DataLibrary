using DataLibrary.Param;
using DataLibrary.Param.Impl;
using DataLibrary.ParamMapper;
using DataStorageLibrary.Data;

namespace DataStorageLibrary.ParamMappers
{
    public class AddBookParamMapper : IParamMapper<Book>
    {
        public IParam[] MapToParams(Book book)
        {
            return new IParam[]
            {
                new Param("name",book.Name),
                new Param("author",book.Author),
                new Param("isbn",book.Isbn),
                new Param("year",book.Year)
            };
        }
    }
}
