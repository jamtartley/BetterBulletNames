using System.Text.RegularExpressions;

namespace BetterItemNames
{
    public class SniperBulletTransform : Transform
    {
        protected override Regex NameMatcher => new Regex(@"^(.+?)\s+Sniper Bullet\s*$");

        public override string? Replacer(string originalName)
        {
            var match = NameMatcher.Match(originalName);
            if (match.Success)
            {
                string prefix = match.Groups[1].Value.Trim();

                return $"(Snip) {prefix}";
            }

            return null;
        }
    }
}

