using DataLibrary.Param;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.ParamMapper
{
    public interface IParamMapper<T>
    {
        IParam[] MapToParams(T param);
    }
}
