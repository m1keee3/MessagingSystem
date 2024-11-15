using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Adressees;

public class GroupAdressee : IAdressee
{
    public ILogger Logger { get; }

    public int PriorityLvl { get; }

    private readonly List<IAdressee> _adressees = new();

    public GroupAdressee(int priorityLvl, ILogger logger)
    {
        PriorityLvl = priorityLvl;
        Logger = logger;
    }

    public void AddAdressee(IAdressee adressee)
    {
        _adressees.Add(adressee);
    }

    public OperationResult ReceiveMessege(IMessage message)
    {
        if (message.PriorityLvl >= PriorityLvl)
        {
            foreach (IAdressee adressee in _adressees)
            {
                Logger.Log("Adressee received message");
                adressee.ReceiveMessege(message);
                return new OperationResult.Success();
            }
        }

        Logger.Log("Message have low priority");
        return new OperationResult.LowPriorityLvlFault();
    }
}