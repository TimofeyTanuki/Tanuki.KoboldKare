using Photon.Pun;
using Tanuki.KoboldKare.Models;

namespace Tanuki.KoboldKare.Commands;

internal class Cum : ICommand
{
    public string Name => "cum";
    public string[] Aliases => null;

    private const string RPCMethodName = "Cum";

    public void Execute(string[] Arguments)
    {
        Kobold KoboldCaller = (Kobold)PhotonNetwork.LocalPlayer.TagObject;
        switch (Arguments.Length)
        {
            case 0:
                KoboldCaller.photonView.RPC(RPCMethodName, RpcTarget.All, []);
                return;

            case 1:
                KoboldCaller.photonView.RequestOwnership();
                KoboldGenes KoboldGenes = KoboldCaller.GetGenes();
                float SavedBallsSize = KoboldGenes.ballSize;

                if (!float.TryParse(Arguments[0], out float BallsSize))
                {
                    Main.Instance.CheatsManager.AppendText("<color=red>Invalid balls size.</color>");
                    return;
                }

                KoboldGenes.ballSize = BallsSize;
                KoboldCaller.SetGenes(KoboldGenes);
                KoboldCaller.photonView.RPC(RPCMethodName, RpcTarget.All, []);
                KoboldGenes.ballSize = SavedBallsSize;
                KoboldCaller.SetGenes(KoboldGenes);
                return;

            default:
                Main.Instance.CheatsManager.AppendText("<color=grey>/cum <balls size></color>");
                return;
        }
    }
}