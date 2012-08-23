using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class ObjectParser : BaseParser
    {
        protected override JObject Read(string content)
        {
            return JObject.Parse(content);
        }
    }
}