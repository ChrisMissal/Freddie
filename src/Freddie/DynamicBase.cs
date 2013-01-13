using System;
using System.Dynamic;
using System.Linq;
using Freddie.RequestProviders;

namespace Freddie
{
    internal abstract class DynamicBase : DynamicObject
    {
        protected readonly Endpoint endpoint;

        protected DynamicBase(Endpoint endpoint)
        {
            this.endpoint = endpoint;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var handlesAttributes = GetType().GetCustomAttributes(typeof (HandlesAttribute), false).Cast<HandlesAttribute>();
            var attribute =
                (from attr in handlesAttributes
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

            ThrowHelper.Message(
                "The method '{1}' does not exist. The currently supported methods for {2} are:{0}{3}",
                Environment.NewLine, binder.Name, GetType().Name.Replace("Dynamic", ""),
                string.Join(Environment.NewLine, handlesAttributes.Select(x => @"    " + x.Method))
                );

            result = default(IRequestProvider);
            return false;
        }
    }
}