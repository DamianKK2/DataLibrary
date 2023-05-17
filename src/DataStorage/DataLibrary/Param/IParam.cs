using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Param
{
    public interface IParam
    {
        String Name { get; }
        object Value { get; }
    }
}
