using Photon.Pun;
using Tanuki.KoboldKare.Models;
using UnityEngine;

namespace Tanuki.KoboldKare.Commands;

internal class Equip : ICommand
{
    public string Name => "equip";
    public string[] Aliases => null;

    public void Execute(string[] Arguments)
    {
        if (Arguments.Length == 0)
        {
            Main.Instance.CheatsManager.AppendText("<color=grey>/equip <item></color>");
            return;
        }

        string EquipmentName = string.Join(" ", Arguments);
        Equipment Equipment = null;

        try
        {
            Equipment = EquipmentDatabase.GetEquipment(EquipmentName);
        }
        catch (UnityException) { }

        if (Equipment is null)
        {
            Main.Instance.CheatsManager.AppendText(string.Format("<color=red>Equipment \"{0}\" not found.</color>", EquipmentName));
            return;
        }

        Kobold KoboldCaller = (Kobold)PhotonNetwork.LocalPlayer.TagObject;

        KoboldCaller.photonView.RPC("PickupEquipmentRPC", 0, [EquipmentDatabase.GetID(Equipment), -1]);
        Main.Instance.CheatsManager.AppendText(string.Format("<color=green>Item \"{0}\" equipped.</color>", EquipmentName));
    }
}