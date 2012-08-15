using System;
using System.Text.RegularExpressions;

namespace Freddie
{
    public static class Validate
    {
        private static readonly Regex apiRegex = new Regex(@"^(\w*)\-(\w){3}$");

        public static void IsValidApiKey(string apiKey)
        {
            if (!string.IsNullOrWhiteSpace(apiKey) && apiRegex.IsMatch(apiKey))
                return;

            ThrowHelper.InvalidApiKeyFormat(apiKey);
        }

        public static void NotNull(object obj, string paramName, string message)
        {
            if (obj != null)
                return;

            ThrowHelper.NullValue(new ArgumentNullException(paramName), message);
        }
    }
}