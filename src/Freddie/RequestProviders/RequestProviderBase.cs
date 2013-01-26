namespace Freddie.RequestProviders
{
    internal abstract class RequestProviderBase : IRequestProvider
    {
        protected readonly Endpoint endpoint;
        protected readonly IResponseParser parser = new ObjectParser();
        protected readonly QueryStringBuilder builder = new QueryStringBuilder();

        protected RequestProviderBase(Endpoint endpoint)
        {
            this.endpoint = endpoint;
        }

        public virtual string GetRequest()
        {
            var relativeUri = "?method=" + Method + "&apikey=" + endpoint.ApiKey;

            if (Args != null)
                relativeUri += builder.Build(Args);

            return relativeUri;
        }

        public abstract IResponseParser Parser { get; }

        protected dynamic Args { get; set; }

        protected virtual string Method
        {
            get { return GetType().Name.Replace("RequestProvider", "").ToMethodCasing(); }
        }
    }
}