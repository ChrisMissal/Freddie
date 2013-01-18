using System;
using System.Configuration;
using Freddie.RequestProviders;

namespace Freddie
{
    public class Tree
    {
        private readonly RequestExecutor _executor = new RequestExecutor();

        public static Tree Create()
        {
            var key = ConfigurationManager.AppSettings.Get("Freddie.ApiKey");
            Validate.NotNull(key, "Freddie.ApiKey", "Create a Tree by passing in the ApiKey or set it in your config file with key 'Freddie.ApiKey' and use Tree.Create().");

            return new Tree(key);
        }

        public Tree(string apiKey)
        {
            Endpoint = new Endpoint(new ApiKey(apiKey));
            Helper = new DynamicHelper(Endpoint);
            List = new DynamicList(Endpoint);
            Campaign = new DynamicCampaign(Endpoint);
            Template = new DynamicTemplate(Endpoint);
        }

        private Endpoint Endpoint { get; set; }

        public dynamic List { get; private set; }

        public dynamic Helper { get; private set; }

        public dynamic Campaign { get; private set; }

        public dynamic Template { get; private set; }

        public IResponse Do(Func<Tree, object> func)
        {
            return _executor.Send((IRequestProvider)func(this));
        }
    }
}