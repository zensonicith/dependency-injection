namespace DI.Core;

public class MiniContainer : IMiniContainer
{
    public void Print(string msg)
    {
        System.Console.WriteLine($"Message: {msg}");
    }
}
