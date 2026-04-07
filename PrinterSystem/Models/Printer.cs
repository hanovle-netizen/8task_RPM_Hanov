namespace PrinterSystem;

public class Printer
{
    public bool IsReady { get; private set; } = true;

    /// <summary>
    /// Имитирует печать документа.
    /// </summary>
    /// <param name="doc">Печатаемый документ.</param>
    /// <param name="simulateError">Если true — принтер «ломается».</param>
    public void Print(Document doc, bool simulateError = false)
    {
        if (!IsReady)
        {
            Console.WriteLine("  [Printer] Принтер недоступен.");
            return;
        }

        Console.WriteLine($"  [Printer] Начало печати: {doc.Name}");
        doc.StartPrinting();

        if (simulateError)
        {
            IsReady = false;
            Console.WriteLine($"  [Printer] ОШИБКА при печати {doc.Name}! Принтер сломан.");
            doc.ReportError();
        }
        else
        {
            Console.WriteLine($"  [Printer] Печать завершена: {doc.Name}");
            doc.FinishPrinting();
        }
    }

    public void Repair()
    {
        IsReady = true;
        Console.WriteLine("  [Printer] Принтер починен и готов к работе.");
    }
}
