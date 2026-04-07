namespace PrinterSystem.State;

/// <summary>
/// New — документ создан, можно добавить в очередь.
/// </summary>
public class NewState : IDocumentState
{
    public string StateName => "New";

    public void AddToQueue(Document doc)
    {
        doc.Mediator.OnDocumentAddedToQueue(doc);
    }

    public void StartPrinting(Document doc)
    {
        Console.WriteLine($"  [State] {doc.Name}: New → Printing");
        doc.SetState(new PrintingState());
    }

    public void FinishPrinting(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: недоступно в состоянии New.");

    public void ReportError(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: недоступно в состоянии New.");
}
