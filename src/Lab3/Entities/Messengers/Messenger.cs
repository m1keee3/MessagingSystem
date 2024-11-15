using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Messenger : IMessenger
{
    public void ReceiveMessage(IMessage message)
    {
        Console.Write($"Messenger: {message.Tittle}\n {message.Body}");
    }
}