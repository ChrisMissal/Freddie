using System.Collections.Generic;
using System.Dynamic;

namespace Freddie
{
    internal class DynamicResponseContent : DynamicObject
    {
        public DynamicResponseContent()
        {
            Properties = new Dictionary<string, object>();
        }

        internal IDictionary<string, object> Properties { get; private set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (Properties.ContainsKey(binder.Name))
            {
                result = Properties[binder.Name];
                return true;
            }

            result = null;
            return false;
        }
    }
}