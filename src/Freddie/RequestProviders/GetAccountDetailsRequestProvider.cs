namespace Freddie.RequestProviders
{
    internal class GetAccountDetailsRequestProvider : RequestProviderBase
    {
        public GetAccountDetailsRequestProvider(Endpoint endpoint) : base(endpoint)
        {
        }

        public override IResponseParser Parser
        {
            get { return new ObjectParser(); }
        }
    }
}