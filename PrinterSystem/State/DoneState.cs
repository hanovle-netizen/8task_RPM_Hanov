namespace PrinterSystem.State;

/// <summary>
/// Done — документ напечатан; финальное состояние.
/// </summary>
public class DoneState : IDocumentState
{
    public string StateName => "Done";

    public void AddToQueue(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: уже напечатан — повторная постановка недоступна.");

    public void StartPrinting(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: уже напечатан.");

    public void FinishPrinting(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: уже напечатан.");

    public void ReportError(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: уже напечатан — ошибка недоступна.");
}
