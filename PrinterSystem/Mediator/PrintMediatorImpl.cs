namespace PrinterSystem.Mediator;

/// <summary>
/// Посредник — координирует Printer, PrintQueue, Logger и Document.
/// Компоненты не знают друг о друге напрямую; всё общение идёт через этот объект.
/// </summary>
public class PrintMediatorImpl : IPrintMediator
{
    private readonly Printer _printer;
    private readonly PrintQueue _queue;
    private readonly Logger _logger;

    public PrintMediatorImpl(Printer printer, PrintQueue queue, Logger logger)
    {
        _printer = printer;
        _queue   = queue;
        _logger  = logger;
    }

    // ── Вызывается из Document.AddToQueue() через состояние ──────────────
    public void OnDocumentAddedToQueue(Document doc)
    {
        _queue.Enqueue(doc);
        _logger.Log($"Документ «{doc.Name}» добавлен в очередь печати.");
    }

    // ── Вызывается Dispatcher-ом ─────────────────────────────────────────
    public void StartPrintNext(bool simulateError = false)
    {
        if (_queue.IsEmpty)
        {
            Console.WriteLine("  [Mediator] Очередь пуста — нечего печатать.");
            return;
        }

        if (!_printer.IsReady)
        {
            Console.WriteLine("  [Mediator] Принтер не готов — починка...");
            _printer.Repair();
        }

        var doc = _queue.Dequeue()!;
        _logger.Log($"Начата печать «{doc.Name}».");
        _printer.Print(doc, simulateError);
    }

    // Реализация интерфейса (без параметра — используется из состояний)
    public void StartPrintNext() => StartPrintNext(false);

    // ── Колбэки от состояний документа ───────────────────────────────────
    public void OnPrintSuccess(Document doc)
    {
        _logger.Log($"Документ «{doc.Name}» успешно напечатан. Состояние: {doc.StateName}.");
    }

    public void OnPrintError(Document doc)
    {
        _logger.Log($"ОШИБКА печати «{doc.Name}». Состояние: {doc.StateName}. Можно повторить.");
    }
}
