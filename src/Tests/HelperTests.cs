using NUnit.Framework;

namespace Freddie.Tests
{
    [TestFixture]
    [Category("Integration")]
    public class HelperTests : BaseTester
    {
        [Test]
        public void Can_GetAccountDetails()
        {
            var details = tree.Do(x => x.Helper.GetAccountDetails());

            Assert.That(details.Content, Is.Not.Null);
            Assert.That(details.Content.contact.fname.Value, Is.EqualTo("Chris"));
            Assert.True(details.Success);
        }
    }
}