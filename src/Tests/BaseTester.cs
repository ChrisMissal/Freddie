namespace Freddie.Tests
{
    public abstract class BaseTester
    {
        public static string Apikey = "";
        public static string MasterListId = "";

        protected readonly Tree tree = new Tree(Apikey);
    }
}