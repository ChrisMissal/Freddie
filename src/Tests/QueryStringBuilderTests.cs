using Freddie;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class QueryStringBuilderTests
    {
        [Test]
        public void Can_build_merge_vars_correctly()
        {
            var builder = new QueryStringBuilder();
            var expected = @"&id=123&update=True&email_address=your.name%2bmore%40domain.com&merge_vars[fname]=chris&merge_vars[lname]=missal";
            var member = new
            {
                id = 123,
                update = true,
                email_address = "your.name+more@domain.com",
                merge_vars = new { fname = "chris", lname = "missal" }
            };

            var queryString = builder.Build(member);

            Assert.That(queryString, Is.EqualTo(expected));
        }
    }
}