using Tanuki.KoboldKare.Models;

namespace Tanuki.KoboldKare.Commands;

internal class Cheats : ICommand
{
    public string Name => "cheats";
    public string[] Aliases => null;

    public void Execute(string[] Arguments)
    {
        bool Cheats;
        if (Arguments.Length > 0)
        {
            if (!bool.TryParse(Arguments[0], out Cheats))
            {
                Main.Instance.CheatsManager.AppendText("<color=grey>Failed to parse argument as a boolean (true/false).</color>");
                return;
            }
        }
        else
            Cheats = !CheatsProcessor.GetCheatsEnabled();

        CheatsProcessor.SetCheatsEnabled(Cheats);
        Main.Instance.CheatsManager.AppendText($"<color=green>Cheats: {(Cheats ? "On" : "Off")}</color>");
    }
}