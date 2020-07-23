using System;
namespace SourceConsole.Repository
{
    public interface IInteractionRepository
    {
        string[] GetAvailableCommands();
    }
}
