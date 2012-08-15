using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class PingResponse : Response
    {
        private readonly bool _success;

        internal PingResponse(JToken content, bool success) : base(content)
        {
            _success = success;
        }

        public override bool Success
        {
            get { return _success; }
        }
    }
}