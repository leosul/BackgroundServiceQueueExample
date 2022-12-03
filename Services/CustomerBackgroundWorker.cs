using BackgroundServiceQueueExample.Interfaces;
using BackgroundServiceQueueExample.Models;

namespace BackgroundServiceQueueExample.Services;

public class CustomerBackgroundWorker : BackgroundService
{
    private readonly IBackgroundQueue<List<Customer>> _queue;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<CustomerBackgroundWorker> _logger;

    public CustomerBackgroundWorker(IBackgroundQueue<List<Customer>> queue, 
                                    IServiceScopeFactory scopeFactory, 
                                    ILogger<CustomerBackgroundWorker> logger)
    {
        _queue = queue;
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("{Type} is now running in the background.", nameof(CustomerBackgroundWorker));

        await BackgroundProcessing(stoppingToken);
    }
    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(500, stoppingToken);
                var customer = _queue.Dequeue();

                if (customer == null) continue;

                _logger.LogInformation("Customer found! Starting to process ..");

                using (var scope = _scopeFactory.CreateScope())
                {
                    var publisher = scope.ServiceProvider.GetRequiredService<ICustomerPublisher>();

                    await publisher.Publish(customer, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occurred when publishing a customer. Exception: {@Exception}", ex);
            }
        }
    }
}
