namespace BackgroundServiceQueueExample.Models;

public class Invoice
{
    public Invoice(string invoiceNumber, decimal grossValue, decimal netValue, DateTime invoiceDate)
    {
        Id = Guid.NewGuid();
        InvoiceNumber = invoiceNumber;
        GrossValue = grossValue;
        NetValue = netValue;
        InvoiceDate = invoiceDate;
    }
    public Guid Id { get; private set; }

    public string InvoiceNumber { get; private set; }

    public decimal GrossValue { get; private set; }

    public decimal NetValue { get; private set; }

    public DateTime InvoiceDate { get; private set; }
}
