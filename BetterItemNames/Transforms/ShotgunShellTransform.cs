using System.Text.RegularExpressions;

namespace BetterItemNames
{
    public class ShotgunShellTransform : Transform
    {
        protected override Regex NameMatcher => new Regex(@"^(.+?)\s+Shotgun Shell\s*$");

        public override string? Replacer(string originalName)
        {
            var match = NameMatcher.Match(originalName);
            if (match.Success)
            {
                string prefix = match.Groups[1].Value.Trim();

                return $"(Shot) {prefix}";
            }

            return null;
        }
    }
}

