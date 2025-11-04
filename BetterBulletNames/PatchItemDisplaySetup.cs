namespace BetterBulletNames
{
    [HarmonyLib.HarmonyPatch(typeof(Duckov.UI.ItemDisplay), "Setup")]
    public class PatchItemDisplaySetup
    {
        static void Postfix(Duckov.UI.ItemDisplay __instance, ItemStatsSystem.Item target)
        {
            var originalName = target.DisplayName;

            UnityEngine.Debug.Log("[BetterBulletNames] Original name: " + originalName);
        }
    }
}
