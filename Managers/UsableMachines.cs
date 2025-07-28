using UnityEngine;

namespace Tanuki.KoboldKare.Managers;

internal class UsableMachines
{
    private static UsableMachines Instance;
    private UsableMachines() { }
    public static UsableMachines GetInstance()
    {
        Instance ??= new();
        return Instance;
    }

    private BrainSwapperMachine _BrainSwapperMachine;
    public BrainSwapperMachine BrainSwapperMachine
    {
        get
        {
            _BrainSwapperMachine ??= Object.FindObjectOfType<BrainSwapperMachine>();
            return _BrainSwapperMachine;
        }
    }
}