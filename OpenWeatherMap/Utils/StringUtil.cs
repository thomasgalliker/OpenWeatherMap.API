namespace OpenWeatherMap.Utils
{
    internal static class StringUtil
    {
        internal static string ReplaceWithWildcardChars(string input, string stringToReplace)
        {
            if (input == null)
            {
                return null;
            }

            return input.Replace(stringToReplace, new string('*', input.Length));
        }
    }
}
