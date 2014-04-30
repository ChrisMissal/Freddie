using NUnit.Framework;

namespace Freddie.Tests.Campaign
{
    [TestFixture]
    [Category("Integration")]
    public class CampaignTests : BaseTester
    {
        [Test]
        public void Can_CreateCampaign()
        {
            var args = GetSampleCampaignCreateArgs();

            var createResponse = tree.Do(x => x.Campaign.CampaignCreate(args));

            Assert.True(createResponse.Success);
            Assert.That(createResponse.Content, Is.Not.Null);
        }

        private static object GetSampleCampaignCreateArgs()
        {
            var args = new
            {
                type = "plaintext",
                options = new
                {
                    list_id = MasterListId,
                    subject = "test",
                    from_email = "chris.missal%2BFreddieNET@gmail.com",
                    from_name = "FreddieTEST"
                },
                content = new { text = @"Dear citizen, You are neat! Love Freddie" }
            };
            return args;
        }

        [Test]
        public void Can_get_campaigns()
        {
            var campaignsResponse = tree.Do(x => x.Campaign.Campaigns());

            Assert.True(campaignsResponse.Success);
            Assert.That((int)campaignsResponse.Content.total, Is.GreaterThan(1));
        }

        [Test]
        public void Can_get_campaignContent()
        {
            var campaignsResponse = tree.Do(x => x.Campaign.Campaigns());

            string id = campaignsResponse.Content.data[0].id;
            var args = new { cid = id };
            var campaignContentResponse = tree.Do(x => x.Campaign.CampaignContent(args));

            Assert.True(campaignContentResponse.Success);
        }

        [Test]
        public void Can_campaignDelete()
        {
            var args = GetSampleCampaignCreateArgs();
            var createResponse = tree.Do(x => x.Campaign.CampaignCreate(args));

            string text = createResponse.Content.text;
            var dArgs = new { cid = text };
            var deleteResponse = tree.Do(x => x.Campaign.CampaignDelete(dArgs));

            Assert.True(deleteResponse.Success);
        }

        [Test]
        public void Can_campaignTemplateContent()
        {
            var args = new { cid = "9349a04e77" };
            var templateContentResponse = tree.Do(x => x.Campaign.campaignTemplateContent(args));

            Assert.True(templateContentResponse.Success);
        }
    }
}
