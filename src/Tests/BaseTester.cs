using System.Configuration;
using NUnit.Framework;

namespace Freddie.Tests
{
    [SetUpFixture]
    public class MailchimpSetUpFixture
    {
        public MailchimpSetUpFixture()
        {
            BaseTester.Apikey = ConfigurationManager.AppSettings["ApiKey"];
            BaseTester.MasterListId = ConfigurationManager.AppSettings["MasterListId"];
        }
    }

    public abstract class BaseTester
    {
        public static string Apikey = "";
        public static string MasterListId = "";

        protected readonly Tree tree = new Tree(Apikey);
    }
}