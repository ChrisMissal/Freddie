namespace Freddie.RequestProviders.Campaign
{
    internal class CampaignCreateRequestProvider : RequestProviderBase
    {
        public CampaignCreateRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new StringParser(); }
        }
    }
}
