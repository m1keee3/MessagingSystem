namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class UserMessage : IMessage
{
    public bool IsRead { get; private set; } = false;

    public string Tittle { get; }

    public string Body { get; }

    public int PriorityLvl { get; }

    public UserMessage(string tittle, string body, int priorityLvl)
    {
        Tittle = tittle;
        Body = body;
        PriorityLvl = priorityLvl;
    }

    public void Read()
    {
        IsRead = true;
    }
}