using BackgroundServiceQueueExample.Interfaces;
using BackgroundServiceQueueExample.Models;

namespace BackgroundServiceQueueExample.Services;

public class CustomerPublisher : ICustomerPublisher
{
    private readonly ILogger<CustomerPublisher> _logger;

    public CustomerPublisher(ILogger<CustomerPublisher> logger)
    {
        _logger = logger;
    }

    public async Task Publish(List<Customer> customers, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Publishing customer ...");

        await Task.Delay(2500, cancellationToken);

        _logger.LogInformation("\"{Name}\" has been published!");
    }
}