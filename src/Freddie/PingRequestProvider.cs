using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class PingRequestProvider : RequestProviderBase, IResponseParser
    {
        public PingRequestProvider(Endpoint endpoint) : base(endpoint)
        {
        }

        protected override string Method
        {
            get { return "ping"; }
        }

        public override IResponseParser Parser
        {
            get { return this; } // note: a hack because I didn't want to create another parser class just for ping
        }

        public Response Parse(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var text = reader.ReadToEnd();
                var success = string.Equals(text, "\"everything's chimpy!\"", StringComparison.OrdinalIgnoreCase);
                return new PingResponse(JToken.Parse(text), success);
            }
        }
    }
}