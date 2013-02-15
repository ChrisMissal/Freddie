using System;
using NUnit.Framework;

namespace Freddie.Tests.List
{
    [TestFixture]
    [Category("Integration")]
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
        public void Get_ListAbuseReports()
        {
            var args = new { id = MasterListId };
            var abuseResponse = tree.Do(x => x.List.ListAbuseReports(args));

            Assert.That(abuseResponse.Success, Is.True);

            // brittle assertions
            Assert.That(abuseResponse.Content.items.total.Value, Is.EqualTo(0));
            Assert.That(abuseResponse.Content.items.data, Is.Empty);
        }

        [Test]
        public void Get_ListActivity()
        {
            var args = new { id = MasterListId };
            var activityResponse = tree.Do(x => x.List.ListActivity(args));

            Assert.That(activityResponse.Success, Is.True);
            var firstDay = activityResponse.Content.items[0].day;

            // brittle assertion :(
            Assert.That(DateTime.Parse(firstDay.Value), Is.EqualTo(new DateTime(2012, 8, 23)));
        }

        [Test]
        public void Can_ListClients()
        {
            var args = new { id = MasterListId };
            var clientsResponse = tree.Do(x => x.List.ListClients(args));

            Assert.That(clientsResponse.Success, Is.True);

            Assert.That(clientsResponse.Content.success.desktop, Is.Empty);
            Assert.That(clientsResponse.Content.success.mobile, Is.Empty);
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

        [Test]
        public void Can_listGrowthHistory()
        {
            var growthResponse = tree.Do(x => x.List.ListGrowthHistory(new { id = MasterListId }));

            Assert.That(growthResponse.Success, Is.True);
            Assert.That(growthResponse.Content.items[0].optins.Value, Is.EqualTo("2")); // uggh, this should be an int, not a string
        }

        [Test]
        public void Can_listLocations()
        {
            var args = new
            {
                id = MasterListId,
            };
            var locationResponse = tree.Do(x => x.List.listLocations(args));

            Assert.That(locationResponse.Success, Is.True);
            Assert.That(locationResponse.Content.items, Is.Not.Empty);
        }

        [Test]
        public void Can_listMemberActivity()
        {
            var args = new
            {
                id = MasterListId,
                // brittle data for test :(
                email_address = "chris.missal+e426a872-9303-4d35-bc74-3ab09daa2693@gmail.com",
            };
            var activityResponse = tree.Do(x => x.List.listMemberActivity(args));

            Assert.That(activityResponse.Success, Is.True);
            Assert.That(activityResponse.Content.items, Is.Not.Empty);
        }

        [Test]
        public void Can_listMemberInfo()
        {
            var args = new
            {
                id = MasterListId,
                // brittle data for test :(
                email_address = "chris.missal+e426a872-9303-4d35-bc74-3ab09daa2693@gmail.com",
            };
            var infoResponse = tree.Do(x => x.List.listMemberInfo(args));

            Assert.That(infoResponse.Success, Is.True);
            Assert.That(infoResponse.Content.items, Is.Not.Empty);
        }

        [Test]
        public void Can_listMembers()
        {
            var args = new
            {
                id = MasterListId,
                status = "subscribed",
            };
            var membersResponse = tree.Do(x => x.List.listMembers(args));

            Assert.That(membersResponse.Success, Is.True);
            Assert.That(membersResponse.Content.items, Is.Not.Empty);
        }

        [Test]
        public void Can_listUnsubscribe()
        {
            var email = "chris.missal+" + Guid.NewGuid().ToString("n") + "@gmail.com";
            var args = new
            {
                id = MasterListId,
                double_optin = false,
                update_existing = false,
                email_address = email,
                send_goodbye = false,
                send_notify = false,
            };

            var subscribe = tree.Do(x => x.List.ListSubscribe(args));
            Assert.That(subscribe.Success, Is.True);

            var unsubscribe = tree.Do(x => x.List.ListUnsubscribe(args));
            Assert.That(unsubscribe.Success, Is.True);
        }

        [Test]
        public void Can_listBatchSubscribe()
        {
            var args = new
            {
                id = MasterListId,
                batch = new []
                    {
                        new { EMAIL = "63e12c3383cc4222bc504bde936f64f6@gmail.com", EMAIL_TYPE = "html" },
                        new { EMAIL = "cbfb9fb6e7e24188aea129aa47ba08fb@gmail.com", EMAIL_TYPE = "html" },
                        new { EMAIL = "2f0dd9c7f6504d19916c209efbfcf561@gmail.com", EMAIL_TYPE = "html" },
                        new { EMAIL = "c291a94840194c848a2867db5b28b176@gmail.com", EMAIL_TYPE = "html" },
                    },
                double_optin = false,
                update_existing = true,
            };
            var result = tree.Do(x => x.List.listBatchSubscribe(args));

            Assert.That(result.Success, Is.True);
        }
    }
}