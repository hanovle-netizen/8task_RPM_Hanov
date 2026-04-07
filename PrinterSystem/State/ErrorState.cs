namespace PrinterSystem.State;

/// <summary>
/// Error — ошибка печати; документ можно повторно отправить в очередь.
/// </summary>
public class ErrorState : IDocumentState
{
    public string StateName => "Error";

    public void AddToQueue(Document doc)
    {
        Console.WriteLine($"  [State] {doc.Name}: Error → New (повторная постановка в очередь)");
        doc.SetState(new NewState());
        doc.Mediator.OnDocumentAddedToQueue(doc);
    }

    public void StartPrinting(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: сначала повторите постановку в очередь.");

    public void FinishPrinting(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: недоступно в состоянии Error.");

    public void ReportError(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: уже в состоянии Error.");
}
