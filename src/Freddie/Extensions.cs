using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Freddie
{
    [DebuggerStepThrough]
    internal static class Extensions
    {
        internal static IEnumerable<object> Concat(this object self, params object[] args)
        {
            yield return self;
            foreach (var arg in args)
                yield return arg;
        }

        internal static string SubstringAfter(this string self, string delimiter)
        {
            var startIndex = self.IndexOf(delimiter, StringComparison.Ordinal) + delimiter.Length;
            return self.Substring(startIndex, self.Length - startIndex);
        }

        internal static string ToMethodCasing(this string self)
        {
            return self.Substring(0, 1).ToLower() + self.Substring(1);
        }
    }
}