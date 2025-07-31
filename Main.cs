using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace Tanuki.KoboldKare;

[BepInPlugin("c6e77d51-a831-42e1-ba1c-d007cc546c31", "Tanuki.KoboldKare", "1.1.0.0")]
[BepInProcess("KoboldKare.exe")]
public class Main : BaseUnityPlugin
{
    internal static Main Instance;

    internal ManualLogSource ManualLogSource;

    internal Managers.Command CheatsManager;
    internal Managers.UsableMachines UsableMachinesManager;

    private bool UsageAnnounced = false;

    internal void Awake()
    {
        Instance = this;

        ManualLogSource = BepInEx.Logging.Logger.CreateLogSource("Tanuki.KoboldKare");
        ManualLogSource.LogInfo("Tanuki.KoboldKare by Timofey Tanuki / tanu.su");

        string ApplicationVersion = "05.12.2025_cc1519c8";
        if (Application.version != ApplicationVersion)
            ManualLogSource.LogWarning($"This plugin is made for game version {ApplicationVersion} (your version is {Application.version})!\nNormal operation is not guaranteed.\nYou can contact the developer if necessary.");

        CheatsManager = Managers.Command.GetInstance();
        UsableMachinesManager = Managers.UsableMachines.GetInstance();

        Patches.CheatsProcessor.Constructor.After += Constructor_After;

        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
    }
    private void Constructor_After(CheatsProcessor CheatsProcessor)
    {
        if (LevelLoader.instance is null)
            return;

        if (UsageAnnounced)
            return;

        UsageAnnounced = true;
        CheatsManager.AppendText("<b><size=12><color=#e64c44>Tanuki.KoboldKare by Timofey Tanuki / tanu.su</color></size>\n<size=11><color=#577fba>Replaced commands:\ncheats, cum, equip, sculpt, skip, swap</color>\n<color=#57adba>Added commands:\nteleport, kku</color>\n<color=#57adba>The use of any commands is not displayed in the chat for others.</color></size></b>");
    }
}