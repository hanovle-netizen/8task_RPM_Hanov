namespace PrinterSystem.Mediator;

public interface IPrintMediator
{
    void OnDocumentAddedToQueue(Document doc);
    void OnPrintSuccess(Document doc);
    void OnPrintError(Document doc);
    void StartPrintNext();
}
