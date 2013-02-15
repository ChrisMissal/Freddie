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

        internal string Method { get; private set; }

        internal Type ParserType { get; private set; }
    }
}