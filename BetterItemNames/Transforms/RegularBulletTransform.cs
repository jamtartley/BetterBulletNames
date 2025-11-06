using System.Text.RegularExpressions;

namespace BetterItemNames
{
    public class RegularBulletTransform : Transform
    {
        protected override Regex NameMatcher => new Regex(@"^(.+?)\s+Bullet\s*\(([^)]+)\)\s*$");

        public override string? Replacer(string originalName)
        {
            var match = NameMatcher.Match(originalName);
            if (match.Success)
            {
                string prefix = match.Groups[1].Value.Trim();
                string caliber = match.Groups[2].Value.Trim();

                return $"({caliber}) {prefix}";
            }

            return null;
        }
    }
}

