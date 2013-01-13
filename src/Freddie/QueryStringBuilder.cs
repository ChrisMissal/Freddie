using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freddie
{
    class QueryStringBuilder
    {
        private readonly HashSet<string> hashKeys = new HashSet<string>
        {
            "merge_vars", "options", "content"
        };

        public string Build(object value)
        {
            return "&" + string.Join("&", value
                   .GetType().GetProperties()
                   .Select(x => GetQueryString(x.GetValue(value, null), x.Name)).ToArray());
        }

        public string ToHash(object value, string name)
        {
            return string.Join("&", value.GetType().GetProperties()
                .Select(x => string.Format("{2}[{0}]={1}", x.Name, x.GetValue(value, null), name)).ToArray());
        }

        public string GetQueryString(object value, string name)
        {
            if (hashKeys.Contains(name))
                return ToHash(value, name);

            return name + "=" + HttpUtility.UrlEncode(value.ToString());
        }
    }
}
