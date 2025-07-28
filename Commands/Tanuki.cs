using Tanuki.KoboldKare.Models;
using UnityEngine;

namespace Tanuki.KoboldKare.Commands;

internal class Tanuki : ICommand
{
    public string Name => "tanuki";
    public string[] Aliases => null;

    public void Execute(string[] Arguments)
    {
        Main.Instance.CheatsManager.AppendText("<color=#e64c44>Tanuki.KoboldKare by Timofey Tanuki</color> / <color=#6194cd>tanu.su</color>");
        if (Arguments.Length > 0)
            Application.OpenURL("https://tanu.su/");
    }
}