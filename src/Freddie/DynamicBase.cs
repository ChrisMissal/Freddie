using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Freddie.RequestProviders;

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
            var attribute =
                (from attr in GetType().GetCustomAttributes(typeof (HandlesAttribute), false).Cast<HandlesAttribute>()
                 where string.Equals(attr.Method, binder.Name, StringComparison.OrdinalIgnoreCase)
                 select attr).FirstOrDefault();

            if (attribute != null)
            {
                var arguments = new object[] { endpoint, attribute.Method }.Concat(args);

                var genericType = typeof (UniversalRequestProvider<>)
                    .MakeGenericType(attribute.ParserType);

                result = Activator.CreateInstance(genericType, arguments.ToArray());

                return true;
            }

            if (methods.ContainsKey(binder.Name))
            {
                var array = new object[] { endpoint }.Concat(args).ToArray();

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