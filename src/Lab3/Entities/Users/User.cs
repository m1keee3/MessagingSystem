using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User : IUser
{
    private readonly List<UserMessage> _messages = new();

    public void AddMessage(IMessage message)
    {
        _messages.Add(new UserMessage(message.Tittle, message.Body, message.PriorityLvl));
    }

    public bool CheckIfMessageRead(int ind)
    {
        return _messages[ind].IsRead;
    }

    public OperationResult ReadMessages()
    {
        foreach (UserMessage message in _messages)
        {
            if (message.IsRead)
            {
                return new OperationResult.MessageAlreadyReadFault();
            }

            message.Read();
        }

        return new OperationResult.Success();
    }
}