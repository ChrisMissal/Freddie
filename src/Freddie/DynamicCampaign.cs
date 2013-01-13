using Freddie.RequestProviders.Campaign;

namespace Freddie
{
    internal class DynamicCampaign : DynamicBase
    {
        internal DynamicCampaign(Endpoint endpoint) : base(endpoint)
        {
            methods.Add("campaignCreate", typeof(CampaignCreateRequestProvider));
            methods.Add("campaignContent", typeof(CampaignContentRequestProvider));
            methods.Add("campaigns", typeof(CampaignsRequestProvider));
            methods.Add("campaignDelete", typeof(CampaignDeleteRequestProvider));
            methods.Add("campaignPause", typeof(CampaignPauseRequestProvider));
        }
    }
}