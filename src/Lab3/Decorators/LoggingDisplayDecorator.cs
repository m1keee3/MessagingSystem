using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class LoggingDisplayDecorator : IDisplay
{
    private readonly IDisplay _display;
    private readonly ILogger _logger;

    public LoggingDisplayDecorator(IDisplay display, ILogger logger)
    {
        _display = display;
        _logger = logger;
    }

    public void ReloadDriver(IDisplayDriver driver)
    {
        _logger.Log("Reloading driver");
        _display.ReloadDriver(driver);
    }

    public void ShowMessage(IMessage message)
    {
        _logger.Log("Showing message");
        _display.ShowMessage(message);
    }

    public void ShowMessage(IMessage message, ConsoleColor color)
    {
        _logger.Log("Showing message with different color");
        _display.ShowMessage(message, color);
    }
}