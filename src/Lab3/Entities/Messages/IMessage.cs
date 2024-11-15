namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public interface IMessage
{
    public string Tittle { get; }

    public string Body { get; }

    public int PriorityLvl { get; }
}