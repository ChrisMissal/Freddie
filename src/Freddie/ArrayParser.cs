using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class ArrayParser : BaseParser
    {
        protected override JObject Read(string content)
        {
            var json = @"{""items"": " + content + "}";
            return JObject.Parse(json);
        }
    }
}