using RimWorld;
using HarmonyLib;
using UnityEngine;

namespace PaintableSheets
{
    [HarmonyPatch(typeof(Building_Bed), nameof(Building_Bed.DrawColorTwo), MethodType.Getter)]
    public static class Building_Bed_DrawColorTwo
    {
        public static bool Prefix(ref Color __result, Building_Bed __instance)
        {
            if (__instance.PaintColorDef == null)
            {
                return true;
            }
            __result = __instance.PaintColorDef.color;
            return false;
        }


    }

    [HarmonyPatch(typeof(Building_Bed), nameof(Building_Bed.DrawColor), MethodType.Getter)]
    public static class Building_Bed_DrawColor
    {
        public static bool Prefix(ref Color __result, Building_Bed __instance)
        {
            if (__instance.def.MadeFromStuff && __instance.Stuff != null)
            {
                __result = __instance.def.GetColorForStuff(__instance.Stuff);
                return false;
            }
            return true;
        }
    }
}
