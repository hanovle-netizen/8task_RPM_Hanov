using PrinterSystem.Mediator;
using PrinterSystem.State;

namespace PrinterSystem;

public class Document
{
    public string Name { get; }
    public IPrintMediator Mediator { get; }

    private IDocumentState _state;
    public string StateName => _state.StateName;

    public Document(string name, IPrintMediator mediator)
    {
        Name = name;
        Mediator = mediator;
        _state = new NewState();
    }

    public void SetState(IDocumentState state) => _state = state;

    public void AddToQueue()      => _state.AddToQueue(this);
    public void StartPrinting()   => _state.StartPrinting(this);
    public void FinishPrinting()  => _state.FinishPrinting(this);
    public void ReportError()     => _state.ReportError(this);
}
