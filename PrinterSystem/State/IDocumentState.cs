namespace PrinterSystem.State;

public interface IDocumentState
{
    void AddToQueue(Document doc);
    void StartPrinting(Document doc);
    void FinishPrinting(Document doc);
    void ReportError(Document doc);
    string StateName { get; }
}
