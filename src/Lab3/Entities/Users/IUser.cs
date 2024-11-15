using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public interface IUser
{
    public void AddMessage(IMessage message);

    public bool CheckIfMessageRead(int ind);

    public OperationResult ReadMessages();
}