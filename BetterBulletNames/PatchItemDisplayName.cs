using System.Collections.Generic;
using ItemStatsSystem;
using HarmonyLib;

namespace BetterBulletNames
{
    [HarmonyPatch(typeof(Item), nameof(Item.DisplayName), MethodType.Getter)]
    public class PatchItemDisplayName
    {
        private static Dictionary<string, string> displayNameConversions = new Dictionary<string, string> {
            { "Standard Bullet (AR)", "(AR) Standard" }
        };

        static void Postfix(Item __instance, ref string __result)
        {
            if (displayNameConversions.ContainsKey(__result))
            {
                __result = displayNameConversions[__result];
            }
        }
    }
}
