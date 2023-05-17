using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Formatter
{
    public interface IFormatter<T>
    {
        String Format(T input);
    }
}
