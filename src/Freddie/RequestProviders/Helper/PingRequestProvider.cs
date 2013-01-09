namespace Freddie.RequestProviders.Helper
{
    internal class PingRequestProvider : RequestProviderBase
    {
        public PingRequestProvider(Endpoint endpoint) : base(endpoint)
        {
        }

        public override IResponseParser Parser
        {
            get { return new StringParser(); }
        }
    }
}