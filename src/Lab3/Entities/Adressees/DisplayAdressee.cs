using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Adressees;

public class DisplayAdressee : IAdressee
{
    public ILogger Logger { get; }

    public int PriorityLvl { get; }

    public IDisplay Display { get; }

    public DisplayAdressee(int priorityLvl, IDisplay display, ILogger logger)
    {
        PriorityLvl = priorityLvl;
        Display = display;
        Logger = logger;
    }

    public OperationResult ReceiveMessege(IMessage message)
    {
        if (message.PriorityLvl >= PriorityLvl)
        {
            Logger.Log("Adressee received message");
            Display.ShowMessage(message);
            return new OperationResult.Success();
        }

        Logger.Log("Message have low priority");
        return new OperationResult.LowPriorityLvlFault();
    }
}