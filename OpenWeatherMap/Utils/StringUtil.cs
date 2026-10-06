using System.Diagnostics.CodeAnalysis;

namespace OpenWeatherMap.Utils
{
    internal static class StringUtil
    {
        [return: NotNullIfNotNull(nameof(stringToReplace))]
        internal static string? ReplaceWithWildcardChars(string input, string? stringToReplace)
        {
            if (string.IsNullOrEmpty(stringToReplace))
            {
                return input;
            }

            return input.Replace(stringToReplace, new string('*', input.Length));
        }
    }
}
