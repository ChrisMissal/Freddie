using NUnit.Framework;

namespace Freddie.Tests.Campaign
{
    [TestFixture]
    public class CampaignTests : BaseTester
    {
        [Test]
        public void Can_CreateCampaign()
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

            var createResponse = tree.Do(x => x.Campaign.CampaignCreate(args));

            Assert.True(createResponse.Success);
            Assert.That(createResponse.Content, Is.Not.Null);
        }
    }
}
