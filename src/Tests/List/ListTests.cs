using System;
using NUnit.Framework;

namespace Freddie.Tests.List
{
    [TestFixture]
    public class ListTests : BaseTester
    {
        [Test]
        public void Can_get_ListStaticSegments()
        {
            var listsResponse = tree.Do(x => x.List.ListStaticSegments(new { id = MasterListId } ));

            Assert.True(listsResponse.Success);
            Assert.That(listsResponse.Content.items[0].name.Value, Is.EqualTo("Admins"));
        }

        [Test]
        public void Can_get_Lists()
        {
            var listsResponse = tree.Do(x => x.List.Lists());

            Assert.True(listsResponse.Success);
            Assert.That(listsResponse.Content.total.Value, Is.EqualTo(1));
        }

        [Test]
        public void Can_ListSubscribe()
        {
            dynamic stuff = new {
                id = MasterListId,
                double_optin = false,
                update_existing = true,
                email_address = "chris.missal+freddie@gmail.com" };

            var details = tree.Do(x => x.List.ListSubscribe(stuff));

            Assert.True(details.Success);
            Assert.That(details.Content.success.Value, Is.EqualTo(true));
        }

        [Test]
        public void Get_List_missing_method_should_throw_helpful_exception()
        {
            var exception = Assert.Throws<FreddieException>(() => tree.List.SomethingMadeUp());
            Console.WriteLine(exception.Message);
            Assert.That(exception.Message.StartsWith("The method 'SomethingMadeUp' does not exist. The currently supported methods for List are:"));
            Assert.That(exception.Message, Contains.Substring("listSubscribe"));
        }

        [Test]
        public void Can_ListUpdate()
        {
            var member = new {
                id = MasterListId,
                email_address = "chris.missal+freddie@gmail.com",
                merge_vars = new { fname = "chriss", lname = "missal" }
            };
            var details = tree.Do(x => x.List.ListUpdateMember(member));

            Assert.That(details.Success, Is.True);
        }
    }
}