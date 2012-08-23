using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Freddie
{
    [DebuggerStepThrough]
    internal static class Extensions
    {
        private static string ToMergeVars(this object self)
        {
            return string.Join("&", self.GetType().GetProperties()
                .Select(x => string.Format("merge_vars[{0}]={1}", x.Name, x.GetValue(self, null))).ToArray());
        }

        internal static string ToQueryString(this object self)
        {
            return "&" + string.Join("&", self
                   .GetType().GetProperties()
                   .Select(x => {
                        var value = x.GetValue(self, null);
                        if (x.Name == "merge_vars")
                            return value.ToMergeVars();

                        return x.Name + "=" + HttpUtility.UrlEncode(value.ToString());
                    }).ToArray());
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

        internal static string ToMethodCasing(this string self)
        {
            return self.Substring(0, 1).ToLower() + self.Substring(1);
        }
    }
}