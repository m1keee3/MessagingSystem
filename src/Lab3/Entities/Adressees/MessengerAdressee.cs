using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Adressees;

public class MessengerAdressee : IAdressee
{
    public ILogger Logger { get; }

    public int PriorityLvl { get; }

    public IMessenger Messenger { get; }

    public MessengerAdressee(int priorityLvl, IMessenger messenger, ILogger logger)
    {
        PriorityLvl = priorityLvl;
        Messenger = messenger;
        Logger = logger;
    }

    public OperationResult ReceiveMessege(IMessage message)
    {
        if (message.PriorityLvl >= PriorityLvl)
        {
            Logger.Log("Adressee received message");
            Messenger.ReceiveMessage(message);
            return new OperationResult.Success();
        }

        Logger.Log("Message have low priority");
        return new OperationResult.LowPriorityLvlFault();
    }
}