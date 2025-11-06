using System.Text.RegularExpressions;

namespace BetterItemNames
{
    public class TotemTransform : Transform
    {
        protected override Regex NameMatcher => new Regex(@"^Totem: (.+?)$");

        public override string? Replacer(string originalName)
        {
            var match = NameMatcher.Match(originalName);
            if (match.Success)
            {
                string name = match.Groups[1].Value.Trim();

                return name;
            }

            return null;
        }
    }
}
