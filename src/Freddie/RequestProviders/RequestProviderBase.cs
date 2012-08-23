using System;
using System.Net.Http;

namespace Freddie.RequestProviders
{
    internal abstract class RequestProviderBase : IRequestProvider
    {
        protected readonly Endpoint endpoint;
        protected readonly IResponseParser parser = new ObjectParser();

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

        public abstract IResponseParser Parser { get; }

        protected dynamic Args { get; set; }

        protected virtual string Method
        {
            get { return GetType().Name.Replace("RequestProvider", "").ToMethodCasing(); }
        }
    }
}