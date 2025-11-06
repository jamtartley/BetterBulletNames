using System;
using System.Reflection;
using System.Linq;
using ItemStatsSystem;
using HarmonyLib;

namespace BetterItemNames
{
    [HarmonyPatch(typeof(Item), nameof(Item.DisplayName), MethodType.Getter)]
    public class PatchItemDisplayName
    {
        static void Postfix(Item __instance, ref string __result)
        {
            var transforms = Assembly.GetExecutingAssembly().GetTypes().Where(
                t => t.IsClass() && !t.IsAbstract && t.IsSubclassOf(typeof(Transform))
            ).Select(t => (Transform)Activator.CreateInstance(t));

            foreach (var transform in transforms)
            {
                var replaced = transform.Replacer(__result);
                if (replaced != null)
                {
                    __result = replaced;
                    return;
                }
            }
        }
    }
}
