using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplay
{
    public void ReloadDriver(IDisplayDriver driver);

    public void ShowMessage(IMessage message);

    public void ShowMessage(IMessage message, ConsoleColor color);
}