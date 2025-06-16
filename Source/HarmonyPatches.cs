using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace PaintableSheets
{
    [HarmonyPatch(typeof(Building_Bed), nameof(Building_Bed.DrawColorTwo), MethodType.Getter)]
    public static class Building_Bed_DrawColorTwo
    {
        public static bool Prefix(ref Color __result, Building_Bed __instance, ref bool __state)
        {
            if (__instance.def.graphicData.shaderType != ShaderTypeDefOf.CutoutComplex || !__instance.def.building.paintable)
            {
                return true;
            }
            if (__instance.PaintColorDef == null)
            {
                if (__instance.def.building.paintable)
                {
                    __state = true;
                }
                return true;
            }
            __result = __instance.PaintColorDef.color;
            return false;
        }

        public static void Postfix(ref Color __result, Building_Bed __instance, bool __state)
        {
            if (__state)
            {
                Color grey = new Color(121f / 255f, 121f / 255f, 121f / 255f);
                __result = grey * __result;
            }
        }
    }

    [HarmonyPatch(typeof(Building_Bed), nameof(Building_Bed.DrawColor), MethodType.Getter)]
    public static class Building_Bed_DrawColor
    {
        public static bool Prefix(ref Color __result, Building_Bed __instance)
        {
            if (__instance.def.graphicData.shaderType != ShaderTypeDefOf.CutoutComplex || !__instance.def.building.paintable)
            {
                return true;
            }
            if (__instance.def.MadeFromStuff && __instance.Stuff != null)
            {
                __result = __instance.def.GetColorForStuff(__instance.Stuff);
                return false;
            }
            return true;
        }
    }
}
