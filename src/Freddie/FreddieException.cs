using System;

namespace Freddie
{
    internal class FreddieException : Exception
    {
        internal FreddieException(Exception innerException, string format, params object[] args) : base(string.Format(format, args), innerException)
        {
        }

        internal FreddieException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        internal FreddieException(string message) : base(message)
        {
        }
    }
}