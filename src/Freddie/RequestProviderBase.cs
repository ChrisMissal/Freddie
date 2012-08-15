using System;
using System.Net.Http;

namespace Freddie
{
    internal abstract class RequestProviderBase : IRequestProvider
    {
        protected readonly Endpoint endpoint;
        protected readonly IResponseParser parser = new DefaultParser();

        protected RequestProviderBase(Endpoint endpoint)
        {
            this.endpoint = endpoint;
        }

        public virtual HttpRequestMessage GetRequest()
        {
            var relativeUri = "?method=" + Method + "&apikey=" + endpoint.ApiKey;
            if (Args != null) relativeUri += Extensions.ToQueryString(Args);
            var requestUri = new Uri(endpoint.Uri, relativeUri);
            return new HttpRequestMessage(HttpMethod.Post, requestUri);
        }

        protected abstract string Method { get; }

        protected dynamic Args { get; set; }

        public virtual IResponseParser Parser
        {
            get { return parser; }
        }
    }
}