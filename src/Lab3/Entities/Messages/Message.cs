namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message : IMessage
{
    public string Tittle { get; }

    public string Body { get; }

    public int PriorityLvl { get; }

    public Message(string tittle, string body, int priorityLvl)
    {
        Tittle = tittle;
        Body = body;
        PriorityLvl = priorityLvl;
    }
}