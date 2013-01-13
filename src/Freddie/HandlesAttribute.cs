using System;

namespace Freddie
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class HandlesAttribute : Attribute
    {
        public HandlesAttribute(string method, Type parserType)
        {
            Method = method;
            ParserType = parserType;
        }

        public string Method { get; set; }

        public Type ParserType { get; set; }
    }
}