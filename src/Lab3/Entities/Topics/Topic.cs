using Itmo.ObjectOrientedProgramming.Lab3.Entities.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic
{
    public string Name { get; }

    private readonly List<IAdressee> _adressee = new();

    public Topic(string name)
    {
        Name = name;
    }

    public void AddAdressee(IAdressee adressee)
    {
        _adressee.Add(adressee);
    }

    public void SendMessage(IMessage message)
    {
        foreach (IAdressee adressee in _adressee)
        {
            adressee.ReceiveMessege(message);
        }
    }
}