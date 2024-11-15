using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class LoggingMessengerDecorator : IMessenger
{
    private readonly ILogger _logger;
    private readonly IMessenger _messenger;

    public LoggingMessengerDecorator(ILogger logger, IMessenger messenger)
    {
        _logger = logger;
        _messenger = messenger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _logger.Log("Messenger received message");
        _messenger.ReceiveMessage(message);
    }
}