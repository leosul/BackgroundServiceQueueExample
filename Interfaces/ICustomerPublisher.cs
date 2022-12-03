using BackgroundServiceQueueExample.Models;

namespace BackgroundServiceQueueExample.Interfaces;

public interface ICustomerPublisher
{
    Task Publish(List<Customer> customers, CancellationToken cancellationToken = default);
}
