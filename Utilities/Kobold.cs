namespace Tanuki.KoboldKare.Utilities;

internal static class Kobold
{
    public static string GetPrefabName(string Name) => Name.Replace("(Clone)", "");
}