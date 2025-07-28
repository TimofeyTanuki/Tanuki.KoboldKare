using Tanuki.KoboldKare.Models;

namespace Tanuki.KoboldKare.Commands;

internal class Skip : ICommand
{
    public string Name => "skip";
    public string[] Aliases => null;

    public void Execute(string[] Arguments)
    {
        switch (Arguments.Length)
        {
            case 0:
                ObjectiveManager.SkipObjective();
                Main.Instance.CheatsManager.AppendText("<color=green>Objective skipped!</color>");
                return;

            case 1:

                if (!ushort.TryParse(Arguments[0], out ushort Count))
                {
                    Main.Instance.CheatsManager.AppendText("<color=red>Invalid objectives count.</color>");
                    return;
                }

                for (ushort i = 0; i < Count; ++i)
                    ObjectiveManager.SkipObjective();

                Main.Instance.CheatsManager.AppendText(string.Format("<color=green>Skipped {0} objectives!</color>", Count));
                return;

            default:
                Main.Instance.CheatsManager.AppendText("<color=grey>/skip [Count]</color>");
                return;
        }
    }
}