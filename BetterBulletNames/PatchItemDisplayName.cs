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

            FixRegularBullet(__instance, ref __result);
            FixSniperBullet(__instance, ref __result);
            FixShotgunShell(__instance, ref __result);
        }

        private static void FixRegularBullet(Item __instance, ref string __result)
        {
            var matchWithCaliber = Regex.Match(__result, @"^(.+?)\s+Bullet\s*\(([^)]+)\)\s*$");
            if (matchWithCaliber.Success)
            {
                UnityEngine.Debug.Log($"matchWithCaliber: {matchWithCaliber.Groups[0].Value}");
                string prefix = matchWithCaliber.Groups[1].Value.Trim();
                string caliber = matchWithCaliber.Groups[2].Value.Trim();

                __result = $"({caliber}) {prefix}";
                return;
            }
        }

        private static void FixSniperBullet(Item __instance, ref string __result)
        {
            var matchWithCaliber = Regex.Match(__result, @"^(.+?)\s+Sniper Bullet\s*$");
            if (matchWithCaliber.Success)
            {
                UnityEngine.Debug.Log($"matchWithCaliber: {matchWithCaliber.Groups[0].Value}");
                string prefix = matchWithCaliber.Groups[1].Value.Trim();

                __result = $"(Snip) {prefix}";
                return;
            }
        }

        private static void FixShotgunShell(Item __instance, ref string __result)
        {
            var matchWithCaliber = Regex.Match(__result, @"^(.+?)\s+Shotgun Shell\s*$");
            if (matchWithCaliber.Success)
            {
                UnityEngine.Debug.Log($"matchWithCaliber: {matchWithCaliber.Groups[0].Value}");
                string prefix = matchWithCaliber.Groups[1].Value.Trim();

                __result = $"(Shot) {prefix}";
                return;
            }
        }
    }
}
