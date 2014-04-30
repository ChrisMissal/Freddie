namespace Freddie.RequestProviders
{
    using Quiche;

    internal abstract class RequestProviderBase : IRequestProvider
    {
        protected readonly Endpoint endpoint;
        protected readonly IResponseParser parser = new ObjectParser();
        protected readonly Builder builder = new Builder();

        protected RequestProviderBase(Endpoint endpoint)
        {
            this.endpoint = endpoint;
        }

        public virtual string GetRequest()
        {
            if (Args != null)
                return builder.ToQueryString(Args) + "&method=" + Method + "&apikey=" + endpoint.ApiKey;

            return builder.ToQueryString(new { method = Method, apikey = endpoint.ApiKey });
        }

        public abstract IResponseParser Parser { get; }

        protected dynamic Args { get; set; }

        protected virtual string Method
        {
            get { return GetType().Name.Replace("RequestProvider", "").ToMethodCasing(); }
        }
    }
}