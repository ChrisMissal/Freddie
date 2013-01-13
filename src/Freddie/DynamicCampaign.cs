namespace Freddie
{
    [Handles("campaignCreate", typeof(StringParser))]
    [Handles("campaignContent", typeof(ObjectParser))]
    [Handles("campaigns", typeof(ObjectParser))]
    [Handles("campaignDelete", typeof(BooleanParser))]
    [Handles("campaignPause", typeof(BooleanParser))]
    [Handles("campaignReplicate", typeof(BooleanParser))]
    [Handles("campaignResume", typeof(BooleanParser))]
    [Handles("campaignSchedule", typeof(BooleanParser))]
    [Handles("campaignScheduleBatch", typeof(BooleanParser))]
    [Handles("campaignSendNow", typeof(BooleanParser))]
    [Handles("campaignSendTest", typeof(BooleanParser))]
    [Handles("campaignTemplateContent", typeof(ArrayParser))]
    [Handles("campaignUnschedule", typeof(BooleanParser))]
    [Handles("campaignUpdate", typeof(BooleanParser))]
    internal class DynamicCampaign : DynamicBase
    {
        internal DynamicCampaign(Endpoint endpoint) : base(endpoint)
        {
        }
    }
}