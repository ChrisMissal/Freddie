using NUnit.Framework;

namespace Freddie.Tests
{
    [TestFixture]
    [Category("Integration")]
    public class PingTests : BaseTester
    {
        [Test]
        public void Can_Ping()
        {
            var ping = tree.Do(x => x.Helper.Ping());

            Assert.That(ping.Content.text.Value, Is.EqualTo("Everything's Chimpy!"));
        }
    }
}