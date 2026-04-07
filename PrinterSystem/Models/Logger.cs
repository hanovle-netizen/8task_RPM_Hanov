namespace PrinterSystem;

public class Logger
{
    private readonly List<string> _log = new();

    public void Log(string message)
    {
        var entry = $"[{DateTime.Now:HH:mm:ss}] {message}";
        _log.Add(entry);
        Console.WriteLine($"  [Log]     {entry}");
    }

    public void PrintAll()
    {
        Console.WriteLine("\n========== Полный журнал событий ==========");
        foreach (var entry in _log)
            Console.WriteLine(entry);
        Console.WriteLine("===========================================");
    }
}
