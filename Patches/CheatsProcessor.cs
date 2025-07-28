using HarmonyLib;

namespace Tanuki.KoboldKare.Patches;

internal static class CheatsProcessor
{
    [HarmonyPatch(typeof(global::CheatsProcessor), MethodType.Constructor)]
    public static class Constructor
    {
        public delegate void EventHandler(global::CheatsProcessor CheatsProcessor);
        public static event EventHandler After;
        public static void Postfix(global::CheatsProcessor __instance) => After?.Invoke(__instance);
    }
}