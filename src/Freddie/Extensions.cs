using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Freddie
{
    [DebuggerStepThrough]
    internal static class Extensions
    {
        internal static string ToQueryString(this object self)
        {
            return string.Join("&", self
                   .GetType().GetProperties()
                   .Select(x => x.Name + "=" + x.GetValue(self, null))
                   .ToArray());
        }

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
    }
}