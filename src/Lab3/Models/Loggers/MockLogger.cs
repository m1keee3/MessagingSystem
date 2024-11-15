using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

public class MockLogger : ILogger
{
    public Collection<string> Logs { get; } = new();

    public void Log(string message)
    {
        Logs.Add(message);
    }
}