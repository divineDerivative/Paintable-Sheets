using HarmonyLib;
using Verse;

namespace PaintableSheets
{
    [StaticConstructorOnStartup]
    public static class OnStartup
    {
        static OnStartup()
        {
            Harmony harmony = new Harmony(id: "rimworld.divineDerivative.paintableSheets");
            harmony.PatchAll();
        }
    }
}