using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freddie
{
    class QueryStringBuilder
    {
        private readonly HashSet<string> structArrays = new HashSet<string>
        {
            "batch",
        };
        private readonly HashSet<string> hashKeys = new HashSet<string>
        {
            "merge_vars", "options", "content", "values",
        };

        public string Build(object value)
        {
            return "&" + string.Join("&", value
                   .GetType().GetProperties()
                   .Select(x => GetQueryString(x.GetValue(value, null), x.Name)).ToArray());
        }

        public string ToStructArray(IEnumerable value, string name)
        {
            var items = new List<string>();
            int index = 0;
            foreach (var val in value)
            {
                foreach (var property in val.GetType().GetProperties())
                {
                    var itemValue = property.GetValue(val, null);
                    var item = string.Format("{0}[{1}][{2}]={3}", name, index, property.Name, itemValue);
                    items.Add(item);
                }
                index++;
            }
            return string.Join("&", items);
            //return string.Join("&", value.GetType().GetProperties()
            //    .Select((x, i) => string.Format("{2}[{0}][{3}]={1}", x.Name, x.GetValue(value, null), name, i)).ToArray());
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

            if (structArrays.Contains(name))
                return ToStructArray((IEnumerable)value, name);

            return name + "=" + HttpUtility.UrlEncode(value.ToString());
        }
    }
}
