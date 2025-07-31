namespace Tanuki.KoboldKare.Models;

public interface ICommand
{
    public string Name { get; }
    public string[] Aliases { get; }
    public void Execute(string[] Arguments);
}