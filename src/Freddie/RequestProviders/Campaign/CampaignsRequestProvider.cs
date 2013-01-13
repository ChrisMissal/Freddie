namespace Freddie.RequestProviders.Campaign
{
    internal class CampaignsRequestProvider : RequestProviderBase
    {
        public CampaignsRequestProvider(Endpoint endpoint) : base(endpoint)
        {
        }

        public CampaignsRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new ObjectParser(); }
        }
    }
}