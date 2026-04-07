namespace PrinterSystem;

/// <summary>
/// FIFO-очередь документов, ожидающих печати.
/// </summary>
public class PrintQueue
{
    private readonly Queue<Document> _queue = new();

    public int Count => _queue.Count;
    public bool IsEmpty => _queue.Count == 0;

    public void Enqueue(Document doc)
    {
        _queue.Enqueue(doc);
        Console.WriteLine($"  [Queue]   {doc.Name} добавлен в очередь. Позиция: {_queue.Count}");
    }

    public Document? Dequeue() =>
        _queue.Count > 0 ? _queue.Dequeue() : null;
}
