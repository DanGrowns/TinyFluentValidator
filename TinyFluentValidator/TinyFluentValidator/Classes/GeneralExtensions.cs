using System.Text.RegularExpressions;

namespace TinyFluentValidator.Classes
{
    public static class GeneralExtensions
    {
        public static string SplitPascalCaseToString(this string pascalCaseStr, bool usePluralName = false)
        {
            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            var modelWithSpaces = r.Replace(pascalCaseStr, " ");
            var finalChar = pascalCaseStr[^1..];
            
            if (usePluralName)
                return finalChar == "s" ? $"{modelWithSpaces}es" : $"{modelWithSpaces}s";

            return modelWithSpaces;
        }
        
        // TODO: Any code sharing cleanup
    }
}