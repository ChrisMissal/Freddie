using System;
using System.Diagnostics;

namespace Freddie
{
    [DebuggerStepThrough]
    internal static class ThrowHelper
    {
        internal static void NullValue(Exception innerException, string message)
        {
            throw new FreddieException(innerException, message);
        }

        internal static void InvalidApiKeyFormat(string apiKey)
        {
            throw new FreddieException("The Api Key '{0}' appears to be invalid, please double check.", apiKey ?? "(null)");
        }

        internal static void Message(string format, params object[] args)
        {
            throw new FreddieException(format, args);
        }
    }
}