using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using Tanuki.KoboldKare.Commands;
using Tanuki.KoboldKare.Models;

namespace Tanuki.KoboldKare.Managers;

internal class Command
{
    private static Command Instance;
    public CheatsProcessor CheatsProcessor { get; private set; }
    private Command()
    {
        Patches.CheatsProcessor.Constructor.After += Constructor_After;
        Patches.PlayerPossession.OnTextSubmit.Before += OnTextSubmit_Before;
    }
    public static Command GetInstance()
    {
        Instance ??= new();
        return Instance;
    }
    private readonly List<ICommand> Commands =
        [
            new Cum(),
            new Equip(),
            new Skip(),
            new Swap(),
            new Teleport(),
            new Cheats(),
            new Sculpt(),
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

        ShouldAllow = false;

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

            /*
             * This should be reworked to improve parameter handling.
             * Currently, parameters are separated strictly by spaces, so parameters cannot be compound (consisting of two or more values).
             */
            string[] Arguments = ArgumentsIndex == Text.Length ? [] : Text.Substring(ArgumentsIndex).Split([' '], StringSplitOptions.RemoveEmptyEntries);

            Command.Execute(Arguments);
            return;
        }
        try
        {
            CheatsProcessor.ProcessCommand((Kobold)PhotonNetwork.LocalPlayer.TagObject, Text);
        }
        catch (Exception Exception)
        {
            AppendText("<color=red>An error occurred while executing the command.</color>");
            Main.Instance.ManualLogSource.LogError($"Command: \"{Text}\"\n{Exception}");
        }
    }
    private void Constructor_After(CheatsProcessor CheatsProcessor) => this.CheatsProcessor = CheatsProcessor;
    public void AppendText(string Text) => CheatsProcessor.AppendText(Text + "\n");
}