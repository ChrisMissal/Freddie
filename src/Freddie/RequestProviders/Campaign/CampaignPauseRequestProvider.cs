namespace Freddie.RequestProviders.Campaign
{
    internal class CampaignPauseRequestProvider : RequestProviderBase
    {
        public CampaignPauseRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new BooleanParser(); }
        }
    }
}