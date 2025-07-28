using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using Tanuki.KoboldKare.Commands;
using Tanuki.KoboldKare.Models;

namespace Tanuki.KoboldKare.Managers;

internal class CheatsProcessor
{
    private static CheatsProcessor Instance;
    private CheatsProcessor()
    {
        Patches.CheatsProcessor.Constructor.After += Constructor_After;
        Patches.PlayerPossession.OnTextSubmit.Before += OnTextSubmit_Before;
    }
    public static CheatsProcessor GetInstance()
    {
        Instance ??= new();
        return Instance;
    }

    public global::CheatsProcessor OriginalCheatsProcessor { get; private set; }
    private readonly List<ICommand> Commands =
        [
            new Cum(),
            new Equip(),
            new Skip(),
            new Swap(),
            new Teleport(),
            new Commands.Tanuki()
        ];

    private void OnTextSubmit_Before(string Text, ref bool ShouldAllow)
    {
        if (string.IsNullOrEmpty(Text))
            return;

        if (!Text.StartsWith("/"))
            return;


        if (Text.Length <= 1)
            return;

        int ArgumentsIndex = Text.IndexOf(' ');
        if (ArgumentsIndex < 0)
            ArgumentsIndex = Text.Length;

        string CommandName = Text.Substring(0, ArgumentsIndex).TrimStart('/').ToLower();

        foreach (ICommand Command in Commands)
        {
            if (!Command.Name.Equals(CommandName))
            {
                if (Command.Aliases is null)
                    continue;

                if (!Command.Aliases.Contains(CommandName))
                    continue;
            }

            string[] Arguments = ArgumentsIndex == Text.Length ? [] : Text.Substring(ArgumentsIndex).Split([' '], StringSplitOptions.RemoveEmptyEntries);

            Command.Execute(Arguments);
            return;
        }
        try
        {
            global::CheatsProcessor.ProcessCommand((Kobold)PhotonNetwork.LocalPlayer.TagObject, Text);
        }
        catch (Exception Exception)
        {
            AppendText("<color=red>An error occurred while executing the command.</color>");
            Main.Instance.ManualLogSource.LogError($"Command: \"{Text}\"\n{Exception}");
        }
    }
    private void Constructor_After(global::CheatsProcessor CheatsProcessor) => OriginalCheatsProcessor = CheatsProcessor;
    public void AppendText(string Text) => global::CheatsProcessor.AppendText(Text + "\n");
}