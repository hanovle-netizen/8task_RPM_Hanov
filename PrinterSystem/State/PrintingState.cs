namespace PrinterSystem.State;

/// <summary>
/// Printing — документ сейчас печатается; нельзя добавить в очередь повторно.
/// </summary>
public class PrintingState : IDocumentState
{
    public string StateName => "Printing";

    public void AddToQueue(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: уже печатается — нельзя добавить в очередь повторно.");

    public void StartPrinting(Document doc) =>
        Console.WriteLine($"  [State] {doc.Name}: уже печатается.");

    public void FinishPrinting(Document doc)
    {
        Console.WriteLine($"  [State] {doc.Name}: Printing → Done");
        doc.SetState(new DoneState());
        doc.Mediator.OnPrintSuccess(doc);
    }

    public void ReportError(Document doc)
    {
        Console.WriteLine($"  [State] {doc.Name}: Printing → Error");
        doc.SetState(new ErrorState());
        doc.Mediator.OnPrintError(doc);
    }
}
