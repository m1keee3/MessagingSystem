namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayDriver : IDisplayDriver
{
    public ConsoleColor Color { get; private set; } = ConsoleColor.White;

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(ConsoleColor color)
    {
        Color = color;
    }

    public void WriteText(string text)
    {
        Console.Write(text);
    }
}