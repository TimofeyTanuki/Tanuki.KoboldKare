using Photon.Pun;
using Photon.Realtime;
using Tanuki.KoboldKare.Models;

namespace Tanuki.KoboldKare.Commands;

internal class Teleport : ICommand
{
    public string Name => "teleport";
    public string[] Aliases => ["tp"];

    public void Execute(string[] Arguments)
    {
        Kobold KoboldCaller = (Kobold)PhotonNetwork.LocalPlayer.TagObject;
        switch (Arguments.Length)
        {
            case 1:
                TeleportToPlayer(KoboldCaller, Arguments);
                return;
            case 3:
                TeleportToPosition(KoboldCaller, Arguments);
                return;
        }
        Main.Instance.CheatsManager.AppendText("<color=grey>/tp <Target ID>\n/tp <x> <y> <z></color>");
    }
    private void TeleportToPlayer(Kobold Caller, string[] Arguments)
    {
        if (!int.TryParse(Arguments[0], out int TargetID))
        {
            Main.Instance.CheatsManager.AppendText("<color=red>Invalid player ID.</color>");
            return;
        }

        Player Target = null;

        foreach (Player Player in PhotonNetwork.PlayerListOthers)
        {
            if (Player.ActorNumber != TargetID)
                continue;

            Target = Player;
            break;
        }

        if (Target is null)
        {
            Main.Instance.CheatsManager.AppendText("<color=red>Target not found.</color>");
            return;
        }

        Caller.transform.position = ((Kobold)Target.TagObject).transform.position;
        Main.Instance.CheatsManager.AppendText(string.Format("<color=green>You are teleported to [{0}] {1}</color>", Target.ActorNumber, Target.NickName));
    }
    private void TeleportToPosition(Kobold Caller, string[] Arguments)
    {
        float[] Coordinates = new float[3];
        for (byte i = 0; i < 3; i++)
        {
            if (float.TryParse(Arguments[i], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out Coordinates[i]))
                continue;

            Main.Instance.CheatsManager.AppendText("<color=red>Invalid coordinates.</color>");
            return;
        }

        Caller.transform.position = new(Coordinates[0], Coordinates[1], Coordinates[2]);
        Main.Instance.CheatsManager.AppendText(
            string.Format(
                "<color=green>You are teleported to coordinates (x: {0}, y: {1}, z: {2})</color>",
                Coordinates[0],
                Coordinates[1],
                Coordinates[2]
            )
        );
    }
}