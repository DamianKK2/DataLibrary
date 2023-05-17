using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Param.Impl
{
    public class Param : IParam
    {
        public string Name { get; }
        public object Value { get; }
        public Param(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
