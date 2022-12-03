using BackgroundServiceQueueExample.Interfaces;
using BackgroundServiceQueueExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundServiceQueueExample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class CustomersController : ControllerBase
{
    private readonly IBackgroundQueue<List<Customer>> _queue;
    public CustomersController(IBackgroundQueue<List<Customer>> queue)
    {
        _queue = queue;
    }

    [HttpPost]
    public IActionResult Publish()
    {
        var data = new Customer().Initialize();

        _queue.Enqueue(data);

        return Accepted();
    }
}
