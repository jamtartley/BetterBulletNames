using System.Collections.Generic;
using ItemStatsSystem;
using HarmonyLib;

namespace BetterItemNames
{
    [HarmonyPatch(typeof(Item), nameof(Item.DisplayName), MethodType.Getter)]
    public class PatchItemDisplayName
    {
        static void Postfix(Item __instance, ref string __result)
        {
            IEnumerable<Transform> matchers = new List<Transform>() {
                new RegularBulletTransform(),
                new SniperBulletTransform(),
                new ShotgunShellTransform(),
            };

            foreach (var matcher in matchers)
            {
                var replaced = matcher.Replacer(__result);
                if (replaced != null)
                {
                    __result = replaced;
                    return;
                }
            }
        }
    }
}
