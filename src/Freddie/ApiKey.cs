namespace Freddie
{
    internal class ApiKey
    {
        private readonly string _apiKey;
        private readonly string _dc;

        internal ApiKey(string apiKey)
        {
            Validate.IsValidApiKey(apiKey);

            _apiKey = apiKey;
            _dc = apiKey.SubstringAfter("-");
        }

        internal string APIKey
        {
            get { return _apiKey; }
        }

        internal string Dc
        {
            get { return _dc; }
        }
    }
}