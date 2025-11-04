using System.Text.RegularExpressions;
using ItemStatsSystem;
using HarmonyLib;

namespace BetterBulletNames
{
    [HarmonyPatch(typeof(Item), nameof(Item.DisplayName), MethodType.Getter)]
    public class PatchItemDisplayName
    {
        static void Postfix(Item __instance, ref string __result)
        {
            UnityEngine.Debug.Log($"Item.DisplayName: {__result}");

            var matchWithCaliber = Regex.Match(__result, @"^(.+?)\s+Bullet\s*\(([^)]+)\)\s*$");
            if (matchWithCaliber.Success)
            {
                UnityEngine.Debug.Log($"matchWithCaliber: {matchWithCaliber.Groups[0].Value}");
                string prefix = matchWithCaliber.Groups[1].Value.Trim();
                string caliber = matchWithCaliber.Groups[2].Value.Trim();

                __result = $"({caliber}) {prefix}";
                return;
            }

            var matchSniper = Regex.Match(__result, @"^(.+?)\s+Sniper Bullet$");
            if (matchSniper.Success)
            {
                UnityEngine.Debug.Log($"matchSniper: {matchSniper.Groups[0].Value}");
                string prefix = matchSniper.Groups[1].Value.Trim();

                __result = $"(Snip) {prefix}";
            }

            var matchShotgun = Regex.Match(__result, @"^(.+?)\s+Shotgun Shell$");
            if (matchShotgun.Success)
            {
                UnityEngine.Debug.Log($"matchShotgun: {matchShotgun.Groups[0].Value}");
                string prefix = matchShotgun.Groups[1].Value.Trim();

                __result = $"(Shot) {prefix}";
            }
        }
    }
}
