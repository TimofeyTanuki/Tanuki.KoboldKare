using Photon.Pun;
using Photon.Realtime;
using Tanuki.KoboldKare.Models;
using UnityEngine;

namespace Tanuki.KoboldKare.Commands;

internal class Swap : ICommand
{
    public string Name => "swap";
    public string[] Aliases => null;

    private BrainSwapperMachine BrainSwapperMachine;

    public void Execute(string[] Arguments)
    {
        BrainSwapperMachine ??= Main.Instance.UsableMachinesManager.BrainSwapperMachine;
        if (BrainSwapperMachine is null)
        {
            Main.Instance.CheatsManager.AppendText("<color=red>Couldn't find the brain swapper machine.</color>");
            return;
        }

        Player Target = null,
               Caller = PhotonNetwork.LocalPlayer;

        Kobold KoboldCaller = (Kobold)Caller.TagObject;

        foreach (RaycastHit RaycastHit in Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 256f))
        {
            Kobold KoboldTarget = RaycastHit.collider.GetComponentInParent<Kobold>();
            if (KoboldTarget is null)
                continue;

            if (KoboldTarget == KoboldCaller)
                continue;

            foreach (Player Player in PhotonNetwork.PlayerListOthers)
            {
                if ((Kobold)Player.TagObject != KoboldTarget)
                    continue;

                Target = Player;
                break;
            }

            try
            {
                KoboldTarget.photonView.RequestOwnership();
                BrainSwapperMachine.photonView.RPC(
                    "AssignKobolds",
                    0,
                    [
                        KoboldCaller.photonView.ViewID,
                        KoboldTarget.photonView.ViewID,
                        (Target is null) ? -1 : Target.ActorNumber,
                        Caller.ActorNumber,
                        KoboldTarget.GetComponent<MoneyHolder>().GetMoney(),
                        KoboldCaller.GetComponent<MoneyHolder>().GetMoney()
                    ]
                );

                Main.Instance.CheatsManager.AppendText(
                    Target is null ?
                        string.Format("<color=green>You swapped your kobold \"{0}\" ({1}) to \"{2}\" ({3}).</color>",
                            Utilities.Kobold.GetPrefabName(KoboldCaller.name),
                            KoboldCaller.photonView.ViewID,
                            Utilities.Kobold.GetPrefabName(KoboldTarget.name),
                            KoboldTarget.photonView.ViewID
                        )
                        :
                        string.Format("<color=green>You swapped your kobold \"{0}\" ({1}) with {2} [{3}] on \"{4}\" ({5}).</color>",
                            Utilities.Kobold.GetPrefabName(KoboldCaller.name),
                            KoboldCaller.photonView.ViewID,
                            Target.NickName,
                            Target.ActorNumber,
                            Utilities.Kobold.GetPrefabName(KoboldTarget.name),
                            KoboldTarget.photonView.ViewID
                        )
                );
            }
            catch
            {
                Main.Instance.CheatsManager.AppendText("The body swap failed.");
            }
            return;
        }

        Main.Instance.CheatsManager.AppendText("<color=red>You're not looking at the kobold.</color>");
    }
}