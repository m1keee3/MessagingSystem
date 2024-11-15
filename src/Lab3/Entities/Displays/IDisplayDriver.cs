namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplayDriver
{
    public void Clear();

    public void SetColor(ConsoleColor color);

    public void WriteText(string text);
}