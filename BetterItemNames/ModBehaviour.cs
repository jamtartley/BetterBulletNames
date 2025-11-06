namespace BetterItemNames
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        private const string Id = "jamtartley.BetterItemNames";
        private HarmonyLib.Harmony? harmony;

        private void OnEnable()
        {
            harmony = new HarmonyLib.Harmony(Id);
            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
        }

        private void OnDisable()
        {
            harmony?.UnpatchAll(Id);
        }
    }
}
