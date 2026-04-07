using PrinterSystem.Mediator;

namespace PrinterSystem;

/// <summary>
/// Диспетчер (UI-уровень) — единственная точка входа для пользователя.
/// Работает только через посредника; не знает о Queue, Printer или Logger напрямую.
/// </summary>
public class Dispatcher
{
    private readonly PrintMediatorImpl _mediator;

    public Dispatcher(PrintMediatorImpl mediator)
    {
        _mediator = mediator;
    }

    /// <summary>Создаёт документ и ставит его в очередь.</summary>
    public Document CreateAndEnqueue(string name)
    {
        var doc = new Document(name, _mediator);
        doc.AddToQueue();
        return doc;
    }

    /// <summary>Запускает печать следующего документа из очереди.</summary>
    public void PrintNext() => _mediator.StartPrintNext(simulateError: false);

    /// <summary>Запускает печать следующего документа с имитацией ошибки принтера.</summary>
    public void PrintNextWithError() => _mediator.StartPrintNext(simulateError: true);

    /// <summary>Повторно ставит документ в состоянии Error в очередь.</summary>
    public void Retry(Document doc) => doc.AddToQueue();
}
