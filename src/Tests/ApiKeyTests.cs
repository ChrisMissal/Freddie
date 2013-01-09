using NUnit.Framework;

namespace Freddie.Tests
{
    [TestFixture]
    public class ApiKeyTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        [TestCase("982375349857439857324985")]
        [TestCase("982abced375f34985a743c985b7e32ad4985-us")]
        [TestCase("myapikey-us2-d")]
        [TestCase("-myapikey-us2")]
        [TestCase("myapikey-us2", ExpectedException = typeof(AssertionException))]
        public void ApiKey_should_throw_when_created_with_bad_ApiKey(string key)
        {
            Assert.Throws<FreddieException>(() => new ApiKey(key));
        }
    }
}
