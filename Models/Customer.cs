namespace BackgroundServiceQueueExample.Models;

public class Customer
{
    public Customer()
    {

    }
    public Customer(string name, bool isActive)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsActive = isActive;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public ICollection<Invoice> Invoices { get; private set; }

    public List<Customer> Initialize()
    {
        var customers = new List<Customer>();

        for (int i = 0; i < 50; i++)
        {
            var customer = new Customer($"Customer_{i}", i % 2 == 0);

            var invoices = new List<Invoice>();
            for (int x = 0; x < 5; x++)
            {
                var invoice = new Invoice(
                    $"Invoice-{i * (i % 2 == 0 ? 4 : 3)}",
                    Math.Round(i * (i % 2 == 0 ? 4.543M : 3.8976M), 2),
                    Math.Round(i * (i % 2 == 0 ? 2.524M : 1.8860M), 2),
                    i % 2 == 0 ? DateTime.UtcNow.AddDays(-i * 2) :
                    DateTime.UtcNow.AddDays(-i * 4));

                invoices.Add(invoice);
            }

            customer.AddInvoice(invoices);
            customers.Add(customer);
        }

        return customers;
    }
    public void AddInvoice(ICollection<Invoice> invoices) => Invoices = invoices;
}
