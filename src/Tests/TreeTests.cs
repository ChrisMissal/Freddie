using System;
using Freddie;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TreeTests
    {
        private readonly Tree tree = new Tree("___");

        [Test]
        public void Can_get_Lists()
        {
            var listsResponse = tree.Do(x => x.List.Lists());

            Assert.True(listsResponse.Success);
        }

        [Test]
        public void Can_Ping()
        {
            var ping = tree.Do(x => x.Helper.Ping());

            Assert.That(ping.Content.ToString(), Is.EqualTo("Everything's Chimpy!"));
        }

        [Test]
        public void Can_GetAccountDetails()
        {
            var details = tree.Do(x => x.Helper.GetAccountDetails());

            Assert.That(details.Content, Is.Not.Null);
        }

        [Test]
        public void Can_ListSubscribe()
        {
            dynamic stuff = new { id = "1239214", email_address = "example@domain.com" };
            var details = tree.Do(x => x.List.ListSubscribe(stuff));

            Assert.That(details.Success, Is.True);
        }

        [Test]
        public void Get_List_missing_method_should_throw_helpful_exception()
        {
            var exception = Assert.Throws<FreddieException>(() => tree.List.SomethingMadeUp());
            Console.WriteLine(exception.Message);
            Assert.That(exception.Message.StartsWith("The method 'SomethingMadeUp' does not exist. The currently supported methods for List are:"));
            Assert.That(exception.Message, Contains.Substring("listSubscribe"));
        }
    }
}