using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display : IDisplay
{
    public IDisplayDriver Driver { get; private set; }

    public Display(IDisplayDriver driver)
    {
        Driver = driver;
    }

    public void ReloadDriver(IDisplayDriver driver)
    {
        Driver = driver;
    }

    public void ShowMessage(IMessage message)
    {
        Driver.Clear();
        Driver.WriteText($"{message.Tittle}\n {message.Body}");
    }

    public void ShowMessage(IMessage message, ConsoleColor color)
    {
        Driver.Clear();
        Driver.SetColor(color);
        Driver.WriteText($"{message.Tittle}\n {message.Body}");
    }
}