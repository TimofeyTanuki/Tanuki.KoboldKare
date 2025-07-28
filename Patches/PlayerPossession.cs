using HarmonyLib;

namespace Tanuki.KoboldKare.Patches;

internal static class PlayerPossession
{
    [HarmonyPatch(typeof(global::PlayerPossession), "OnTextSubmit")]
    internal static class OnTextSubmit
    {
        public delegate void OnBefore(string Text, ref bool ShouldAllow);
        public static event OnBefore Before;
        public static void Prefix(global::PlayerPossession __instance, ref string t)
        {
            bool ShouldAllow = true;
            Before?.Invoke(t, ref ShouldAllow);

            if (ShouldAllow)
                return;

            t = string.Empty;
        }
    }
}