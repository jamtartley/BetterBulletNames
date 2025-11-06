using System.Text.RegularExpressions;

namespace BetterItemNames
{
    public abstract class Transform
    {
        protected abstract Regex NameMatcher { get; }
        public abstract string? Replacer(string originalName);
    }
}
