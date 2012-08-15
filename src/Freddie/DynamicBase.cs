using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Freddie
{
    internal abstract class DynamicBase : DynamicObject
    {
        protected readonly IDictionary<string, Type> methods = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        protected readonly Endpoint endpoint;

        protected DynamicBase(Endpoint endpoint)
        {
            this.endpoint = endpoint;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (methods.ContainsKey(binder.Name))
            {
                var array = endpoint.Concat(args).ToArray();
                // todo: see what can be done so overloaded ctors don't have to exist
                result = Activator.CreateInstance(methods[binder.Name], array);
                return true;
            }

            ThrowHelper.Message(
                "The method '{1}' does not exist. The currently supported methods for {2} are:{0}{3}",
                Environment.NewLine, binder.Name, GetType().Name.Replace("Dynamic", ""),
                string.Join(Environment.NewLine, methods.Select(m => @"    " + m.Key))
                );

            result = default(IRequestProvider);
            return false;
        }
    }
}