namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}