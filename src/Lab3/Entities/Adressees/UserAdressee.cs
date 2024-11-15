using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Adressees;

public class UserAdressee : IAdressee
{
    public ILogger Logger { get; }

    public int PriorityLvl { get; }

    public IUser User { get; }

    public UserAdressee(int priorityLvl, IUser user, ILogger logger)
    {
        PriorityLvl = priorityLvl;
        User = user;
        Logger = logger;
    }

    public OperationResult ReceiveMessege(IMessage message)
    {
        if (message.PriorityLvl >= PriorityLvl)
        {
            Logger.Log("Adressee received message");
            User.AddMessage(message);
            return new OperationResult.Success();
        }

        Logger.Log("Message have low priority");
        return new OperationResult.LowPriorityLvlFault();
    }
}