using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class LoggingUserDecorator : IUser
{
    private readonly User _user;
    private readonly MockLogger _logger;

    public LoggingUserDecorator(MockLogger logger, User user)
    {
        _user = user;
        _logger = logger;
    }

    public void AddMessage(IMessage message)
    {
        _user.AddMessage(message);
        _logger.Log("User received message");
    }

    public bool CheckIfMessageRead(int ind)
    {
        return _user.CheckIfMessageRead(ind);
    }

    public OperationResult ReadMessages()
    {
        if (_user.ReadMessages() is OperationResult.Success)
        {
            _logger.Log("Messages has been read");
            return new OperationResult.Success();
        }

        _logger.Log("Message already read");
        return new OperationResult.MessageAlreadyReadFault();
    }
}