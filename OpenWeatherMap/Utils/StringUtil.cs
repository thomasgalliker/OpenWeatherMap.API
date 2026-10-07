namespace OpenWeatherMap.Utils
{
    internal static class StringUtil
    {
        internal static string ReplaceWithWildcardChars(string input, string? stringToReplace)
        {
            if (string.IsNullOrEmpty(stringToReplace))
            {
                return input;
            }

            return input.Replace(stringToReplace, new string('*', input.Length));
        }
    }
}
